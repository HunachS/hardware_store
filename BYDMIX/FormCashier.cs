using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYDMIX
{
    public partial class FormCashier : Form
    {

        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cm = new OleDbCommand();
        string stitle = "Точка продажі";
        string id;
        string price;
        private DataGridViewRow selectedRow = null;




        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        public FormCashier()
        {
            InitializeComponent();
            cn = new OleDbConnection(ConnectionString);
            GetbtnNTran();
            SetSearchTextBoxHint();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void slide(Button button)
        {
            panelSlide.BackColor = Color.White;
            panelSlide.Height = button.Height;
            panelSlide.Top = button.Top;
        }

        private void btnNTran_Click(object sender, EventArgs e)
        {
            slide(btnNTran);
            GetbtnNTran();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            slide(btnSearch);
            LookUpProduct lookUp = new LookUpProduct(this);
            lookUp.LoadProducts();
            lookUp.ShowDialog();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            slide(btnDiscount);
            FormDiscount discount = new FormDiscount(this);
            discount.lbld.Text = id;
            discount.txtTotalPrice.Text = price;
            discount.ShowDialog();
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            slide(btnSettle);
            FormSettlePaymentcs settle = new FormSettlePaymentcs(this);
            settle.txtSale.Text = lblDisplayTotal.Text;
            settle.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            slide(btnClear);
            if (MessageBox.Show("Видалити всі значення з карти?", "Підтвердити", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cm = new OleDbCommand("DELETE FROM Cart WHERE Transno LIKE '" + lblTranNo.Text + "'", cn);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Всі значення були успішно видалені", "Видалити значення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCart();
            }
            // Очищаємо всі рядки
        }

        private void btnDSales_Click(object sender, EventArgs e)
        {
            slide(btnDSales);
            FormDailySale dailySale = new FormDailySale();
            dailySale.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            slide(btnLogout);
            this.Visible = false;
        }

        public void LoadCart()
        {
            Boolean hascart = false;
            int i = 0;
            double total = 0;
            double discount = 0;
            dgvCash.Rows.Clear();
            cn.Open();
            cm = new OleDbCommand(@"SELECT c.ID_Cart, c.Pcode, p.Description, c.Price, c.Qty, c.Disc, c.total 
        FROM Cart AS c 
        INNER JOIN Products AS p ON c.Pcode = p.PCode 
        WHERE c.Transno LIKE @Transno", cn);

            cm.Parameters.AddWithValue("@transno", lblTranNo.Text);
            OleDbDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                double price = Convert.ToDouble(dr["Price"]);
                int qty = Convert.ToInt32(dr["Qty"]);
                double itemTotal = price * qty;

                total += itemTotal ;
                discount += Convert.ToDouble(dr["Disc"]);
                string cartID = dr["ID_Cart"].ToString();
                dgvCash.Rows.Add(i, cartID, dr["Pcode"].ToString(), dr["Description"].ToString(), price, qty, dr["Disc"].ToString(), itemTotal.ToString("#,##0.00"));
                hascart = true;

                
            }

            dr.Close();
            cn.Close();

            cn.Open();
            foreach (DataGridViewRow row in dgvCash.Rows)
            {
                string cartID = row.Cells[1].Value.ToString();
                double itemTotal = Convert.ToDouble(row.Cells[7].Value);

                string updateQuery = "UPDATE Cart SET total = @Total WHERE ID_Cart = @CartID";
                using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, cn))
                {
                    updateCommand.Parameters.AddWithValue("@Total", itemTotal);
                    updateCommand.Parameters.AddWithValue("@CartID", cartID);
                    updateCommand.ExecuteNonQuery();
                }
            }
            cn.Close();

            lblSaleTotal.Text = total.ToString("#,##0.00"); // Встановити значення загальної суми
            lblDiscount.Text = discount.ToString("#,##0.00");
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            GetCartTotal();
            if (hascart) { btnClear.Enabled = true; btnSettle.Enabled = true; btnDiscount.Enabled = true; }
            else { btnClear.Enabled = false; btnSettle.Enabled = false; btnDiscount.Enabled = false; }
        }




        public void GetCartTotal()
        {
            double discount = double.Parse(lblDiscount.Text);
            double sales = double.Parse(lblSaleTotal.Text) - discount;
            double vat = sales * 0.12;// Податок: 12% Вихідний податок - вхідний податок
            double vatable = sales - vat;

            lblVat.Text = vat.ToString("#, ##0.00");
            lblVatable.Text = vatable.ToString("#, ##0.00");
            lblDisplayTotal.Text = sales.ToString("#, ##0.00");

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        public void GetbtnNTran()
        {
            try
            {
                string sdate = DateTime.Now.ToString("ddMMyyyy");
                int count;
                string transo;

                cn.Open();
                cm = new OleDbCommand("SELECT TOP 1 Transno FROM Cart WHERE Transno LIKE @sdate + '%' ORDER BY ID_Cart DESC", cn);
                cm.Parameters.AddWithValue("@sdate", sdate);
                OleDbDataReader dr = cm.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    transo = dr.GetString(0);
                    count = int.Parse(transo.Substring(8, 4));
                    lblTranNo.Text = sdate + (count + 1);
                }
                else
                {
                    transo = sdate + "1001";
                    lblTranNo.Text = transo;
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle);
            }

        }

        private void FormCashier_Load(object sender, EventArgs e)
        {
           
        }

        private void dgvCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCash.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
                if (MessageBox.Show("Видалити цей об'єкт?", "Видалити об'єкт", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                    {
                        string query = "DELETE FROM Cart WHERE ID_Cart LIKE '" + dgvCash.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Значення(об'єкти) були успішно видалені", "Видалити значення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCart();
                }
            }
            else if (colName == "colAdd") //У цьому коді значення параметра @Qty було замінено на фіксоване значення 1 у відповідних запитах UPDATE для збільшення або зменшення кількості.
            {
                int i = 0;
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT SUM(Qty) as Qty FROM Products WHERE PCode LIKE @PCode GROUP BY PCode", connection))
                    {
                        command.Parameters.AddWithValue("@PCode", dgvCash.Rows[e.RowIndex].Cells[2].Value.ToString());
                        connection.Open();
                        i = int.Parse(command.ExecuteScalar()?.ToString() ?? "0");
                    }
                }

                if (int.Parse(dgvCash.Rows[e.RowIndex].Cells[5].Value.ToString()) < i)
                {
                    using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                    {
                        using (OleDbCommand command = new OleDbCommand("UPDATE Cart SET Qty = Qty + 1 WHERE Transno LIKE @Transno AND Pcode LIKE @PCode", connection))
                        {
                            command.Parameters.AddWithValue("@Transno", lblTranNo.Text);
                            command.Parameters.AddWithValue("@PCode", dgvCash.Rows[e.RowIndex].Cells[2].Value.ToString());
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Залишок Qty на руках є " + i + "!", "Немає в наявності", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (colName == "colReduce")//У цьому коді значення параметра @Qty було замінено на фіксоване значення 1 у відповідних запитах UPDATE для збільшення або зменшення кількості.
            {
                int i = 0;
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    using (OleDbCommand command = new OleDbCommand("SELECT SUM(Qty) as Qty FROM Cart WHERE Pcode LIKE @PCode GROUP BY Pcode", connection))
                    {
                        command.Parameters.AddWithValue("@PCode", dgvCash.Rows[e.RowIndex].Cells[2].Value.ToString());
                        connection.Open();
                        i = int.Parse(command.ExecuteScalar()?.ToString() ?? "0");
                    }
                }

                if (i > 1)
                {
                    using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                    {
                        using (OleDbCommand command = new OleDbCommand("UPDATE Cart SET Qty = Qty - 1 WHERE Transno LIKE @Transno AND Pcode LIKE @PCode", connection))
                        {
                            command.Parameters.AddWithValue("@Transno", lblTranNo.Text);
                            command.Parameters.AddWithValue("@PCode", dgvCash.Rows[e.RowIndex].Cells[2].Value.ToString());
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Залишок Qty на руках є " + i + "!", "Немає в наявності", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void dgvCash_SelectionChanged(object sender, EventArgs e)
        {
            int i = dgvCash.CurrentRow.Index;

            if (dgvCash[1, i].Value != null)
            {
                id = dgvCash[1, i].Value.ToString();
            }

            if (dgvCash[7, i].Value != null)
            {
                price = dgvCash[7, i].Value.ToString();
            }
        }

        private void txtSearchTovarInCash_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchTovarInCash.Text;

            // Find rows that match the search keyword
            foreach (DataGridViewRow row in dgvCash.Rows)
            {
                string description = row.Cells["Column4"].Value.ToString(); // Replace "Description" with the actual column name
                if (description.Contains(searchKeyword))
                {
                    row.Selected = true;
                    dgvCash.CurrentCell = row.Cells["Column4"]; // Replace "Description" with the actual column name
                    dgvCash.FirstDisplayedScrollingRowIndex = row.Index;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }


        private void listBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxResults.SelectedIndex != -1)
            {
                string selectedResult = listBoxResults.SelectedItem.ToString();
                txtSearchTovarInCash.Text = selectedResult;
                listBoxResults.Visible = false;

                // Викличте метод пошуку товарів у корзині з використанням вибраного ключового слова
                LoadCartSearch();
            }
        }

        private void LoadCartSearch()
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT c.ID_Cart, c.Pcode, p.Description, c.Price, c.Qty, c.Disc, c.total 
                FROM Cart AS c 
                INNER JOIN Products AS p ON c.Pcode = p.PCode 
                WHERE c.Transno LIKE @Transno";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Transno", "%" + txtSearchTovarInCash.Text + "%");

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvCash.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void SetSearchTextBoxHint()
        {
            txtSearchTovarInCash.Text = "Пошук в корзині...";
            txtSearchTovarInCash.ForeColor = SystemColors.GrayText;
        }

        private void ClearSearchTextBoxHint()
        {
            txtSearchTovarInCash.Text = "";
            txtSearchTovarInCash.ForeColor = SystemColors.WindowText;
        }

        private void txtSearchTovarInCash_Enter(object sender, EventArgs e)
        {
            if (txtSearchTovarInCash.Text == "Пошук в корзині...")
            {
                ClearSearchTextBoxHint();
            }
        }

        private void txtSearchTovarInCash_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchTovarInCash.Text))
            {
                SetSearchTextBoxHint();
            }
        }
    }
}

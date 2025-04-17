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
    public partial class FormSettlePaymentcs : Form
    {

        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cm = new OleDbCommand();
        FormCashier cashier;

        public FormSettlePaymentcs(FormCashier cash)
        {
            InitializeComponent();
            cn = new OleDbConnection(ConnectionString);
            this.KeyPreview = true;
            cashier = cash;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnOne.Text;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnTwo.Text;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnThree.Text;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnFour.Text;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnFive.Text;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnSix.Text;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnSeven.Text;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnEight.Text;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnNine.Text;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnZero.Text;
        }

        private void btnDZero_Click(object sender, EventArgs e)
        {
            txtCash.Text += btnDZero.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCash.Clear();
            txtCash.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(txtChange.Text) < 0 || string.IsNullOrEmpty(txtCash.Text))
                {
                    MessageBox.Show("Неправильна сума, будь ласка введіть правильну суму!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                    {
                        connection.Open();

                        for (int i = 0; i < cashier.dgvCash.Rows.Count; i++)
                        {
                            int quantity = int.Parse(cashier.dgvCash.Rows[i].Cells[5].Value.ToString());
                            string productCode = cashier.dgvCash.Rows[i].Cells[2].Value.ToString();
                            string cartID = cashier.dgvCash.Rows[i].Cells[1].Value.ToString();

                            // Оновлення кількості товару в таблиці Products
                            using (OleDbCommand updateQtyCommand = new OleDbCommand("UPDATE Products SET Qty = Qty - @quantity WHERE PCode = @productCode", connection))
                            {
                                updateQtyCommand.Parameters.AddWithValue("@quantity", quantity);
                                updateQtyCommand.Parameters.AddWithValue("@productCode", productCode);
                                updateQtyCommand.ExecuteNonQuery();
                            }

                            // Оновлення статусу в таблиці Cart
                            using (OleDbCommand updateStatusCommand = new OleDbCommand("UPDATE Cart SET status = 'Продано' WHERE ID_Cart = @cartID", connection))
                            {
                                updateStatusCommand.Parameters.AddWithValue("@cartID", cartID);
                                updateStatusCommand.ExecuteNonQuery();
                            }
                        }

                        connection.Close();
                    }

                    MessageBox.Show("Оплата успішно збережена!", "Оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // cashier.GetTranNo();
                    cashier.GetbtnNTran(); // ПОМИЛКА
                    cashier.LoadCart();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e) //реагує на зміни в полі введення готівки,
                                                                     //обчислює різницю між готівкою та
                                                                     //загальною сумою продажу,
                                                                     //і відображає цю різницю в полі введення здачі.
        {
            try
            {
                double sale = double.Parse(txtSale.Text);
                double cash = double.Parse(txtCash.Text);
                double charge = cash - sale;
                txtChange.Text = charge.ToString("#,##0.00");
            }
            catch (Exception)
            {
                txtChange.Text = "0,00";
            }
        }

        private void FormSettlePaymentcs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Dispose();
            else if (e.KeyCode == Keys.Enter) btnEnter.PerformClick();
        }
    }
}

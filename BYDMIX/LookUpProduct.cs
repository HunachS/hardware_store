using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BYDMIX
{
    public partial class LookUpProduct : Form
    {
        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cm = new OleDbCommand();
        string stitle = "Точка Продажу";
        FormCashier cashier;

        public LookUpProduct(FormCashier cash)
        {
            InitializeComponent();
            cn = new OleDbConnection(ConnectionString);
            cashier = cash;
            LoadProducts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /*public void LoadProducts()
        {
            int i = 0;
            string searchKeyword = txtSearch.Text;


            cn.Open();
            string searchQuery = @"SELECT p.PCode, p.Barcode, p.Description, b.Brand, c.Category, p.Price, p.Qty 
                      FROM Products AS p, [Назва фірми] AS b, Типи AS c 
                      WHERE p.[Brand] = b.[КодФірми] 
                      AND p.[Category] = c.[КодТипа] 
                      AND (p.[Description] LIKE @search OR b.[Brand] LIKE @search OR c.[Category] LIKE @search)";

            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {

                using (OleDbCommand command = new OleDbCommand(searchQuery, cn))
                {
                    command.Parameters.AddWithValue("@search", "%" + searchKeyword + "%");
                    cn.Open();


                    using (OleDbDataReader dr = command.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            i++;
                            dgvBrand.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                        }
                    }
                }
            }


        }*/

        public void LoadProducts()
        {
            int i = 0;
            string searchKeyword = txtSearch.Text;
            dgvBrand.Rows.Clear();

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Встановити значення параметра @SearchTerm
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchKeyword + "%");

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        i++;
                        dgvBrand.Rows.Add(i, row["PCode"], row["Barcode"], row["Description"], row["Brand"], row["Category"], row["Price"], row["Qty"]);
                    }
                }
            }

        }

        private void dgvBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBrand.Columns[e.ColumnIndex].Name;
            if (colName == "SelectColumn")
            {
                FormAmountQTY qty = new FormAmountQTY(cashier);
                qty.ProductDetails(dgvBrand.Rows[e.RowIndex].Cells[1].Value.ToString(), int.Parse(dgvBrand.Rows[e.RowIndex].Cells[6].Value.ToString()), cashier.lblTranNo.Text, int.Parse(dgvBrand.Rows[e.RowIndex].Cells[7].Value.ToString()));
                qty.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text;

            // Find rows that match the search keyword
            foreach (DataGridViewRow row in dgvBrand.Rows)
            {
                string description = row.Cells["Column4"].Value.ToString(); // Replace "Description" with the actual column name
                if (description.Contains(searchKeyword))
                {
                    row.Selected = true;
                    dgvBrand.CurrentCell = row.Cells["Column4"]; // Replace "Description" with the actual column name
                    dgvBrand.FirstDisplayedScrollingRowIndex = row.Index;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        private void listBoxResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxResult.SelectedIndex != -1)
            {
                string selectedResult = listBoxResult.SelectedItem.ToString();
                txtSearch.Text = selectedResult;
                listBoxResult.Visible = false;

                // Викличте метод пошуку товарів у корзині з використанням вибраного ключового слова
                LoadProducts();
            }
        }
    }
}

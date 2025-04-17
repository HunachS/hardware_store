using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BYDMIX
{
    public partial class FormDailySale : Form
    {
        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";
        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cm = new OleDbCommand();

        public FormDailySale()
        {
            InitializeComponent();
            LoadCasheir();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadCasheir()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("Всі продавці");

            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                cn.Open();
                using (OleDbCommand cm = new OleDbCommand("SELECT * FROM Profile_Users WHERE Username LIKE 'Admin'", cn))
                {
                    using (OleDbDataReader reader = cm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cboCashier.Items.Add(reader["Username"].ToString());
                        }
                    }
                }
            }
        }

        public void LoadSold()
        {
            int i = 0;
            double total = 0;
            double discount = 0;
            dgvSold.Rows.Clear();

            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                cn.Open();

                string query;
                if (cboCashier.Text == "Всі продавці")
                {
                    query = @"SELECT c.ID_Cart, c.Transno, c.Pcode, p.Description, c.Price, c.Qty, c.Disc, c.total 
                      FROM Cart AS c 
                      INNER JOIN Products AS p ON c.Pcode = p.PCode 
                      WHERE status LIKE 'Продано' ";
                }
                else
                {
                    query = @"SELECT c.ID_Cart, c.Transno, c.Pcode, p.Description, c.Price, c.Qty, c.Disc, c.total 
                      FROM Cart AS c 
                      INNER JOIN Products AS p ON c.Pcode = p.PCode 
                      WHERE status LIKE 'Продано' AND sdate BETWEEN @FromDate AND @ToDate AND cashier LIKE @Cashier";
                }

                using (OleDbCommand cm = new OleDbCommand(query, cn))
                {
                    cm.Parameters.AddWithValue("@FromDate", dtFrom.Value);
                    cm.Parameters.AddWithValue("@ToDate", dtTo.Value.Date.AddDays(1).AddSeconds(-1));
                    cm.Parameters.AddWithValue("@Cashier", cboCashier.Text);

                    using (OleDbDataReader dr = cm.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            i++;
                            double price = Convert.ToDouble(dr["Price"]);
                            int qty = Convert.ToInt32(dr["Qty"]);
                            discount = Convert.ToDouble(dr["Disc"]);
                            double itemTotal = price * qty;

                            total += itemTotal - discount;
                            // total += itemTotal - discount;
                            dgvSold.Rows.Add(i, dr["ID_Cart"].ToString(), dr["Transno"].ToString(), dr["Pcode"].ToString(), dr["Description"].ToString(), dr["Price"].ToString(), dr["Qty"].ToString(), dr["Disc"].ToString(), itemTotal.ToString("#,##0.00"));
                        }
                    }
                }
                lblTotal.Text = total.ToString("#,##0.00");
            }
        }
        


        private void cboCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadSold();
        }

        private void FormDailySale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void dgvSold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSold.Columns[e.ColumnIndex].Name;

            if (colName == "Cancel")
            {
                if (MessageBox.Show("Відмінити проданий товар?", "Відмінити товар", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                    {
                        string query = "DELETE FROM Cart WHERE ID_Cart LIKE '" + dgvSold.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Товар було успішно відмінено", "Відмінити товар", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCasheir();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            double total = 0;
            double discount = 0;
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            // Заголовки стовпців
            worksheet.Cells[1, 4] = "BYDMIX";
            worksheet.Cells[2, 4] = "Продавець";
            worksheet.Cells[3, 3] = "DATE FROM";
            worksheet.Cells[4, 4] = "Щоденні продажі";
            worksheet.Cells[4, 7] = "Сума: ";

            worksheet.Cells[5, 1] = "ID_Cart";
            worksheet.Cells[5, 2] = "Transno";
            worksheet.Cells[5, 3] = "Pcode";
            worksheet.Cells[5, 4] = "Description";
            worksheet.Cells[5, 5] = "Price";
            worksheet.Cells[5, 6] = "Qty";
            worksheet.Cells[5, 7] = "Discount";
            worksheet.Cells[5, 8] = "Total";

            decimal totalPrice = 0;
            // Задати форматування для заголовків стовпців
            Excel.Range headerRange = worksheet.Range["A1:H5"];
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Отримання даних для звіту
            using (OleDbConnection cn = new OleDbConnection(ConnectionString))
            {
                
                cn.Open();
                string query;
                if (cboCashier.Text == "Всі продавці")
                {
                    query = @"SELECT c.ID_Cart, c.Transno, c.Pcode, p.Description, c.Price, c.Qty, c.Disc, c.total 
                      FROM Cart AS c 
                      INNER JOIN Products AS p ON c.Pcode = p.PCode 
                      WHERE status LIKE 'Продано' ";

                }
                else
                {

                    query = @"SELECT c.ID_Cart, c.Transno, c.Pcode, p.Description, c.Price, c.Qty, c.Disc, c.total 
                      FROM Cart AS c 
                      INNER JOIN Products AS p ON c.Pcode = p.PCode 
                      WHERE status LIKE 'Продано' AND sdate BETWEEN @FromDate AND @ToDate";
                }
                    

                using (OleDbCommand cm = new OleDbCommand(query, cn))
                {
                    cm.Parameters.AddWithValue("@FromDate", dtFrom.Value);
                    cm.Parameters.AddWithValue("@ToDate", dtTo.Value);

                    using (OleDbDataReader dr = cm.ExecuteReader())
                    {
                        int row = 6; // Початковий рядок для запису даних

                        while (dr.Read())
                        {
                            // Запис даних у відповідні стовпці
                            worksheet.Cells[row, 1] = dr["ID_Cart"].ToString();

                            worksheet.Cells[row, 2].NumberFormat = "0";
                            worksheet.Cells[row, 2] = dr["Transno"].ToString();

                            worksheet.Cells[row, 3] = dr["Pcode"].ToString();
                            worksheet.Cells[row, 4] = dr["Description"].ToString();
                            worksheet.Cells[row, 5] = dr["Price"].ToString();
                            worksheet.Cells[row, 6] = dr["Qty"].ToString();
                            worksheet.Cells[row, 7] = dr["Disc"].ToString();
                            worksheet.Cells[row, 8] = dr["total"].ToString();

                            
                            // Вирівнювання тексту по центру у кожній ячейці
                            worksheet.Range["A" + row, "H" + row].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            double price = Convert.ToDouble(dr["Price"]);
                            int qty = Convert.ToInt32(dr["Qty"]);
                            discount = Convert.ToDouble(dr["Disc"]);
                            double itemTotal = price * qty;

                            total += itemTotal - discount;
                            row++;
                        }
                    }
                }
                worksheet.Cells[4, 8] = lblTotal.Text = total.ToString("#,##0.00");
                // Задати ширину стовпців
                worksheet.Columns["B"].ColumnWidth = 15;
                worksheet.Columns["C"].ColumnWidth = 15;
                worksheet.Columns["D"].ColumnWidth = 30;
                // Додавання жирного шрифту до комірок
                worksheet.Range["A1:H5"].Font.Bold = true;
                // Вставлення дати створення звіту
                worksheet.Cells[3, 3] = "Дата створення:";
                worksheet.Cells[3, 4] = DateTime.Now.ToString("dd/MM/yyyy");
                // Збереження та закриття книги Excel
                workbook.SaveAs("D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX.xlsx");
                workbook.Close();
                excelApp.Quit();
            }

            // Звільнення ресурсів
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(excelApp);
            MessageBox.Show("Звіт збережено успішно.", "Успіх");

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Помилка при звільненні об'єкта: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }

    
}


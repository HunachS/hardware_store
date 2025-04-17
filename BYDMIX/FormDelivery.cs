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
using System.Drawing.Printing;

namespace BYDMIX
{
    public partial class FormDelivery : Form
    {

        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        public FormDelivery()
        {
            InitializeComponent();
        }

        private void btnRefreshLoadSuppliers_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Поставка";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewSuppliers.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void dataGridViewSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Перевірити, чи було натиснуто на ячейку стовпця "КодПостачальника"
            if (e.ColumnIndex == dataGridViewSuppliers.Columns["КодПоставщика"].Index && e.RowIndex >= 0)
            {
                // Отримати значення КодПостачальника з вибраної ячейки
                string supplierIdValue = dataGridViewSuppliers.Rows[e.RowIndex].Cells["КодПоставщика"].Value.ToString();

                // Викликати функцію відображення інформації про постачальника з передачею supplierId
                ShowSupplierInfo(supplierIdValue);
            }
        }

        private void ShowSupplierInfo(string supplierId)
        {
            // Отримати інформацію про постачальника за допомогою supplierId
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                string query = "SELECT * FROM Поставщики WHERE [Назва] = @SupplierNazva;";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SupplierNazva", supplierId);
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Отримати дані про постачальника
                            string supplierName = reader.GetString(reader.GetOrdinal("Назва"));
                            string supplierPredstav = reader.GetString(reader.GetOrdinal("Представництво"));
                            string supplierCountry = reader.GetString(reader.GetOrdinal("Країна"));
                            string supplierCity = reader.GetString(reader.GetOrdinal("Місто"));
                            string supplierAddress = reader.GetString(reader.GetOrdinal("Адрес"));
                            string supplierPhoneNum = reader.GetString(reader.GetOrdinal("Телефон"));

                            // Відображення інформації про постачальника
                            MessageBox.Show($"Назва: {supplierName}\nПредставництво: {supplierPredstav}\nКраїна: {supplierCountry}\nМісто: {supplierCity}\nАдрес: {supplierAddress}\nТелефон: {supplierPhoneNum}", "Інформація про постачальника");
                        }
                        else
                        {
                            MessageBox.Show("Постачальника не знайдено", "Помилка");
                        }
                    }
                }
            }

        }

        private void txtSearchDelivery_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchDelivery.Text;

            // Підключення до бази даних
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    // Відкриття з'єднання з базою даних
                    connection.Open();

                    // Формування запиту до бази даних
                    string query = "SELECT * FROM Поставка WHERE КодПоставщика LIKE @Keyword OR Прийняв LIKE @Keyword OR КодТовара LIKE @Keyword;";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Keyword", "%" + searchKeyword + "%");

                    // Виконання запиту до бази даних та отримання результатів
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                    // Відображення результатів у DataGridView
                    dataGridViewSuppliers.DataSource = dataTable;

                }
                catch (Exception ex)
                {
                    // Обробка винятку при з'єднанні з базою даних
                    MessageBox.Show("Помилка при з'єднанні з базою даних: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBoxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxResults.SelectedIndex != -1)
            {
                string selectedResult = listBoxResults.SelectedItem.ToString();
                txtSearchDelivery.Text = selectedResult;
                listBoxResults.Visible = false;


                // Оновіть DataGridView з результатами пошуку, використовуючи вибране ключове слово
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Поставка";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewSuppliers.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) //пошук по датам
        {
            // Отримати введені дати для пошуку
            DateTime fromDate = dateTimePickerFrom.Value.Date;
            DateTime toDate = dateTimePickerTo.Value.Date;

            // Пройтися по кожному рядку DataGridView і знайти ті, що відповідають введеним датам
            foreach (DataGridViewRow row in dataGridViewSuppliers.Rows)
            {
                // Отримати значення дати з відповідної комірки
                DateTime date = Convert.ToDateTime(row.Cells[6].Value);

                // Перевірити, чи дата потрапляє в діапазон
                if (date >= fromDate && date <= toDate)
                {
                    // Відобразити рядок, якщо він відповідає умовам пошуку
                    row.Visible = true;
                }
                else
                {
                    // Приховати рядок, якщо він не відповідає умовам пошуку
                    row.Visible = false;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Отримати вибраний рядок у DataGridView
            if (dataGridViewSuppliers.SelectedRows.Count > 0)
            {
                // Отримати дані товару з вибраного рядка
                string deliveryPostavshchuk = dataGridViewSuppliers.SelectedRows[0].Cells["КодПоставщика"].Value.ToString();
                string deliveryTovar = dataGridViewSuppliers.SelectedRows[0].Cells["КодТовара"].Value.ToString();
                string deliveryAmountTovar = dataGridViewSuppliers.SelectedRows[0].Cells["КількістьТовара"].Value.ToString();
                decimal deliveryPricePostavku = Convert.ToDecimal(dataGridViewSuppliers.SelectedRows[0].Cells["ЦінаПоставки"].Value);
                string deliveryPruiniav = dataGridViewSuppliers.SelectedRows[0].Cells["Прийняв"].Value.ToString();


                // Передати дані товару до форми редагування
                FormEditDelivery editForm = new FormEditDelivery(deliveryPostavshchuk, deliveryTovar, deliveryAmountTovar, deliveryPricePostavku, deliveryPruiniav);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Оновити дані товару в DataGridView
                    dataGridViewSuppliers.SelectedRows[0].Cells["КодПоставщика"].Value = editForm.DeliveryPostavshchuk;
                    dataGridViewSuppliers.SelectedRows[0].Cells["КодТовара"].Value = editForm.DeliveryTovar;
                    dataGridViewSuppliers.SelectedRows[0].Cells["КількістьТовара"].Value = editForm.DeliveryAmountTovar;
                    dataGridViewSuppliers.SelectedRows[0].Cells["ЦінаПоставки"].Value = editForm.DeliveryPricePostavku;
                    dataGridViewSuppliers.SelectedRows[0].Cells["Прийняв"].Value = editForm.DeliveryPruiniav;
                }
                
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть поставку для редагування.");
            }
        }

        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            new FormAddDelivery().Show();
        }

        private void btnDeleteDeliv_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Ви дійсно бажаєте видалити цю поставку(накладку)?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int selectedRowIndex = dataGridViewSuppliers.SelectedRows[0].Index;
                    int deliveryId = Convert.ToInt32(dataGridViewSuppliers.Rows[selectedRowIndex].Cells["КодПоставки"].Value);

                    using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                    {
                        try
                        {
                            connection.Open();

                            string query = "DELETE FROM Поставка WHERE КодПоставки = @DeliveryId";
                            OleDbCommand command = new OleDbCommand(query, connection);
                            command.Parameters.AddWithValue("@DeliveryId", deliveryId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Поставка(накладна) успішно видалений.");
                                LoadProducts(); // Оновити дані клієнтів в dataGridViewClients
                            }
                            else
                            {
                                MessageBox.Show("Помилка видалення товара.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Виберіть поставку(накладку), яку бажаєте видалити.");
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count > 0)
            {
                // Отримати дані товару з вибраного рядка
                string deliveryPostavshchuk = dataGridViewSuppliers.SelectedRows[0].Cells["КодПоставщика"].Value.ToString();
                string deliveryTovar = dataGridViewSuppliers.SelectedRows[0].Cells["КодТовара"].Value.ToString();
                string deliveryAmountTovar = dataGridViewSuppliers.SelectedRows[0].Cells["КількістьТовара"].Value.ToString();
                decimal deliveryPricePostavku = Convert.ToDecimal(dataGridViewSuppliers.SelectedRows[0].Cells["ЦінаПоставки"].Value);
                string deliveryPruiniav = dataGridViewSuppliers.SelectedRows[0].Cells["Прийняв"].Value.ToString();

                // Створити об'єкт класу PrintDocument
                PrintDocument printDocument = new PrintDocument();

                // Налаштувати параметри друку
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom", 300, 400); // Задати розмір сторінки
                printDocument.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50); // Задати поля
                printDocument.DefaultPageSettings.Landscape = true; // Режим альбомної орієнтації

                // Визначити обробник події PrintPage для малювання даних друку
                printDocument.PrintPage += (s, args) =>
                {
                    Graphics graphics = args.Graphics;
                    int startX = 50;
                    int startY = 50;
                    int offset = 30;
                    int lineHeight = 20;

                    // Малювати заголовок накладної
                    SizeF textSize = graphics.MeasureString("Накладна", new Font("Arial", 16, FontStyle.Bold));
                    float textX = startX + (printDocument.DefaultPageSettings.PrintableArea.Width - textSize.Width) / 2;
                    graphics.DrawString("Накладна", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, textX, startY);
                    startY += offset;


                    // Малювати дані друку
                    graphics.DrawString("Поставщик: " + deliveryPostavshchuk, new Font("Arial", 12), Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("Назва Товара: " + deliveryTovar, new Font("Arial", 12), Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("Кількість: " + deliveryAmountTovar, new Font("Arial", 12), Brushes.Black, startX, startY);
                    startY += offset;
                    graphics.DrawString("Ціна товару: " + deliveryPricePostavku.ToString("C"), new Font("Arial", 12), Brushes.Black, textX, startY + offset);
                    graphics.DrawString("Прийняв накладну: " + deliveryPruiniav, new Font("Arial", 12), Brushes.Black, startX, startY);
                    startY += offset;

                    // Якщо є більше даних для друку, встановити HasMorePages на true
                    // і викликати подію PrintPage ще раз для наступної сторінки
                    args.HasMorePages = false;
                };

                // Викликати метод Print для початку друку
                
                PrintDialog printDialog = new PrintDialog();
                printDocument.PrinterSettings = printDialog.PrinterSettings;
                
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                    printPreviewDialog.Document = printDocument;
                    printPreviewDialog.ShowDialog();
                    printDocument.Print();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть накладну для друку.");
            }
        }

        private void dataGridViewSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

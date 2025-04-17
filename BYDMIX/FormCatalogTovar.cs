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
    public partial class FormCatalogTovar : Form
    {
        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        public FormCatalogTovar()
        {
            InitializeComponent();

            txtSearchTovar.TextChanged += txtSearchTovar_TextChanged;

        }

        private void dataGridViewCatalogTovar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FormCatalogTovar_Load(object sender, EventArgs e)
        {
            string query = "SELECT КодТовара, [Назва товара], КодПоставщика, КодТипа, КодФірми, ЦінаПродажу, Наявність FROM Товари";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewCatalogTovar.DataSource = dataTable;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Товари";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewCatalogTovar.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void btnAddTovar_Click(object sender, EventArgs e)
        {
            new FormAddTovar().Show();
        }

        private void btnDeleteTovar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCatalogTovar.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Ви дійсно бажаєте видалити цей товар?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int selectedRowIndex = dataGridViewCatalogTovar.SelectedRows[0].Index;
                    int productId = Convert.ToInt32(dataGridViewCatalogTovar.Rows[selectedRowIndex].Cells["КодТовара"].Value);

                    using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                    {
                        try
                        {
                            connection.Open();

                            string query = "DELETE FROM Товари WHERE КодТовара = @ProductId";
                            OleDbCommand command = new OleDbCommand(query, connection);
                            command.Parameters.AddWithValue("@ProductId", productId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Товар успішно видалений.");
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
                MessageBox.Show("Виберіть товар, який бажаєте видалити.");
            }

        }

        private void LoadProducts()
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Товари";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewCatalogTovar.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void txtSearchTovar_Enter(object sender, EventArgs e)
        {
            if (txtSearchTovar.Text == "Введіть текст пошуку...")
            {
                txtSearchTovar.Text = "";
            }
        }

        private void txtSearchTovar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchTovar.Text))
            {
                txtSearchTovar.Text = "Введіть текст пошуку...";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchTovar.Text;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Товари WHERE [Назва товара] LIKE @Keyword OR КодПоставщика LIKE @Keyword OR КодТипа LIKE @Keyword;";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Keyword", "%" + searchKeyword + "%");
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewCatalogTovar.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void txtSearchTovar_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchTovar.Text;

            // Підключення до бази даних
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    // Відкриття з'єднання з базою даних
                    connection.Open();

                    // Формування запиту до бази даних
                    string query = "SELECT * FROM Товари WHERE [Назва товара] LIKE @Keyword OR КодПоставщика LIKE @Keyword OR КодТипа LIKE @Keyword;";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Keyword", "%" + searchKeyword + "%");

                    // Виконання запиту до бази даних та отримання результатів
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    

                    // Відображення результатів у DataGridView
                    dataGridViewCatalogTovar.DataSource = dataTable;

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
                txtSearchTovar.Text = selectedResult;
                listBoxResults.Visible = false;


                // Оновіть DataGridView з результатами пошуку, використовуючи вибране ключове слово
                LoadProducts();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            // Отримати вибраний рядок у DataGridView
            if (dataGridViewCatalogTovar.SelectedRows.Count > 0)
            {
                // Отримати дані товару з вибраного рядка
                string tovarName = dataGridViewCatalogTovar.SelectedRows[0].Cells["Назва товара"].Value.ToString();
                string tovarPostavshchuk = dataGridViewCatalogTovar.SelectedRows[0].Cells["КодПоставщика"].Value.ToString();
                string tovarTup = dataGridViewCatalogTovar.SelectedRows[0].Cells["КодТипа"].Value.ToString();
                string tovarFirma = dataGridViewCatalogTovar.SelectedRows[0].Cells["КодФірми"].Value.ToString();
                decimal tovarPrice = Convert.ToDecimal(dataGridViewCatalogTovar.SelectedRows[0].Cells["ЦінаПродажу"].Value);
                // Інші поля товару

                // Передати дані товару до форми редагування
                FormEditTovar editForm = new FormEditTovar(tovarName, tovarPostavshchuk, tovarTup, tovarFirma, tovarPrice);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Оновити дані товару в DataGridView
                    dataGridViewCatalogTovar.SelectedRows[0].Cells["Назва товара"].Value = editForm.TovarName;
                    dataGridViewCatalogTovar.SelectedRows[0].Cells["КодПоставщика"].Value = editForm.TovarPostavshchuk;
                    dataGridViewCatalogTovar.SelectedRows[0].Cells["КодТипа"].Value = editForm.TovarTup;
                    dataGridViewCatalogTovar.SelectedRows[0].Cells["КодФірми"].Value = editForm.TovarFirma;
                    dataGridViewCatalogTovar.SelectedRows[0].Cells["ЦінаПродажу"].Value = editForm.TovarPrice;
                    // Оновити інші поля товару

                    // Зберегти зміни до бази даних
                    
                }
                else
                {
                    MessageBox.Show("Будь ласка, виберіть товар для редагування.");
                }

            }
        }
    }
}

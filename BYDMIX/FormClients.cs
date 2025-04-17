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
    public partial class FormClients : Form
    {

        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        public FormClients()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Клієнти";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewClients.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Клієнти WHERE [Ім'я] LIKE @Keyword OR [Прізвище] LIKE @Keyword OR [Адрес] LIKE @Keyword";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Keyword", "%" + searchKeyword + "%");
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewClients.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormAddDeleteClientcs().Show();
            //this.Hide();
        }

        private void LoadClients()
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM Клієнти";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewClients.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Ви дійсно бажаєте видалити цього клієнта?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int selectedRowIndex = dataGridViewClients.SelectedRows[0].Index;
                    int clientId = Convert.ToInt32(dataGridViewClients.Rows[selectedRowIndex].Cells["КодКлієнта"].Value);

                    using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                    {
                        try
                        {
                            connection.Open();

                            string query = "DELETE FROM Клієнти WHERE КодКлієнта = @ClientId";
                            OleDbCommand command = new OleDbCommand(query, connection);
                            command.Parameters.AddWithValue("@ClientId", clientId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Клієнт успішно видалений.");
                                LoadClients(); // Оновити дані клієнтів в dataGridViewClients
                            }
                            else
                            {
                                MessageBox.Show("Помилка видалення клієнта.");
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
                MessageBox.Show("Виберіть клієнта, якого бажаєте видалити.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();//використання методу Close() може спричинити завершення роботи програми,
                         //якщо це єдиний активний екземпляр форми.
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Введіть текст пошуку...")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Введіть текст пошуку...";
            }
        }
    }
}

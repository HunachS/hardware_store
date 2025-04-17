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
    public partial class FormAddTovar : Form
    {
        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        public FormAddTovar()
        {
            InitializeComponent();
        }

        private void btnAddTovar_Click(object sender, EventArgs e)
        {
            
            string tovarName = textBox1.Text;
            string tovarPostavshchuk = textBox2.Text;
            string tovarTup = textBox3.Text;
            string tovarFirma = textBox4.Text;
            string tovarPrice = textBox5.Text;
            bool tovarNaiavnist = checkBox1.Checked;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Товари ([Назва товара], КодПоставщика, КодТипа, КодФірми, ЦінаПродажу, [Наявність]) VALUES (@tovarName, @tovarPostavshchuk, @tovarTup, @tovarFirma, @tovarPrice, @tovarNaiavnist)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@tovarName", tovarName);
                    command.Parameters.AddWithValue("@tovarPostavshchuk", tovarPostavshchuk);
                    command.Parameters.AddWithValue("@tovarTup", tovarTup);
                    command.Parameters.AddWithValue("@tovarFirma", tovarFirma);
                    command.Parameters.AddWithValue("@tovarPrice", tovarPrice);
                    command.Parameters.AddWithValue("@tovarNaiavnist", tovarNaiavnist);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Товар успішно доданий до бази даних.");

                    // Очищення полів для введення даних після додавання клієнта
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    checkBox1.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void btnCleanTovar_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            checkBox1.Checked = false;
            textBox1.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

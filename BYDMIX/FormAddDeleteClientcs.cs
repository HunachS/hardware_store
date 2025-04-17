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
    public partial class FormAddDeleteClientcs : Form
    {

        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        public FormAddDeleteClientcs()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string clientName = textBox1.Text;
            string clientSurname = textBox2.Text;
            string clientPoBatkovi = textBox3.Text;
            string clientAddress = textBox4.Text;
            string clientPhoneNumer = textBox5.Text;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Клієнти ([Ім'я], [Прізвище], [По батькові], [Адрес], [Телефон]) VALUES (@clientName, @clientSurname, @clientPoBatkovi, @clientAddress, @clientPhoneNumer)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@clientName", clientName);
                    command.Parameters.AddWithValue("@clientSurname", clientSurname);
                    command.Parameters.AddWithValue("@clientPoBatkovi", clientPoBatkovi);
                    command.Parameters.AddWithValue("@clientAddress", clientAddress);
                    command.Parameters.AddWithValue("@clientPhoneNumer", clientPhoneNumer);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Клієнт успішно доданий до бази даних.");

                    // Очищення полів для введення даних після додавання клієнта
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox5.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка підключення до бази даних: " + ex.Message);
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;//Якщо вам потрібно тільки приховати форму і показати її знову пізніше,
                                 //використовуйте властивість Visible.
        }
    }
}

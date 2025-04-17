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

    public partial class FormAddDelivery : Form
    {
        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        public FormAddDelivery()
        {
            InitializeComponent();
        }

        private void buttonAddDelivery_Click(object sender, EventArgs e)
        {
            string deliveryPostavshchuk = textBox1.Text;
            string deliveryTovar = textBox2.Text;
            string deliveryAmountTovar = textBox3.Text;
            string deliveryPricePostavku = textBox5.Text;
            string deliveryPruiniav = textBox4.Text;
            DateTime deliverySelectedDate = dateTimePicker1.Value;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO Поставка (КодПоставщика, КодТовара, КількістьТовара, ЦінаПоставки, Прийняв, [Дата поставки]) VALUES (@deliveryPostavshchuk, @deliveryTovar, @deliveryAmountTovar, @deliveryPricePostavku, @deliveryPruiniav, @deliverySelectedDate)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@deliveryPostavshchuk", deliveryPostavshchuk);
                    command.Parameters.AddWithValue("@deliveryTovar", deliveryTovar);
                    command.Parameters.AddWithValue("@deliveryAmountTovar", deliveryAmountTovar);
                    command.Parameters.AddWithValue("@deliveryPricePostavku", deliveryPricePostavku);
                    command.Parameters.AddWithValue("@deliveryPruiniav", deliveryPruiniav);
                    command.Parameters.AddWithValue("@deliverySelectedDate", deliverySelectedDate);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Поставка (накладна) успішно додана до бази даних.");

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

        private void btnCleanDeliv_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox1.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYDMIX
{
    public partial class FormEditDelivery : Form
    {
        // public int ProductId { get; set; }
        public string DeliveryPostavshchuk { get; set; }
        public string DeliveryTovar { get; set; }
        public string DeliveryAmountTovar { get; set; }
        public decimal DeliveryPricePostavku { get; set; }
        public string DeliveryPruiniav { get; set; }

        

        public FormEditDelivery(string postavshchuk, string tovar, string amountTovar, decimal pricePostavku, string pruiniav)
        {
            InitializeComponent();

            DeliveryPostavshchuk = postavshchuk;
            DeliveryTovar = tovar;
            DeliveryAmountTovar = amountTovar;
            DeliveryPricePostavku = pricePostavku;
            DeliveryPruiniav = postavshchuk;
            

            textBox1.Text = postavshchuk;
            textBox2.Text = tovar;
            textBox3.Text = amountTovar;
            textBox5.Text = pricePostavku.ToString();
            textBox4.Text = pruiniav;
            

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Отримати та перевірити значення з полів форми
            string newDeliveryPostavshchuk = textBox1.Text.Trim();
            string newDeliveryTovar = textBox2.Text.Trim();
            string newDeliveryAmountTovar = textBox3.Text.Trim();
            decimal newPricePostavku;
            string newDeliveryPruiniav = textBox4.Text.Trim();
            

            if (!decimal.TryParse(textBox5.Text.Trim(), out newPricePostavku))
            {
                MessageBox.Show("Неправильний формат ціни поставки.");
                return;
            }

            // Зберегти нові значення
            DeliveryPostavshchuk = newDeliveryPostavshchuk;
            DeliveryTovar = newDeliveryTovar;
            DeliveryAmountTovar = newDeliveryAmountTovar;
            DeliveryPricePostavku = newPricePostavku;
            DeliveryPruiniav = newDeliveryPruiniav;
            

            // Закрити форму з результатом DialogResult.OK
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

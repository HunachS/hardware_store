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
    public partial class FormEditTovar : Form
    {
       // public int ProductId { get; set; }
        public string TovarName { get; set; }
        public string TovarPostavshchuk { get; set; }
        public string TovarTup { get; set; }
        public string TovarFirma { get; set; }

        public decimal TovarPrice { get; set; }

        public FormEditTovar(string name, string postavshchuk, string tup, string firma, decimal price)
        {
            InitializeComponent();

            TovarName = name;
            TovarPostavshchuk = postavshchuk;
            TovarTup = tup;
            TovarFirma = firma;
            TovarPrice = price;

            textBox1.Text = name;
            textBox2.Text = postavshchuk;
            textBox3.Text = tup;
            textBox4.Text = firma;
            textBox5.Text = price.ToString();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Отримати та перевірити значення з полів форми
            string newProductName = textBox1.Text.Trim();
            string newProductPostavshchuk = textBox2.Text.Trim();
            string newProductTup = textBox3.Text.Trim();
            string newProductFirma = textBox4.Text.Trim();
            decimal newProductPrice;

            if (!decimal.TryParse(textBox5.Text.Trim(), out newProductPrice))
            {
                MessageBox.Show("Неправильний формат ціни товару.");
                return;
            }

            // Зберегти нові значення
            TovarName = newProductName;
            TovarPostavshchuk = newProductPostavshchuk;
            TovarTup = newProductTup;
            TovarFirma = newProductFirma;
            TovarPrice = newProductPrice;

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

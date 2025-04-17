using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYDMIX
{
    public partial class FormDiscount : Form
    {
        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cm = new OleDbCommand();
        OleDbDataReader dr;
        string stitle = "Точка Продажі";
        FormCashier cashier;

        public FormDiscount(FormCashier cash)
        {
            InitializeComponent();
            cn = new OleDbConnection(ConnectionString);
            cashier = cash;
            txtDiscount.Focus();
            this.KeyPreview = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FormDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Dispose();
            else if (e.KeyCode == Keys.Enter) btnClose.PerformClick();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double disc = double.Parse(txtTotalPrice.Text) * double.Parse(txtDiscount.Text) * 0.01;
                txtDisAmount.Text = disc.ToString("#,##0.00");
            }
            catch (Exception)
            {
                txtDisAmount.Text = "0.00";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Додати знижку? Натисніть 'Підтвердити'", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();

                    // Оновлення поля Disc
                    cm = new OleDbCommand("UPDATE Cart SET Disc = @Disc WHERE ID_Cart = @ID_Cart", cn);
                    cm.Parameters.AddWithValue("@Disc", txtDisAmount.Text);
                    cm.Parameters.AddWithValue("@ID_Cart", int.Parse(lbld.Text));
                    cm.ExecuteNonQuery();

                    // Оновлення поля Disc_percent
                    cm = new OleDbCommand("UPDATE Cart SET Disc_percent = @Disc_percent WHERE ID_Cart = @ID_Cart", cn);
                    cm.Parameters.AddWithValue("@Disc_percent", 0.1);
                    cm.Parameters.AddWithValue("@ID_Cart", int.Parse(lbld.Text));
                    cm.ExecuteNonQuery();

                    cn.Close();

                    // Оновлення відображення даних у DataGridView
                    cashier.LoadCart();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle);
            }
        }
    }
}

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
    public partial class FormLogin : Form
    {

        /*public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";*/

        public FormLogin()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = " SELECT * FROM Profile_Users WHERE Username= '" + txtUsername.Text + "' and Password= '" + txtPassword.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильний пароль або ім'я користувача, Будь ласка спробуйте знову", "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();

            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

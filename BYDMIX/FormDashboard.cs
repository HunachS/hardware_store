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
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new FormClients().Show();
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormStaff formStaff = new FormStaff();
            formStaff.button5_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormStaff formStaff = new FormStaff();
            formStaff.button6_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormStaff formStaff = new FormStaff();
            formStaff.button3_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormStaff formStaff = new FormStaff();
            formStaff.button2_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FormCashier().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}

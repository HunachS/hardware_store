using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace BYDMIX
{
    public partial class Form1 : Form
    {
        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse);

        public Form1()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

            /*pnlNavIndicator.Height = btnGolovna.Height;
            pnlNavIndicator.Top = btnGolovna.Top;
            pnlNavIndicator.Left = btnGolovna.Left;
            ButtonColorReset(btnGolovna);

            lblTabTitle.Text = "Головна";
            this.pnlContent.Controls.Clear();
            FormDashboard FrmDashboard = new FormDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlContent.Controls.Add(FrmDashboard);
            FrmDashboard.Show();*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ButtonColorReset (Button button)
        {
            Color activeColor = Color.FromArgb(31, 27, 48);
            Color btnColor = Color.FromArgb(26, 23, 40);
            btnGolovna.BackColor = btnColor;
            btnCategoria.BackColor = btnColor;
            btnKasa.BackColor = btnColor;
            btnRyhTovara.BackColor = btnColor;
            btnProNas.BackColor = btnColor;
            button.BackColor = activeColor;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            pnlNavIndicator.Height = btnCategoria.Height;
            pnlNavIndicator.Top = btnCategoria.Top;
            pnlNavIndicator.Left = btnCategoria.Left;
            ButtonColorReset(btnCategoria);

            lblTabTitle.Text = "Каталог товарів";
            this.pnlContent.Controls.Clear();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Visible = false;

        }

        private void btnProNas_Click(object sender, EventArgs e)
        {
            pnlNavIndicator.Height = btnProNas.Height;
            pnlNavIndicator.Top = btnProNas.Top;
            pnlNavIndicator.Left = btnProNas.Left;
            ButtonColorReset(btnProNas);

            lblTabTitle.Text = "Про нас";
            this.pnlContent.Controls.Clear();
            FormStaff FrmStaff = new FormStaff() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlContent.Controls.Add(FrmStaff);
            FrmStaff.Show();
        }

        private void btnGolovna_Click(object sender, EventArgs e)
        {
            pnlNavIndicator.Height = btnGolovna.Height;
            pnlNavIndicator.Top = btnGolovna.Top;
            pnlNavIndicator.Left = btnGolovna.Left;
            ButtonColorReset(btnGolovna);

            lblTabTitle.Text = "Головна";
            this.pnlContent.Controls.Clear();
            FormDashboard FrmDashboard = new FormDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlContent.Controls.Add(FrmDashboard);
            FrmDashboard.Show();

        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            
            pnlNavIndicator.Height = btnCategoria.Height;
            pnlNavIndicator.Top = btnCategoria.Top;
            pnlNavIndicator.Left = btnCategoria.Left;
            ButtonColorReset(btnCategoria);

            lblTabTitle.Text = "Каталог товарів";
            this.pnlContent.Controls.Clear();
            FormCatalogTovar FrmCatalogTovar = new FormCatalogTovar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlContent.Controls.Add(FrmCatalogTovar);
            FrmCatalogTovar.Show();

        }

        private void btnRyhTovara_Click(object sender, EventArgs e)
        {
            pnlNavIndicator.Height = btnRyhTovara.Height;
            pnlNavIndicator.Top = btnRyhTovara.Top;
            pnlNavIndicator.Left = btnRyhTovara.Left;
            ButtonColorReset(btnRyhTovara);

            lblTabTitle.Text = "Поставка(накладні)";
            this.pnlContent.Controls.Clear();
            FormDelivery FrmCatalogTovar = new FormDelivery() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlContent.Controls.Add(FrmCatalogTovar);
            FrmCatalogTovar.Show(); 
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            new FormCashier().Show();
        }

        /* private void label1_Click(object sender, EventArgs e)
         {

         }*/


    }
}

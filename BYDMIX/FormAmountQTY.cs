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
    public partial class FormAmountQTY : Form
    {

        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        OleDbConnection cn = new OleDbConnection();
        OleDbCommand cm = new OleDbCommand();
        private string pcode;
        private int price;
        private string transno;
        private int qty;
        private double total;
        FormCashier cashier;

        public FormAmountQTY(FormCashier cash)
        {
            InitializeComponent();
            cn = new OleDbConnection(ConnectionString);
            cashier = cash;
        }

        public void ProductDetails(string pcode, int price, string transno, int qty)
        {
            this.pcode = pcode;
            this.price = price;
            this.transno = transno;
            this.qty = qty;
        }
        

        private void FormAmountQTY_Load(object sender, EventArgs e)
        {

        }

        private void FormAmountQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtQty.Text))
            {
                using (OleDbConnection cn = new OleDbConnection(ConnectionString))
                {
                    cn.Open();
                    string query = "INSERT INTO Cart (Transno, Pcode, Price, Qty, sdate, cashier) " +
                                   "VALUES (@Transno, @Pcode, @Price, @Qty, @sdate, @cashier)";
                    using (OleDbCommand cm = new OleDbCommand(query, cn))
                    {
                        cm.Parameters.AddWithValue("@Transno", transno);
                        cm.Parameters.AddWithValue("@Pcode", pcode);
                        cm.Parameters.AddWithValue("@Price", price);
                        cm.Parameters.AddWithValue("@Qty", int.Parse(txtQty.Text)); 
                        cm.Parameters.Add("@sdate", OleDbType.VarChar).Value = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                        cm.Parameters.Add("@cashier", OleDbType.VarChar).Value = cashier.lblUsername.Text;
                        cm.ExecuteNonQuery();
                    }
                }
                //total = price * qty;
                cashier.LoadCart();
                //cashier.LoadCart(total);
                this.Dispose();
            }
        }

        /*public double SaleTotal
        {
            get { return saleTotal; }
            set { saleTotal = value; }
        }*/
    }
}

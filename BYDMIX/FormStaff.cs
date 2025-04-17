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

    public partial class FormStaff : Form
    {
        public string ConnectionString =
        "Provider=Microsoft.ACE.OLEDB.12.0;" +
        "Data Source= D:\\Visual studio\\Bakalavrska_robota_BYDMIX_2023\\BYDMIX\\BYDMIX\\DIY_store_db.accdb";

        public FormStaff()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int employeeId = 1; 

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                string query = "SELECT * FROM Співробітники WHERE КодСпівробітника = @EmployeeId;";
                

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string staffSername = reader.GetString(1);
                            string staffName = reader.GetString(2);
                            string staffPosition = reader.GetString(3);
                            string staffPhoneNumber = reader.GetString(4);
                            // Інші поля співробітника

                            // Відображення інформації про співробітника
                            string employeeInfo = $"Прізвище: {staffSername}\nІм'я: {staffName}\nПосада: {staffPosition}\nНомер телефону: {staffPhoneNumber}\n";
                            ShowCustomMessageBox(employeeInfo, "Інформація про персонал", Color.FromArgb(26, 23, 45));
                        }
                        else
                        {
                            ShowCustomMessageBox("Співробітника не знайдено", "Error", Color.FromArgb(26, 23, 45));
                        }
                    }
                }
            }
            
        }

        private void ShowCustomMessageBox(string message, string caption, Color backgroundColor)
        {
            Form messageForm = new Form();
            messageForm.FormBorderStyle = FormBorderStyle.None;
            messageForm.StartPosition = FormStartPosition.CenterScreen;
            messageForm.Size = new Size(300, 200);

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(35, 60);
            lblMessage.ForeColor = Color.FromArgb(199, 198, 205);
            lblMessage.Font = new Font("Arial", 11, FontStyle.Regular);
            messageForm.Controls.Add(lblMessage);

            Label lblCaption = new Label();
            lblCaption.Text = caption;
            lblCaption.AutoSize = true;
            lblCaption.Location = new Point(13, 15);
            lblCaption.ForeColor = Color.FromArgb(199, 198, 205);
            lblCaption.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            messageForm.Controls.Add(lblCaption);

            messageForm.BackColor = backgroundColor;

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            btnOK.ForeColor = Color.SlateBlue;
            btnOK.FlatAppearance.BorderSize = 1;
            btnOK.Size = new Size(50, 30);
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(120, 155);
            messageForm.Controls.Add(btnOK);

            messageForm.ShowDialog();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            int employeeId = 2;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                string query = "SELECT * FROM Співробітники WHERE КодСпівробітника = @EmployeeId;";


                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string staffSername = reader.GetString(1);
                            string staffName = reader.GetString(2);
                            string staffPosition = reader.GetString(3);
                            string staffPhoneNumber = reader.GetString(4);
                            // Інші поля співробітника

                            // Відображення інформації про співробітника
                            string employeeInfo = $"Прізвище: {staffSername}\nІм'я: {staffName}\nПосада: {staffPosition}\nНомер телефону: {staffPhoneNumber}\n";
                            ShowCustomMessageBox(employeeInfo, "Інформація про персонал", Color.FromArgb(26, 23, 45));
                        }
                        else
                        {
                            ShowCustomMessageBox("Співробітника не знайдено", "Error", Color.FromArgb(26, 23, 45));
                        }
                    }
                }
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            int employeeId = 3;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                string query = "SELECT * FROM Співробітники WHERE КодСпівробітника = @EmployeeId;";


                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string staffSername = reader.GetString(1);
                            string staffName = reader.GetString(2);
                            string staffPosition = reader.GetString(3);
                            string staffPhoneNumber = reader.GetString(4);
                            // Інші поля співробітника

                            // Відображення інформації про співробітника
                            string employeeInfo = $"Прізвище: {staffSername}\nІм'я: {staffName}\nПосада: {staffPosition}\nНомер телефону: {staffPhoneNumber}\n";
                            ShowCustomMessageBox(employeeInfo, "Інформація про персонал", Color.FromArgb(26, 23, 45));
                        }
                        else
                        {
                            ShowCustomMessageBox("Співробітника не знайдено", "Error", Color.FromArgb(26, 23, 45));
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int employeeId = 4;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                string query = "SELECT * FROM Співробітники WHERE КодСпівробітника = @EmployeeId;";


                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string staffSername = reader.GetString(1);
                            string staffName = reader.GetString(2);
                            string staffPosition = reader.GetString(3);
                            string staffPhoneNumber = reader.GetString(4);
                            // Інші поля співробітника

                            // Відображення інформації про співробітника
                            string employeeInfo = $"Прізвище: {staffSername}\nІм'я: {staffName}\nПосада: {staffPosition}\nНомер телефону: {staffPhoneNumber}\n";
                            ShowCustomMessageBox(employeeInfo, "Інформація про персонал", Color.FromArgb(26, 23, 45));
                        }
                        else
                        {
                            ShowCustomMessageBox("Співробітника не знайдено", "Error", Color.FromArgb(26, 23, 45));
                        }
                    }
                }
            }
        }

        public void button5_Click(object sender, EventArgs e)
        {
            int employeeId = 5;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                string query = "SELECT * FROM Співробітники WHERE КодСпівробітника = @EmployeeId;";


                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string staffSername = reader.GetString(1);
                            string staffName = reader.GetString(2);
                            string staffPosition = reader.GetString(3);
                            string staffPhoneNumber = reader.GetString(4);
                            // Інші поля співробітника

                            // Відображення інформації про співробітника
                            string employeeInfo = $"Прізвище: {staffSername}\nІм'я: {staffName}\nПосада: {staffPosition}\nНомер телефону: {staffPhoneNumber}\n";
                            ShowCustomMessageBox(employeeInfo, "Інформація про персонал", Color.FromArgb(26, 23, 45));
                        }
                        else
                        {
                            ShowCustomMessageBox("Співробітника не знайдено", "Error", Color.FromArgb(26, 23, 45));
                        }
                    }
                }
            }
        }

        public void button6_Click(object sender, EventArgs e)
        {
            int employeeId = 6;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                string query = "SELECT * FROM Співробітники WHERE КодСпівробітника = @EmployeeId;";


                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string staffSername = reader.GetString(1);
                            string staffName = reader.GetString(2);
                            string staffPosition = reader.GetString(3);
                            string staffPhoneNumber = reader.GetString(4);
                            // Інші поля співробітника

                            // Відображення інформації про співробітника
                            string employeeInfo = $"Прізвище: {staffSername}\nІм'я: {staffName}\nПосада: {staffPosition}\nНомер телефону: {staffPhoneNumber}\n";
                            ShowCustomMessageBox(employeeInfo, "Інформація про персонал", Color.FromArgb(26, 23, 45));
                        }
                        else
                        {
                            ShowCustomMessageBox("Співробітника не знайдено", "Error", Color.FromArgb(26, 23, 45));
                        }
                    }
                }
            }
        }
    }
}

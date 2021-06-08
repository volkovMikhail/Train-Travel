using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Train_Travel.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Train_Travel.Forms
{
    public partial class Login : Form
    {
        SqlConnection conn;
        
        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Registration reg = new Registration();
            reg.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userId = -1;
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE phone = @num", conn);
                cmd.Parameters.Add("@num", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                dataReader = cmd.ExecuteReader();
                int role = -1;
                string pw = string.Empty;
                bool active = false;
                if (dataReader.Read())
                {
                    userId = Convert.ToInt32(dataReader[0]);
                    role = Convert.ToInt32(dataReader[7]);
                    pw = Convert.ToString(dataReader[6]);
                    active = Convert.ToBoolean(dataReader[8]);
                }

                if (active)
                {
                    if (pw == textBox1.Text)
                    {
                        if (userId == -1 || role == -1)
                        {
                            MessageBox.Show("Неверные данные", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (role == 0)
                        {
                            mainUser mainUser = new mainUser(userId);
                            this.Hide();
                            mainUser.ShowDialog();
                            this.Show();
                        }
                        else if (role == 1)
                        {
                            MainAdmin mainAdmin = new MainAdmin();
                            this.Hide();
                            mainAdmin.ShowDialog();
                            this.Show();
                        }
                        else if (role == 2)
                        {
                            Admin admin = new Admin();
                            this.Hide();
                            admin.ShowDialog();
                            this.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверные данные", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ваш аккаунт не активен","Info",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                conn.Close();

            }
        }
    }
}

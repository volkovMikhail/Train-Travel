using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Train_Travel.Forms
{
    public partial class addPlace : Form
    {
        SqlConnection conn;
        public addPlace()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Places VALUES(@p)", conn);
                    cmd.Parameters.Add("@p", SqlDbType.NVarChar).Value = textBox1.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Дополните данные", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

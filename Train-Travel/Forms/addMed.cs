using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train_Travel.Forms
{
    public partial class addMed : Form
    {
        SqlConnection conn;
        public addMed()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            
        }

        int workerid;
        private void button1_Click(object sender, EventArgs e)
        {
            pickWorker pickWorker = new pickWorker();
            pickWorker.ShowDialog();
            workerid = pickWorker.workerID;
            SqlCommand cmd = new SqlCommand($"SELECT * from workers where id={pickWorker.workerID}", conn);
            SqlDataReader dataReader = null;
            if (workerid > 0)
            {
                try
                {
                    conn.Open();
                    dataReader = cmd.ExecuteReader();
                    dataReader.Read();

                    labelWorker.Text = $"{Convert.ToString(dataReader[3])} {Convert.ToString(dataReader[4])} {Convert.ToString(dataReader[5])}";

                    GC.Collect();
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

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (workerid > 0)
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO Med values({workerid},'{dateTimePicker1.Value.Year}-{dateTimePicker1.Value.Month}-{dateTimePicker1.Value.Day}')", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }

                this.Close();
            }
        }
    }
}

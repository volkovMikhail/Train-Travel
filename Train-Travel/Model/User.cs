using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Train_Travel.Model
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int role { get; set; }
        public bool active { get; set; }

        public User()
        {
            this.id = -1;
            this.name = string.Empty;
            this.lastName = string.Empty;
            this.middleName = string.Empty;
            this.phone = string.Empty;
            this.email = string.Empty;
            this.role = -1;
            this.active = false;
        }

        public User(int id)
        {
            this.id = -1;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Users WHERE id = {id}", conn);
                dataReader = cmd.ExecuteReader();
                dataReader.Read();
                this.id = Convert.ToInt32(dataReader[0]);
                this.name = Convert.ToString(dataReader[1]);
                this.lastName = Convert.ToString(dataReader[2]);
                this.middleName = Convert.ToString(dataReader[3]);
                this.phone = Convert.ToString(dataReader[4]);
                this.email = Convert.ToString(dataReader[5]);
                this.role = Convert.ToInt32(dataReader[7]);
                this.active = Convert.ToBoolean(dataReader[8]);
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

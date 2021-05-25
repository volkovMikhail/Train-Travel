using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Train_Travel.Model
{
    public class Voyage
    {
        public int id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int count { get; set; }
        public float price { get; set; }
        public string type { get; set; }

        public Voyage()
        {
            this.id = -1;
            this.from = string.Empty;
            this.to = string.Empty;
            this.startDate = DateTime.Now;
            this.endDate = DateTime.Now;
            this.count = -1;
            this.price = -1;
            this.type = string.Empty;
        }

        public Voyage(int id)
        {
            this.id = -1;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Voyage WHERE id = {id}", conn);
                dataReader = cmd.ExecuteReader();
                dataReader.Read();
                this.id = Convert.ToInt32(dataReader[0]);
                this.from = Convert.ToString(dataReader[1]);
                this.to = Convert.ToString(dataReader[2]);
                this.startDate = Convert.ToDateTime(dataReader[3]);
                this.endDate = Convert.ToDateTime(dataReader[4]);
                this.count = Convert.ToInt32(dataReader[5]);
                this.price = Convert.ToSingle(dataReader[6]);
                this.type = Convert.ToString(dataReader[7]);
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

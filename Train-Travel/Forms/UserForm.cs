using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Train_Travel.Model;
using System.Data.SqlClient;
using System.Configuration;

namespace Train_Travel.Forms
{
    public partial class UserForm : Form
    {
        User user;
        SqlConnection conn;
        public UserForm(int id)
        {
            InitializeComponent();
            user = new User(id);
            this.Text = $"{user.name} {user.lastName} {user.middleName}";
            labelEmail.Text = user.email;
            labelFam.Text = user.lastName;
            labelMiddle.Text = user.middleName;
            labelPhone.Text = user.phone;
            labelId.Text = user.id.ToString();
            labelname.Text = user.name;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }

        private void User_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Orders INNER JOIN Voyage ON Orders.VoyageId = Voyage.Id WHERE Orders.UserId = {user.id}", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewOrders.Items.Clear();
                dataReader = cmd.ExecuteReader();
                List<int> idToDelete = new List<int>();
                ListViewItem viewItem;
                float sum = 0;
                while (dataReader.Read())
                {
                    if (Convert.ToDateTime(dataReader[9]) > DateTime.Now)
                    {
                        viewItem = new ListViewItem(new string[]
                        {
                            Convert.ToString(dataReader[5]),
                            Convert.ToString(dataReader[6]),
                            Convert.ToString(dataReader[12]),
                            Convert.ToDateTime(dataReader[7]).ToShortDateString(),
                            Convert.ToString(dataReader[8]),
                            Convert.ToDateTime(dataReader[9]).ToString(),
                            Convert.ToString(dataReader[11]),
                            Convert.ToString(dataReader[3])
                        });
                        viewItem.Tag = dataReader[0];
                        listViewOrders.Items.Add(viewItem);
                        sum += Convert.ToSingle(dataReader[11]);
                    }
                    else
                    {
                        idToDelete.Add(Convert.ToInt32(dataReader[0]));
                    }
                }
                dataReader.Close();
                foreach (int id in idToDelete)
                {
                    cmd = new SqlCommand($"DELETE FROM Orders WHERE id = {id}", conn);
                    cmd.ExecuteNonQuery();
                }
                labelSum.Text = sum.ToString();
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
}

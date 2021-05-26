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
using Train_Travel.Utils;

namespace Train_Travel
{
    public partial class mainUser : Form
    {
        User user;
        SqlConnection conn;
        public mainUser(int userId)
        {
            InitializeComponent();
            user = new User(userId);
        }
        private void mainUser_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT fromPlace,toPlace FROM Voyage", conn);
            SqlDataReader dataReader = null;
            listViewVoyages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            comboBoxFrom.Items.Add("Все");
            comboBoxTo.Items.Add("Все");
            try
            {
                conn.Open();
                listViewVoyages.Items.Clear();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxFrom.Items.Add(Convert.ToString(dataReader[0]));
                    comboBoxTo.Items.Add(Convert.ToString(dataReader[1]));
                }
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
            comboBoxFrom.SelectedIndex = 0;
            comboBoxTo.SelectedIndex = 0;
            dateTimePickerStartDate.Enabled = false;
            dateTimePickerStartDate.Value = DateTime.Now;
        }

        private void outputFromVoyages()
        {
            queryParams queryParams;
            queryParams.DateSearch = checkBox1.Checked;
            queryParams.from = Convert.ToString(comboBoxFrom.SelectedItem);
            queryParams.to = Convert.ToString(comboBoxTo.SelectedItem);
            queryParams.startDate = dateTimePickerStartDate.Value;
            queryParams.startPrice = textBoxStartPrice.Text;
            queryParams.endPrice = textBoxEndPrice.Text;
            
            SqlCommand cmd = new SqlCommand(QueryBuilder.query(queryParams),conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewVoyages.Items.Clear();
                dataReader = cmd.ExecuteReader();
                ListViewItem viewItem;
                while (dataReader.Read())
                {
                    viewItem = new ListViewItem(new string[]
                    {
                        Convert.ToString(dataReader[1]),
                        Convert.ToString(dataReader[2]),
                        Convert.ToString(dataReader[8]),
                        Convert.ToString(dataReader[3]),
                        Convert.ToString(dataReader[4]),
                        Convert.ToString(dataReader[5]),
                        Convert.ToString(dataReader[6]),
                        Convert.ToString(dataReader[7])
                    });
                    listViewVoyages.Items.Add(viewItem);
                }
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

        private void textBoxEndPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBoxStartPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerStartDate.Enabled = !dateTimePickerStartDate.Enabled;
            outputFromVoyages();
        }

        private void comboBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputFromVoyages();
        }

        private void comboBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputFromVoyages();
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            outputFromVoyages();
        }

        private void textBoxStartPrice_TextChanged(object sender, EventArgs e)
        {
            outputFromVoyages();
        }

        private void textBoxEndPrice_TextChanged(object sender, EventArgs e)
        {
            outputFromVoyages();
        }
    }
}

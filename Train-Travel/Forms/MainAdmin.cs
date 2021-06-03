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

namespace Train_Travel.Forms
{
    public partial class MainAdmin : Form
    {
        User user;
        SqlConnection conn;
        public MainAdmin(int userId)
        {
            InitializeComponent();
            user = new User(userId);
        }

        private void MainAdmin_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            listViewVoyages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            outputToCombo();
            dateTimePickerStartDate.Enabled = false;
            dateTimePickerStartDate.Value = DateTime.Now;
        }

        private void outputToCombo()
        {
            comboBoxFrom.Items.Clear();
            comboBoxTo.Items.Clear();
            comboBoxFrom.Items.Add("Все");
            comboBoxTo.Items.Add("Все");
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT fromPlace,toPlace FROM Voyage", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
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
                comboBoxFrom.SelectedIndex = 0;
                comboBoxTo.SelectedIndex = 0;
            }
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

            SqlCommand cmd = new SqlCommand(QueryBuilder.query(queryParams), conn);
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
                        Convert.ToDateTime(dataReader[3]).ToShortDateString(),
                        Convert.ToString(dataReader[4]),
                        Convert.ToDateTime(dataReader[5]).ToString(),
                        Convert.ToString(dataReader[6]),
                        Convert.ToString(dataReader[7])
                    });
                    viewItem.Tag = dataReader[0];
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerStartDate.Enabled = !dateTimePickerStartDate.Enabled;
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

        private void button1_Click(object sender, EventArgs e)
        {
            addRoute addRoute = new addRoute();
            addRoute.ShowDialog();
            outputToCombo();
            outputFromVoyages();
        }

        private void textBoxStartPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBoxEndPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void удалитьРейсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewVoyages.SelectedIndices.Count > 0)
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM Voyage WHERE Id = {Convert.ToInt32(listViewVoyages.SelectedItems[0].Tag)}", conn);
                try
                {
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
                    outputFromVoyages();
                    outputToCombo();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали рейс", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listViewVoyages.SelectedItems.Clear();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

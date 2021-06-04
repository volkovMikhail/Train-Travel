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
            labelId.Text = user.id.ToString();
            labelname.Text = user.name;
            labelFam.Text = user.lastName;
            labelMiddle.Text = user.middleName;
            labelEmail.Text = user.email;
            labelPhone.Text = user.phone;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT fromPlace,toPlace FROM Voyage", conn);
            SqlDataReader dataReader = null;
            listViewVoyages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewOrders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            comboBoxFrom.Items.Add("Все");
            comboBoxTo.Items.Add("Все");
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

            }
            comboBoxFrom.SelectedIndex = 0;
            comboBoxTo.SelectedIndex = 0;
            dateTimePickerStartDate.Enabled = false;
            dateTimePickerStartDate.Value = DateTime.Now;
            outputFromVoyages();
            outputOrders();
        }

        private void outputOrders()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Orders INNER JOIN Voyage ON Orders.VoyageId = Voyage.Id WHERE Orders.UserId = {user.id}", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewOrders.Items.Clear();
                dataReader = cmd.ExecuteReader();
                ListViewItem viewItem;
                float sum = 0;
                while (dataReader.Read())
                {
                    viewItem = new ListViewItem(new string[]
                    {
                        Convert.ToString(dataReader[5]),
                        Convert.ToString(dataReader[6]),
                        Convert.ToString(dataReader[12]),
                        Convert.ToDateTime(dataReader[7]).ToShortDateString(),
                        Convert.ToString(dataReader[8]),
                        Convert.ToDateTime(dataReader[9]).ToShortDateString(),
                        Convert.ToString(dataReader[11]),
                        Convert.ToString(dataReader[3])
                    });
                    viewItem.Tag = dataReader[0];
                    listViewOrders.Items.Add(viewItem);
                    sum += Convert.ToSingle(dataReader[11]);
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

        private void купитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewVoyages.SelectedIndices.Count > 0)
            {
                if (Convert.ToInt32(listViewVoyages.SelectedItems[0].SubItems[6].Text) > 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Orders VALUES(@UserId,@VoyageId,@date)", conn);
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = user.id;
                    cmd.Parameters.Add("@VoyageId", SqlDbType.Int).Value = Convert.ToInt32(listViewVoyages.SelectedItems[0].Tag);
                    cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand($"UPDATE Voyage SET count = count - 1, sell = sell + 1 WHERE Id = {Convert.ToInt32(listViewVoyages.SelectedItems[0].Tag)}", conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Билет добавлен в личный кабинет", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                        outputOrders();
                        outputFromVoyages();
                    }
                }
                else
                {
                    MessageBox.Show("Билеты кончились", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали рейс","Info",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            listViewVoyages.SelectedItems.Clear();
        }

        private void вернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedIndices.Count > 0)
            {

                SqlCommand cmd = new SqlCommand($"SELECT * FROM Orders WHERE Id = {Convert.ToInt32(listViewOrders.SelectedItems[0].Tag)}", conn);
                SqlDataReader dataReader = null;
                try
                {
                    conn.Open();
                    dataReader = cmd.ExecuteReader();
                    dataReader.Read();
                    object id = dataReader[0], Vid = dataReader[2];
                    if (dataReader != null && !dataReader.IsClosed)
                    {
                        dataReader.Close();
                    }
                    cmd = new SqlCommand($"UPDATE Voyage SET count = count + 1, sell = sell - 1 WHERE Id = {Convert.ToInt32(Vid)}", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand($"DELETE FROM Orders WHERE Id = {Convert.ToInt32(id)}",conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Вы вернули билет", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    outputOrders();
                    outputFromVoyages();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали билет", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listViewOrders.SelectedItems.Clear();
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO печать
        }
    }
}

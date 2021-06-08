using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Train_Travel.Forms
{
    public partial class Admin : Form
    {
        SqlConnection conn;
        string filter;
        public Admin()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            filter = "> -1";
            outputUsers();
        }

        private void перейтиВМенюАдминистратораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainAdmin mainAdmin = new MainAdmin();
            mainAdmin.ShowDialog();
            this.Show();
        }

        private void outputUsers()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Users WHERE role {filter}", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewUsers.Items.Clear();
                dataReader = cmd.ExecuteReader();
                ListViewItem viewItem;
                while (dataReader.Read())
                {
                    if (Convert.ToInt32(dataReader[7]) != 2)
                    {
                        string status, role;
                        if (Convert.ToInt32(dataReader[7]) == 0)
                        {
                            role = "Пассажир";
                        }
                        else
                        {
                            role = "Администратор";
                        }
                        if (Convert.ToBoolean(dataReader[8]))
                        {
                            status = "Активирован";
                        }
                        else
                        {
                            status = "Не активирован";
                        }
                        viewItem = new ListViewItem(new string[]
                        {
                            Convert.ToString(dataReader[0]),
                            Convert.ToString(dataReader[1]),
                            Convert.ToString(dataReader[2]),
                            Convert.ToString(dataReader[3]),
                            Convert.ToString(dataReader[4]),
                            Convert.ToString(dataReader[5]),
                            role,
                            status
                        });
                        viewItem.Tag = dataReader[0];
                        listViewUsers.Items.Add(viewItem);
                    }
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

        private void активироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedIndices.Count > 0)
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Users SET active = 1 WHERE id = {Convert.ToInt32(listViewUsers.SelectedItems[0].Tag)}", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    listViewUsers.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                    outputUsers();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали рейс", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void деактивироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedIndices.Count > 0)
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Users SET active = 0 WHERE id = {Convert.ToInt32(listViewUsers.SelectedItems[0].Tag)}", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    listViewUsers.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                    outputUsers();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали рейс", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedIndices.Count > 0)
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM Users WHERE id = {Convert.ToInt32(listViewUsers.SelectedItems[0].Tag)}", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    listViewUsers.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                    outputUsers();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали рейс", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void толькоАдминистраторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (толькоАдминистраторыToolStripMenuItem.Checked)
            {
                filter = "= 1";
            }
            else
            {
                filter = "> -1";
            }
            outputUsers();
        }
    }
}

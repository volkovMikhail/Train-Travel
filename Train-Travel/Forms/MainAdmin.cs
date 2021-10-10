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
        SqlConnection conn;
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void MainAdmin_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            outputToCombo();
            dateTimePickerStartDate.Enabled = false;
            dateTimePickerStartDate.Value = DateTime.Now;
            updateComboBrigades();
            outputWorkers();
            updateComboPlaces();
            outputTrains();
            outputUsers();
            outputMed();
        }

        private void outputUsers()
        {
            userParams userParams;
            userParams.email = textBoxUserEmail.Text;
            userParams.phone = maskedTextBoxUserPhone.Text;
            userParams.id = textBoxId.Text;
            SqlCommand cmd = new SqlCommand(QueryBuilder.users(userParams), conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewUsers.Items.Clear();
                dataReader = cmd.ExecuteReader();
                ListViewItem viewItem;
                while (dataReader.Read())
                {
                    if (0 == Convert.ToInt32(dataReader[7]))
                    {
                        viewItem = new ListViewItem(new string[]
                        {
                            Convert.ToString(dataReader[0]),
                            Convert.ToString(dataReader[1]),
                            Convert.ToString(dataReader[2]),
                            Convert.ToString(dataReader[3]),
                            Convert.ToString(dataReader[4]),
                            Convert.ToString(dataReader[5])
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

        private void updateComboPlaces()
        {
            comboBoxConnPlace.Items.Clear();
            comboBoxConnPlace.Items.Add("Все");

            SqlCommand cmd = new SqlCommand("SELECT * FROM Places", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxConnPlace.Items.Add(Convert.ToString(dataReader[0]));
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
                comboBoxConnPlace.SelectedIndex = 0;
            }
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
            queryParams.sell = checkBoxDontSell.Checked;

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
                        Convert.ToString(dataReader[7]),
                        Convert.ToString(dataReader[9])
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

        private void outputWorkers()
        {
            workersParams workersParams;
            workersParams.otdel = Convert.ToString(comboBoxOtdel.SelectedItem);
            workersParams.brigada = Convert.ToString(comboBoxBrigades.SelectedItem);
            workersParams.phone = maskedTextBoxPhoneSearchWorker.Text;
            SqlCommand cmd = new SqlCommand(QueryBuilder.workers(workersParams), conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewWorkers.Items.Clear();
                dataReader = cmd.ExecuteReader();
                ListViewItem viewItem;
                int count = 0;
                double sumZp = 0;
                while (dataReader.Read())
                {
                    string type;
                    if (Convert.ToBoolean(dataReader[8]))
                    {
                        type = "Рудоводитель";
                    }
                    else
                    {
                        type = "Работник";
                    }
                    viewItem = new ListViewItem(new string[]
                    {
                        Convert.ToString(dataReader[1]),
                        Convert.ToString(dataReader[2]),
                        Convert.ToString(dataReader[3]),
                        Convert.ToString(dataReader[4]),
                        Convert.ToString(dataReader[5]),
                        Convert.ToString(dataReader[6]),
                        Convert.ToString(dataReader[7]),
                        type,
                    });
                    viewItem.Tag = dataReader[0];
                    listViewWorkers.Items.Add(viewItem);
                    count++;
                    sumZp += Convert.ToDouble(dataReader[7]);
                }
                if (sumZp != 0 && count != 0)
                {
                    labelZP.Text = (sumZp / count).ToString();
                }
                else
                {
                    labelZP.Text = 0.ToString();
                }
                labelQueryCount.Text = count.ToString();
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

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e) // delete worker
        {
            if (listViewWorkers.SelectedIndices.Count > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM Workers WHERE Id = {Convert.ToInt32(listViewWorkers.SelectedItems[0].Tag)}", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали работника", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listViewWorkers.SelectedItems.Clear();
            outputWorkers();
        }

        private void buttonAddWorker_Click(object sender, EventArgs e)
        {
            addWorker addWorker = new addWorker();
            addWorker.ShowDialog();
            outputWorkers();
        }

        private void updateComboBrigades()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Brigades", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                comboBoxBrigades.Items.Clear();
                comboBoxBrigades.Items.Add("Все");
                comboBoxTrainBrigade.Items.Clear();
                comboBoxTrainBrigade.Items.Add("Все");
                comboBoxRepairBrigade.Items.Clear();
                comboBoxRepairBrigade.Items.Add("Все");
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxBrigades.Items.Add(Convert.ToString(dataReader[0]));
                    comboBoxTrainBrigade.Items.Add(Convert.ToString(dataReader[0]));
                    comboBoxRepairBrigade.Items.Add(Convert.ToString(dataReader[0]));
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
            comboBoxOtdel.SelectedIndex = 0;
            comboBoxBrigades.SelectedIndex = 0;
            comboBoxTrainBrigade.SelectedIndex = 0;
            comboBoxRepairBrigade.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addBrigade addBrigade = new addBrigade();
            addBrigade.ShowDialog();
            updateComboBrigades();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (listViewWorkers.SelectedIndices.Count > 0)
            {
                addWorker addWorker = new addWorker(Convert.ToInt32(listViewWorkers.SelectedItems[0].Tag));
                addWorker.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали работника", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listViewWorkers.SelectedItems.Clear();
            outputWorkers();
            outputMed();
        }

        private void comboBoxOtdel_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputWorkers();
        }

        private void comboBoxBrigades_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputWorkers();
        }

        private void maskedTextBoxPhoneSearchWorker_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            outputWorkers();
        }

        private void checkBoxMed_CheckedChanged(object sender, EventArgs e)
        {
            outputWorkers();
        }

        private void maskedTextBoxPhoneSearchWorker_TextChanged(object sender, EventArgs e)
        {
            outputWorkers();
        }

        private void buttonAddTrain_Click(object sender, EventArgs e)
        {
            addTrain addTrain = new addTrain();
            addTrain.ShowDialog();
            outputTrains();
        }

        private void outputTrains()
        {
            trainsParams trainsParams;
            trainsParams.brigade = Convert.ToString(comboBoxTrainBrigade.SelectedItem);
            trainsParams.repBrigade = Convert.ToString(comboBoxRepairBrigade.SelectedItem);
            trainsParams.id = textBoxTrainId.Text;
            trainsParams.place = Convert.ToString(comboBoxConnPlace.SelectedItem);
            
            SqlCommand cmd = new SqlCommand(QueryBuilder.trains(trainsParams), conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewTrains.Items.Clear();
                dataReader = cmd.ExecuteReader();
                ListViewItem viewItem;
                int count = 0;
                while (dataReader.Read())
                {
                    viewItem = new ListViewItem(new string[]
                    {
                        Convert.ToString(dataReader[0]),
                        Convert.ToString(dataReader[1]),
                        Convert.ToString(dataReader[2]),
                        Convert.ToString(dataReader[3]),
                        Convert.ToString(dataReader[4]),
                        Convert.ToString(dataReader[5]),
                        Convert.ToString(dataReader[6]),
                        Convert.ToString(dataReader[7])
                    });
                    viewItem.Tag = dataReader[0];
                    listViewTrains.Items.Add(viewItem);
                    count++;
                }
                labelCountTrains.Text = count.ToString();
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

        private void textBoxTrainId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !Char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputTrains();
        }

        private void textBoxTrainId_TextChanged(object sender, EventArgs e)
        {
            outputTrains();
        }

        private void comboBoxTrainBrigade_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputTrains();
        }

        private void comboBoxRepairBrigade_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputTrains();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addPlace addPlace = new addPlace();
            addPlace.ShowDialog();
            updateComboPlaces();
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listViewTrains.SelectedIndices.Count > 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM Trains WHERE Id = {Convert.ToInt32(listViewTrains.SelectedItems[0].Tag)}", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали локоматив", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listViewTrains.SelectedItems.Clear();
            outputTrains();
        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listViewTrains.SelectedIndices.Count > 0)
            {
                addTrain addTrain = new addTrain(Convert.ToInt32(listViewTrains.SelectedItems[0].Tag));
                addTrain.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали локоматив", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listViewTrains.SelectedItems.Clear();
            outputTrains();
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !Char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBoxUserPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            outputUsers();
        }

        private void textBoxUserEmail_TextChanged(object sender, EventArgs e)
        {
            outputUsers();
        }

        private void maskedTextBoxUserPhone_TextChanged(object sender, EventArgs e)
        {
            outputUsers();
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            outputUsers();
        }

        private void listViewUsers_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0)
            {
                UserForm userForm = new UserForm(Convert.ToInt32(listViewUsers.SelectedItems[0].Tag));
                userForm.ShowDialog();
            }
            listViewUsers.SelectedItems.Clear();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            outputFromVoyages();
        }

        private void outputMed()
        {
            medParams med;
            med.date = dateTimePickerMed.Value;
            med.onYear = checkBoxOnYear.Checked;
            med.whoHaveNot = checkBoxOnYearWhoHaveNot.Checked;
            med.phone = maskedTextBoxMed.Text;

            SqlCommand cmd = new SqlCommand(QueryBuilder.med(med), conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewMed.Items.Clear();
                dataReader = cmd.ExecuteReader();
                ListViewItem viewItem;
                int count = 0;
                if (checkBoxOnYearWhoHaveNot.Checked)
                {
                    List<string[]> list = new List<string[]>();

                    while (dataReader.Read())
                    {
                        list.Add(new string[]
                        {
                            Convert.ToString(dataReader[0]) == "" ? "-" : Convert.ToString(dataReader[0]),

                            $"{Convert.ToString(dataReader[1])} {Convert.ToString(dataReader[2])} {Convert.ToString(dataReader[3])}",
                            Convert.ToString(dataReader[4]),
                            (Convert.ToString(dataReader[5])+" -").Split(new char[]{' '})[0],
                            dataReader[6].ToString()
                        });
                    }
                    List<string[]> much = list.FindAll(e=>(e[3]+".-.-.-").Split(new char[]{'.'})[2]==dateTimePickerMed.Value.Year.ToString());
                    foreach (var item in much)
                    {
                        list.RemoveAll(e => item[4] == e[4]);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i][0] = "-";
                        list[i][3] = "-";
                        list[i][4] = "-";
                    }

                    List<string[]> copy = list.ToList();

                    for (int i = 0; i < copy.Count; i++)
                    {
                        List<int> ids = new List<int>();
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (list[j][2] == copy[i][2])
                            {
                                ids.Add(j);
                            }
                        }
                        if (ids.Count > 1)
                        {
                            foreach (var item in ids)
                            {
                                list.RemoveAt(item);
                            }
                        }
                    }

                    foreach (var item in list)
                    {
                        viewItem = new ListViewItem(item);
                        viewItem.Tag = item[item.Length-1];
                        listViewMed.Items.Add(viewItem);
                        count++;
                    }
                }
                else
                {
                    while (dataReader.Read())
                    {
                        viewItem = new ListViewItem(new string[]
                        {
                        Convert.ToString(dataReader[0]) == "" ? "-" : Convert.ToString(dataReader[0]),

                        $"{Convert.ToString(dataReader[1])} {Convert.ToString(dataReader[2])} {Convert.ToString(dataReader[3])}",
                        Convert.ToString(dataReader[4]),
                        (Convert.ToString(dataReader[5])+" . . ").Split(new char[]{' '})[0]
                        });
                        viewItem.Tag = dataReader[6];
                        listViewMed.Items.Add(viewItem);
                        count++;
                    }
                }
                Medcount.Text = count.ToString();
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

        private void checkBoxOnYear_CheckedChanged(object sender, EventArgs e)
        {
            outputMed();
            dateTimePickerMed.Enabled = !dateTimePickerMed.Enabled;
        }

        private void checkBoxOnYearWhoHaveNot_CheckedChanged(object sender, EventArgs e)
        {
            outputMed();
        }

        private void dateTimePickerMed_ValueChanged(object sender, EventArgs e)
        {
            outputMed();
        }

        private void maskedTextBoxMed_TextChanged(object sender, EventArgs e)
        {
            outputMed();
        }

        private void splitContainer5_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            addMed addMed = new addMed();
            addMed.ShowDialog();
            outputMed();
        }

        private void listViewMed_Click(object sender, EventArgs e)
        {

        }

        private void редактироватьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listViewMed.SelectedIndices.Count > 0)
            {
                string id = listViewMed.SelectedItems[0].Tag.ToString();
                
                addWorker addWorker = new addWorker(Convert.ToInt32(id));
                addWorker.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали запись", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                listViewMed.SelectedItems.Clear();
                outputWorkers();
                outputMed();
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewMed.SelectedIndices.Count > 0)
            {
                try
                {
                    string id = listViewMed.SelectedItems[0].SubItems[0].Text;
                    
                    if (id == "-")
                    {
                        return;
                    }
                    SqlCommand cmd = new SqlCommand($"DELETE FROM Med WHERE Id = {id}", conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали запись", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listViewMed.SelectedItems.Clear();
            outputMed();
        }
    }
}

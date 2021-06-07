﻿using System;
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
            updateComboBrigades();
            outputWorkers();
            updateComboPlaces();
            outputTrains();
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
            workersParams.med = checkBoxMed.Checked;
            workersParams.phone = maskedTextBoxPhoneSearchWorker.Text;
            SqlCommand cmd = new SqlCommand(QueryBuilder.workers(workersParams), conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewWorkers.Items.Clear();
                dataReader = cmd.ExecuteReader();
                ListViewItem viewItem;
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
                        Convert.ToDateTime(dataReader[9]).ToShortDateString(),
                    });
                    viewItem.Tag = dataReader[0];
                    listViewWorkers.Items.Add(viewItem);
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
                MessageBox.Show("Вы не выбрали билет", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Вы не выбрали билет", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            listViewWorkers.SelectedItems.Clear();
            outputWorkers();
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Train_Travel.Forms
{
    public partial class addTrain : Form
    {
        SqlConnection conn;
        bool isEditMode;
        int id;
        public addTrain()
        {
            InitializeComponent();
            isEditMode = false;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }

        public addTrain(int id)
        {
            InitializeComponent();
            this.id = id;
            isEditMode = true;
            button1.Text = "Изменить";
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }

        private void addTrain_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Brigades", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                comboBoxBrigades.Items.Clear();
                comboBoxRepairBrigade.Items.Clear();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxRepairBrigade.Items.Add(Convert.ToString(dataReader[0]));
                    comboBoxBrigades.Items.Add(Convert.ToString(dataReader[0]));
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
            outputPlaces();
            cmd = new SqlCommand($"SELECT * FROM Trains WHERE id = {id}",conn);
            dataReader = null;
            try
            {
                conn.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxType.SelectedItem = Convert.ToString(dataReader[1]);
                    textBoxQuantity.Text = Convert.ToString(dataReader[2]);
                    textBoxCompleted.Text = Convert.ToString(dataReader[3]);
                    textBoxRepairs.Text = Convert.ToString(dataReader[4]);
                    comboBoxPlace.SelectedItem = Convert.ToString(dataReader[5]);
                    comboBoxBrigades.SelectedItem = Convert.ToString(dataReader[6]);
                    comboBoxRepairBrigade.SelectedItem = Convert.ToString(dataReader[7]);
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
        }

        private void outputPlaces()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Places", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                comboBoxPlace.Items.Clear();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxPlace.Items.Add(Convert.ToString(dataReader[0]));
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
        }

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !Char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void textBoxCompleted_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !Char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void textBoxRepairs_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !Char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command;
            if (isEditMode)
            {
                command = $"UPDATE Trains SET type = @type, quantity = @quantity, completed = @completed, repairs = @repairs, connectToPlace = @ctp, brigade = @brigade, repairBrigade = @repairBrigade WHERE Id = {id}";
            }
            else
            {
                command = "INSERT INTO Trains VALUES(@type,@quantity,@completed,@repairs,@ctp,@brigade,@repairBrigade)";
            }
            if (comboBoxType.SelectedIndex >= 0 && textBoxQuantity.Text.Length > 0 && textBoxCompleted.Text.Length > 0 && textBoxRepairs.Text.Length > 0 && comboBoxPlace.SelectedIndex >= 0 && comboBoxBrigades.SelectedIndex >= 0 && comboBoxRepairBrigade.SelectedIndex >= 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(command, conn);
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = Convert.ToString(comboBoxType.SelectedItem);
                    cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = Convert.ToInt32(textBoxQuantity.Text);
                    cmd.Parameters.Add("@completed", SqlDbType.Int).Value = Convert.ToInt32(textBoxCompleted.Text);
                    cmd.Parameters.Add("@repairs", SqlDbType.Int).Value = Convert.ToInt32(textBoxRepairs.Text);
                    cmd.Parameters.Add("@ctp", SqlDbType.NVarChar).Value = Convert.ToString(comboBoxPlace.SelectedItem);
                    cmd.Parameters.Add("@brigade", SqlDbType.NVarChar).Value = Convert.ToString(comboBoxBrigades.SelectedItem);
                    cmd.Parameters.Add("@repairBrigade", SqlDbType.NVarChar).Value = Convert.ToString(comboBoxRepairBrigade.SelectedItem);
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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Дополните данные", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addPlace addPlace = new addPlace();
            addPlace.ShowDialog();
            outputPlaces();
        }
    }
}

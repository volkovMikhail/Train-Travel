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
    public partial class addWorker : Form
    {
        SqlConnection conn;
        bool isEditMode;
        int id;
        public addWorker()
        {  
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            loadBrigades();
            isEditMode = false;
        }

        public addWorker(int id)
        {
            this.id = id;
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            loadBrigades();
            button1.Text = "Изменить";
            isEditMode = true;
            SqlCommand cmd = new SqlCommand($"SELECT * FROM Workers WHERE Id = {id}", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxOtdel.SelectedItem = Convert.ToString(dataReader[1]);
                    comboBoxBrigade.SelectedItem = Convert.ToString(dataReader[2]);
                    textBoxName.Text = Convert.ToString(dataReader[3]);
                    textBoxLastname.Text = Convert.ToString(dataReader[4]);
                    textBoxMiddle.Text = Convert.ToString(dataReader[5]);
                    maskedTextBox2.Text = Convert.ToString(dataReader[6]);
                    textBoxZP.Text = Convert.ToString(dataReader[7]);
                    comboBoxType.SelectedIndex = Convert.ToInt32(dataReader[8]);
                    dateTimePicker1.Value = Convert.ToDateTime(dataReader[9]);
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

        private void loadBrigades()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Brigades", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                comboBoxBrigade.Items.Clear();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxBrigade.Items.Add(Convert.ToString(dataReader[0]));
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

        private void addWorker_Load(object sender, EventArgs e)
        {
            
        }

        private void textBoxZP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBoxZP.Text.IndexOf(",") == -1) && (textBoxZP.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBoxZP_Leave(object sender, EventArgs e)
        {
            if (textBoxZP.Text[textBoxZP.Text.Length - 1] == ',')
            {
                textBoxZP.Text += 0.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command;
            if (isEditMode)
            {
                command = $"UPDATE Workers SET otdel = @otdel, brigada = @brigade, name = @name,lastName = @lastname,middleName = @middle,phone = @phone, zp = @zp,type = @type,medDate = @medDate WHERE Id = {id}";
            }
            else
            {
                command = "INSERT INTO Workers VALUES(@otdel,@brigade,@name,@lastname,@middle,@phone,@zp,@type,@medDate)";
            }
            if (comboBoxType.SelectedIndex > -1 && comboBoxOtdel.SelectedIndex > -1 && comboBoxBrigade.SelectedIndex > -1 && textBoxName.Text.Trim().Length > 1 && textBoxLastname.Text.Trim().Length>1 && textBoxMiddle.Text.Trim().Length >1 &&textBoxZP.Text.Length > 0 && maskedTextBox2.Text.Length == 17)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(command,conn);
                    cmd.Parameters.Add("@otdel", SqlDbType.NVarChar).Value = comboBoxOtdel.SelectedItem.ToString();
                    cmd.Parameters.Add("@brigade", SqlDbType.NVarChar).Value = comboBoxBrigade.SelectedItem.ToString();
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBoxName.Text;
                    cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = textBoxLastname.Text;
                    cmd.Parameters.Add("@middle", SqlDbType.NVarChar).Value = textBoxMiddle.Text;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
                    cmd.Parameters.Add("@zp", SqlDbType.Decimal).Value = Convert.ToSingle(textBoxZP.Text);
                    cmd.Parameters.Add("@type", SqlDbType.Bit).Value = comboBoxType.SelectedIndex;
                    cmd.Parameters.Add("@medDate", SqlDbType.Date).Value = dateTimePicker1.Value;
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
                MessageBox.Show("Дополните данные","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

    }
}

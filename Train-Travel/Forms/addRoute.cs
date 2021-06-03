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
    public partial class addRoute : Form
    {
        SqlConnection conn;
        public addRoute()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBoxPrice.Text.IndexOf(",") == -1) && (textBoxPrice.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && !Char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            if (textBoxPrice.Text[textBoxPrice.Text.Length-1] == ',')
            {
                textBoxPrice.Text += 0.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxFrom.Text.Trim() != string.Empty && textBoxTo.Text.Trim() != string.Empty && comboBoxType.SelectedIndex >= 0 && maskedTextBoxStartTime.Text.Trim().Length == 5 && textBoxCount.Text != string.Empty && textBoxPrice.Text != string.Empty && dateTimePickerEnd.Value.Date >= dateTimePickerStart.Value.Date)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Voyage VALUES(@from,@to,@startDate,@time,@endDate,@count,@price,@type)", conn);
                    cmd.Parameters.Add("@from", SqlDbType.NVarChar).Value = textBoxFrom.Text;
                    cmd.Parameters.Add("@to", SqlDbType.NVarChar).Value = textBoxTo.Text;
                    cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = dateTimePickerStart.Value;
                    cmd.Parameters.Add("@time", SqlDbType.Time).Value = maskedTextBoxStartTime.Text;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = dateTimePickerEnd.Value;
                    cmd.Parameters.Add("@count", SqlDbType.Int).Value = Convert.ToInt32(textBoxCount.Text);
                    cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = Convert.ToSingle(textBoxPrice.Text);
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = Convert.ToString(comboBoxType.SelectedItem);
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

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

namespace Train_Travel
{
    public partial class mainUser : Form
    {
        User user;
        
        public mainUser(int userId)
        {
            InitializeComponent();
            user = new User(userId);
        }
        private void mainUser_Load(object sender, EventArgs e)
        {
            dateTimePickerEndDate.Value = DateTime.Now.AddDays(90);
            dateTimePickerStartDate.Value = DateTime.Now;
        }

        private void textBoxEndPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBoxEndPrice.Text.IndexOf(",") == -1) && (textBoxEndPrice.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }

        private void textBoxStartPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBoxStartPrice.Text.IndexOf(",") == -1) && (textBoxStartPrice.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back) e.Handled = true;
            }
        }
    }
}

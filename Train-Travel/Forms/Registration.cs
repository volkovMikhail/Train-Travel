using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Train_Travel.Forms
{
    public partial class Registration : Form
    {
        bool lastNameIsOk;
        bool nameIsOk;
        bool middleNameIsOk;
        bool phoneIsOk;
        bool emailIsOk;
        bool passwordIsOk;
        bool typeIsOk;

        SqlConnection conn;

        public Registration()
        {
            InitializeComponent();
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            lastNameIsOk = false;
            nameIsOk = false;
            middleNameIsOk = false;
            phoneIsOk = false;
            emailIsOk = false;
            passwordIsOk = false;
            typeIsOk = false;

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }


        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length < 2 || textBoxName.Text.Length > 50)
            {
                nameIsOk = false;
                labelErrorReg.Text = "Не допустимое значение имени";
                labelErrorReg.Visible = true;
            }
            else
            {
                nameIsOk = true;
                labelErrorReg.Text = "";
                labelErrorReg.Visible = false;
            }
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLastName.Text.Length < 2 || textBoxLastName.Text.Length > 50)
            {
                lastNameIsOk = false;
                labelErrorReg.Text = "Не допустимое значение отчества";
                labelErrorReg.Visible = true;
            }
            else
            {
                lastNameIsOk = true;
                labelErrorReg.Text = "";
                labelErrorReg.Visible = false;
            }
        }


        private void textBoxMiddleName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMiddleName.Text.Length < 2 || textBoxMiddleName.Text.Length > 50)
            {
                middleNameIsOk = false;
                labelErrorReg.Text = "Не допустимое значение отчества";
                labelErrorReg.Visible = true;
            }
            else
            {
                middleNameIsOk = true;
                labelErrorReg.Text = "";
                labelErrorReg.Visible = false;
            }
        }

        private void maskedTextBoxPhone_TextChanged(object sender, EventArgs e)
        {
            char[] phone = new char[17];
            bool isFull = true;
            for (int i = 5; i < 17; i++)
            {
                try
                {
                    phone[i] = maskedTextBoxPhone.Text[i];
                }
                catch (Exception)
                {
                    phone[i] = ' ';
                }
                if (phone[i] == ' ')
                {
                    isFull = false;
                }
            }
            if (isFull)
            {
                phoneIsOk = true;
                labelErrorReg.Visible = false;
            }
            else
            {
                phoneIsOk = false;
                labelErrorReg.Text = "Неверный номер телефона";
                labelErrorReg.Visible = true;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            bool emailCheck = false;
            for (int i = 0; i < textBoxEmail.Text.Length; i++)
            {
                if (textBoxEmail.Text[i] == '@')
                {
                    emailCheck = true;
                }
            }
            if (emailCheck)
            {
                emailIsOk = true;
                labelErrorReg.Text = "";
                labelErrorReg.Visible = false;
            }
            else
            {
                emailIsOk = false;
                labelErrorReg.Text = "Неверный email";
                labelErrorReg.Visible = true;
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Length < 8)
            {
                passwordIsOk = false;
                labelErrorReg.Text = "Пароль слишком маленький";
                labelErrorReg.Visible = true;
            }
            else if (textBoxPassword.Text.Length > 50)
            {
                passwordIsOk = false;
                labelErrorReg.Text = "Пароль слишком большой";
                labelErrorReg.Visible = true;
            }
            else if (textBoxPassword.Text != textBoxConfirm.Text)
            {
                passwordIsOk = false;
                labelErrorReg.Text = "Подтвердите пароль";
                labelErrorReg.Visible = true;
            }
            else
            {
                passwordIsOk = true;
                labelErrorReg.Text = "";
                labelErrorReg.Visible = false;
            }
        }

        private void textBoxConfirm_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Length < 8)
            {
                passwordIsOk = false;
                labelErrorReg.Text = "Пароль слишком маленький";
                labelErrorReg.Visible = true;
            }
            else if (textBoxPassword.Text.Length > 50)
            {
                passwordIsOk = false;
                labelErrorReg.Text = "Пароль слишком большой";
                labelErrorReg.Visible = true;
            }
            else if (textBoxPassword.Text != textBoxConfirm.Text)
            {
                passwordIsOk = false;
                labelErrorReg.Text = "Вы не потдвердили пароль";
                labelErrorReg.Visible = true;
            }
            else
            {
                passwordIsOk = true;
                labelErrorReg.Text = "";
                labelErrorReg.Visible = false;
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == -1)
            {
                typeIsOk = false;
                labelErrorReg.Text = "Недопустимое значение типа";
                labelErrorReg.Visible = true;
            }
            else
            {
                typeIsOk = true;
                labelErrorReg.Text = "";
                labelErrorReg.Visible = false;
            }
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (lastNameIsOk && nameIsOk && middleNameIsOk && emailIsOk && phoneIsOk && passwordIsOk && typeIsOk)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES(@name,@lastname,@middlename,@phone,@email,@password,@role,@active)", conn);
                    bool active = comboBoxType.SelectedIndex == 0 ? true : false;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBoxName.Text;
                    cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = textBoxLastName.Text;
                    cmd.Parameters.Add("@middlename", SqlDbType.NVarChar).Value = textBoxMiddleName.Text;
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = maskedTextBoxPhone.Text;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = textBoxEmail.Text;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = textBoxPassword.Text;
                    cmd.Parameters.Add("@role", SqlDbType.Int).Value = comboBoxType.SelectedIndex;
                    cmd.Parameters.Add("@active", SqlDbType.Bit).Value = active;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Регистрация прошла успешно!","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message,"Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Дополните данные","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}

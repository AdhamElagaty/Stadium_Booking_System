using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stadium_Booking_Systerm
{
    public partial class Form_login : Form
    {
        public static Form_login Instance;
        public string username;

        public Form_login()
        {
            InitializeComponent();
            Instance = this;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TexteBox_Enter(ref TextBox t)
        {
            t.Text = string.Empty;
            t.ForeColor = Color.LightGray;
            if (textname.TabStop == false || textpass.TabStop == false)
            {
                textpass.TabStop = true;
                textname.TabStop = true;
            }
        }

        private void textpass_Enter(object sender, EventArgs e)
        {
            if (textpass.Text == "Password")
            {
                lab_pass_err.Text = "";
                textpass.TextAlign = HorizontalAlignment.Left;
                TexteBox_Enter(ref textpass);
                textpass.PasswordChar = '*';
            }
            lab_login_error.Text = string.Empty;
            hide_pass_btn.Visible = true;
        }

        private void textname_Enter(object sender, EventArgs e)
        {
            if (textname.Text == "UserName")
            {
                lab_username_err.Text = "";
                TexteBox_Enter(ref textname);
            }
            lab_login_error.Text = string.Empty;
        }

        private void textname_Leave(object sender, EventArgs e)
        {
            if (textname.Text == "")
            {
                textname.Text = "UserName";
                textname.ForeColor = Color.IndianRed;
                lab_username_err.Text = "UserName Required!";
            }
        }

        private void textpass_Leave(object sender, EventArgs e)
        {
            if (textpass.Text == "")
            {
                textpass.TextAlign = HorizontalAlignment.Center;
                textpass.PasswordChar = '\0';
                textpass.ForeColor = Color.IndianRed;
                textpass.Text = "Password";
                lab_pass_err.Text = "Password Required!";
            }
            if (textpass.Text != "Password")
            {
                textpass.PasswordChar = '*';
            }
            show_pass_btn.Visible = false;
            hide_pass_btn.Visible = false;
        }

        private void textpass_TextAlignChanged(object sender, EventArgs e)
        {
            if (textpass.TextAlign == HorizontalAlignment.Center)
            {
                btnlogin.Focus();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (textname.Text != "UserName" && textpass.Text != "Password")
            {
                Account account = new Account();
                string username = textname.Text, password = textpass.Text;
                account.set_UserName_Password(username, password);
                if (account.login_Check())
                {
                    this.username = account.get_UserName();
                    if (account.get_type() == "Admin" || account.get_type() == "Employee")
                    {
                        Main_Form form = new Main_Form();
                        Main_Form.Instance.set_username(username);
                        this.Visible = false;
                        form.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    lab_login_error.Text = "UserName or Password is InCorrect";
                }

            }
            else
            {
                if(textname.Text == "UserName")
                {
                    textname.ForeColor = Color.IndianRed;
                    lab_username_err.Text = "UserName Required!";
                }
                if (textpass.Text == "Password")
                {
                    textpass.ForeColor = Color.IndianRed;
                    lab_pass_err.Text = "Password Required!";
                }
            }
        }

        private void show_pass_btn_Click(object sender, EventArgs e)
        {
            hide_pass_btn.Visible = true;
            show_pass_btn.Visible = false;
            textpass.PasswordChar = '*';

        }
        public void Enter_Key(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnlogin_Click(sender, e);
            }
        }
        private void hide_pass_btn_Click(object sender, EventArgs e)
        {
            hide_pass_btn.Visible = false;
            show_pass_btn.Visible = true;
            textpass.PasswordChar = '\0';
        }

        private void btn_exite_light_MouseHover(object sender, EventArgs e)
        {
            btn_exite_light.Visible = false;
            btn_exite_dark.Visible = true;
        }

        private void btn_exite_dark_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_exite_dark_MouseLeave(object sender, EventArgs e)
        {
            btn_exite_light.Visible = true;
            btn_exite_dark.Visible = false;
        }
    }
}

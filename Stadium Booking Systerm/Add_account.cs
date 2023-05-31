using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace Stadium_Booking_Systerm
{
    public partial class Add_account : Form
    {
        public Add_account()
        {
            InitializeComponent();
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
        }
        private void textname_Enter(object sender, EventArgs e)
        {
            if (textname.Text == "UserName")
            {
                lab_username_err.Text = "";
                TexteBox_Enter(ref textname);
            }
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
        }
        private void textpass_TextAlignChanged(object sender, EventArgs e)
        {
            if (textpass.TextAlign == HorizontalAlignment.Center)
            {
                textphonenumber.Focus();
            }
        }
        private void textphonenumber_Leave(object sender, EventArgs e)
        {
            if (textphonenumber.Text == "")
            {
                textphonenumber.Text = "Phone Number";
            }
        }
        private void textphonenumber_Enter(object sender, EventArgs e)
        {
            if (textphonenumber.Text == "Phone Number")
            {
                TexteBox_Enter(ref textphonenumber);
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (textname.Text != "UserName" && textpass.Text != "Password" && textfname.Text != "First Name" && textsname.Text != "Second Name" && (radio_Admin.Checked || radio_Employee.Checked))
            {
                Account account = new Account();
                string x = null;
                if (pictureBox1.Image != null)
                {
                    x = "Employee_Image/" + textname.Text + ".jpg";
                }
                account.set_UserName(textname.Text);
                account.set_Password(textpass.Text);
                account.set_phone_number(textphonenumber.Text);
                account.set_person_image(x);
                if (radio_Admin.Checked)
                {
                    account.set_type("Admin");
                }
                else if(radio_Employee.Checked)
                {
                    account.set_type("Employee");
                }
                account.set_first_name(textfname.Text);
                account.set_second_name(textsname.Text);
                account.creat_acconut();
                if (!Directory.Exists("Employee_Image"))
                {
                    Directory.CreateDirectory("Employee_Image");
                }
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save("Employee_Image/" + textname.Text + ".jpg");
                }
                this.Close();
            }
            else
            {
                if(!radio_Admin.Checked && !radio_Employee.Checked)
                {
                    lab_type_error.Text = "Type Required!";
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textsname_Enter(object sender, EventArgs e)
        {
            if (textsname.Text == "Second Name")
            {
                lab_sname_error.Text = "";
                TexteBox_Enter(ref textsname);
            }
        }

        private void textfname_Enter(object sender, EventArgs e)
        {
            if (textfname.Text == "First Name")
            {
                lab_fname_error.Text = "";
                TexteBox_Enter(ref textfname);
            }
        }

        private void btnchoosepic_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_form = new OpenFileDialog();
            open_form.Title = "Choose Pictur";
            open_form.Filter = "Images|*.jpg;*.png;*.bmp";
            open_form.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (open_form.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open_form.FileName);
            }
        }

        private void textfname_Leave(object sender, EventArgs e)
        {
            if (textfname.Text == "")
            {
                textfname.Text = "First Name";
                textfname.ForeColor = Color.IndianRed;
                lab_fname_error.Text = "First Name Required!";
            }
        }
        private void textsname_Leave(object sender, EventArgs e)
        {
            if (textsname.Text == "")
            {
                textsname.Text = "Second Name";
                textsname.ForeColor = Color.IndianRed;
                lab_sname_error.Text = "Second Name Required!";
            }
        }

        private void btn_exite_dark_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_exite_dark_MouseLeave(object sender, EventArgs e)
        {
            btn_exite_light.Visible = true;
            btn_exite_dark.Visible = false;
        }

        private void btn_exite_light_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_exite_light_MouseEnter(object sender, EventArgs e)
        {
            btn_exite_light.Visible = false;
            btn_exite_dark.Visible = true;
        }

        private void radio_Admin_CheckedChanged(object sender, EventArgs e)
        {
            lab_type_error.Text = string.Empty;
        }

        private void radio_Employee_CheckedChanged(object sender, EventArgs e)
        {
            lab_type_error.Text = string.Empty;
        }
    }
}

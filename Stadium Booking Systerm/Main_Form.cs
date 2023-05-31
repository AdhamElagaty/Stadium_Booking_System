using FontAwesome.Sharp;
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

namespace Stadium_Booking_Systerm
{
    public partial class Main_Form : Form
    {
        private int count_close_t = 0;
        public static Main_Form Instance;
        Account account = new Account();
        public string username;
        public Main_Form()
        {
            InitializeComponent();
            Instance = this;
        }
        public void set_username(string username)
        {
            this.username = username;
        }
        private void btn_page_Click(ref IconButton btn)
        {
            foreach (Control c in Panel_slider.Controls)
            {
                if (c is IconButton)
                {
                    if (btn != c && iconButton1 != c)
                    {
                        c.BackColor = Color.FromArgb(0, 0, 0, 0);
                        IconButton btn2 = (IconButton)c;
                        if (btn2.FlatAppearance.MouseOverBackColor != Color.FromArgb(0, 0, 0, 0))
                        {
                            btn2.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 51, 51, 51);
                        }
                    }
                }
            }
            btn.BackColor = Color.FromArgb(51, 51, 51);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 51, 51);
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {

        }
        private void iconButton5_MouseHover(object sender, EventArgs e)
        {
            btn_slider.IconColor = Color.FromArgb(51, 51, 51);
        }

        private void iconButton5_MouseLeave(object sender, EventArgs e)
        {
            btn_slider.IconColor = Color.White;
        }
        private void btn_slider_Click(object sender, EventArgs e)
        {
            if (Panel_slider.Size.Width == 323)
            {
                timer_slider_hide.Start();
                btn_slider.IconChar = FontAwesome.Sharp.IconChar.AlignJustify;
            }
            else if (Panel_slider.Size.Width == 113)
            {
                timer_slider_show.Start();
                btn_slider.IconChar = FontAwesome.Sharp.IconChar.AlignLeft;
            }
        }
        private void timer_slider_hide_Tick(object sender, EventArgs e)
        {
            if (Panel_slider.Size.Width > 113)
            {
                int x = Panel_slider.Size.Width - 21, y = Panel_slider.Size.Height;
                Panel_slider.Size = new Size(x, y);
                bunifuPictureBox1.Location = new Point(157, 21);
            }
            else
            {
                timer_slider_hide.Stop();
            }
        }
        private void timer_slider_show_Tick(object sender, EventArgs e)
        {
            if (Panel_slider.Size.Width < 323)
            {
                int x = Panel_slider.Size.Width + 21, y = Panel_slider.Size.Height;
                Panel_slider.Size = new Size(x, y);
                bunifuPictureBox1.Location = new Point(157, 21);
            }
            else
            {
                timer_slider_show.Stop();
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form_login form = new Form_login();
            form.Show();
        }

        private void btn_logout_MouseHover(object sender, EventArgs e)
        {
            btn_logout.ForeColor = Color.IndianRed;
            btn_logout.IconColor = Color.IndianRed;
        }

        private void btn_logout_MouseLeave(object sender, EventArgs e)
        {
            btn_logout.ForeColor = Color.White;
            btn_logout.IconColor = Color.White;
        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 1)
                this.mainpanel.Controls.RemoveAt(1);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            if(f == Tickets.Instance)
            {
                Tickets.Instance.set_username(username);
            }else if(f == Match.Instance)
            {
                Match.Instance.set_user_name(username);
            }
            f.Show();
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            btn_page_Click(ref btn_home);
            loadform(new Home());
        }

        private void Form_Admin_Load(object sender, EventArgs e)
        {
            btn_home_Click(sender,e);
            label1.Text = DateTime.Now.ToString("T");
            account.set_UserName(username);
            account.get_Employee_info();
            try
            {
                bunifuPictureBox1.Image = Image.FromFile(account.get_persone_image());
            }catch(Exception)
            {

            }
            iconButton1.Text = account.get_name();
            if(account.get_type() == "Employee")
            {
                btnmanage.Visible = false;
            }
        }

        private void btn_ticket_Click(object sender, EventArgs e)
        {
            btn_page_Click(ref btn_ticket);
            loadform(new Tickets());
        }

        private void btn_matche_Click(object sender, EventArgs e)
        {
            loadform(new Match());
            btn_page_Click(ref btn_matche);
        }

        private void btnmanage_Click(object sender, EventArgs e)
        {
            loadform(new Mange());
            btn_page_Click(ref btnmanage);
        }

        private void timer_mytime_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("T");
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

        private void btn_exite_light_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_exite_light_MouseHover(object sender, EventArgs e)
        {
            btn_exite_light.Visible = false;
            btn_exite_dark.Visible = true;
        }
    }
}

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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Mange_Matche m = new Mange_Matche();
            if (m.get_next_match())
            {
                panel_home_sorr.Visible = true;
                pictureBox3.Image = Image.FromFile(m.Team1_pic_dis);
                pictureBox2.Image = Image.FromFile(m.Team2_pic_dis);
                label9.Text = m.First_team_name;
                label2.Text = m.Second_team_name;
                label7.Text = m.Match_date_time.ToString();
                label8.Text = m.Number_of_audience.ToString();
            }
            else
            {
                panel_home.Visible = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stadium_Booking_Systerm
{
    public partial class Form_Loding : Form
    {
        private int counter = 0;
        public Form_Loding()
        {
            InitializeComponent();
        }

        private void timer_load_form_Tick(object sender, EventArgs e)
        {
            if (counter < 101)
            {
                bunifuCircleProgress1.Value = counter;
                counter++;
                return;
            }
            else if(counter < 105)
            {
                counter++;
                return;
            }
            timer_load_form.Enabled = false;
            this.Visible = false;
            Form_login f = new Form_login();
            f.ShowDialog();
        }

        private void timer_motion_Tick(object sender, EventArgs e)
        {
            int x = panel_picture.Location.X-5, y = panel_picture.Location.Y;
            if(x > 12)
            {
                panel_picture.Location = new Point(x, y);
            }
            else
            {
                timer_motion.Enabled = false;
            }
        }
    }
}

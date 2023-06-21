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
    public partial class Stad_seat_Book : Form
    {
        public static Stad_seat_Book Instance;
        Account account = new Account();
        Mange_Matche mange_Matche = new Mange_Matche();
        Ticket ticket = new Ticket();
        private string x = "";
        private int num_of_seats = 0, price = 132, Ticket_price = 0;
        public string username;
        private bool check_book = true;
        public Stad_seat_Book()
        {
            InitializeComponent();
            Instance = this;
        }
        public void set_username(string username)
        {
            this.username = username;
        }
        private void Stad_seat_Book_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("T");
            account.set_UserName(username);
            account.get_Employee_info();
            mange_Matche.get_next_match();
            pictureBox4.Image = Image.FromFile(mange_Matche.Team1_pic_dis);
            pictureBox3.Image = Image.FromFile(mange_Matche.Team2_pic_dis);
            label3.Text = mange_Matche.Match_date_time.ToString();
            label4.Text = num_of_seats.ToString();
            label6.Text = Ticket_price.ToString("c");
            int[] set = new int[445];
            set = mange_Matche.seats.ToArray();
            int i = 0;
            foreach (Control c in this.Controls)
            {
                if (c is Button) {
                    string x = c.Name.Remove(0, 6);
                    try
                    {
                        int z = Convert.ToInt32(x);
                        if (!mange_Matche.Check_this_chair_Avalibal(z))
                        {
                            c.BackColor = Color.FromArgb(255,192,192);
                        }
                    }
                    catch(Exception)
                    {

                    }
                }
            }
        }
        private void mytime_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("T");
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(text_name.Text != "Name")
            {
                if(num_of_seats != 0)
                {
                    DateTime d = DateTime.Now;
                    ticket.Name = text_name.Text;
                    ticket.Number_of_seats = num_of_seats;
                    ticket.Price = Ticket_price;
                    ticket.Match_id = mange_Matche.Id;
                    ticket.D = d;
                    ticket.employee_username = account.get_UserName();
                    x = x.Remove(0, 1);
                    ticket.Set_num = x;
                    if (ticket.insert_ticket())
                    {
                        this.Close();
                    }
                }
                else
                {
                    label8.Text = "No Seats Selected to Book";
                }
            }
            else
            {
                lab_username_err.Text = "Name Required!";
            }
        }

        private void text_name_Enter(object sender, EventArgs e)
        {
            if (text_name.Text == "Name")
            {
                lab_username_err.Text = "";
                text_name.Text = string.Empty;
                text_name.ForeColor = Color.LightGray;
            }
        }

        private void text_name_Leave(object sender, EventArgs e)
        {
            if (text_name.Text == "")
            {
                text_name.Text = "Name";
                text_name.ForeColor = Color.IndianRed;
                lab_username_err.Text = "Name Required!";
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

        private void btn_exite_light_MouseHover(object sender, EventArgs e)
        {
            btn_exite_light.Visible = false;
            btn_exite_dark.Visible = true;
        }

        public void Enter_Key(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                iconButton1_Click(sender, e);
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.BackColor != Color.FromArgb(255, 192, 192))
            {
                if (button.BackColor != Color.FromArgb(192, 255, 192) && check_book)
                {
                    button.BackColor = Color.FromArgb(192, 255, 192);
                    x += "," + button.Name.Remove(0, 6) + " ";
                    num_of_seats++;
                    Ticket_price += price;
                    check_book = false;
                }
                else if(!check_book && button.BackColor == Color.FromArgb(192,255,192))
                {
                    button.BackColor = Color.Gray;
                    if (x != "")
                    {
                        x = x.Replace("," + button.Name.Remove(0, 6) + " ", "");
                        num_of_seats--;
                        Ticket_price -= price;
                    }
                    check_book = true;
                }
                label4.Text = num_of_seats.ToString();
                label6.Text = Ticket_price.ToString("c");
            }
        }
    }
}

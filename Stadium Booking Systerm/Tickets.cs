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
    public partial class Tickets : Form
    {
        public static Tickets Instance;
        Account account = new Account();
        public string username;
        private int x;
        public Tickets()
        {
            InitializeComponent();
            Instance = this;
        }
        public void set_username(string username)
        {
            this.username = username;
        }
        public void Refresh_Data()
        {
            Clear_data_gride_view();
            Ticket ticket = new Ticket();
            DataTable dt = new DataTable();
            dt = ticket.view_All_ticket();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(imageList1.Images[0], dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Teams_name"].ToString(), dt.Rows[i]["Match_Date"].ToString(), dt.Rows[i]["Number_of_Seats"].ToString(), dt.Rows[i]["Booking_Date"].ToString(), dt.Rows[i]["Price"].ToString(), dt.Rows[i]["Employee_Name"].ToString());
            }
            if (dataGridView1.RowCount > 14)
            {
                bunifuVScrollBar1.Visible = true;
            }
            else
            {
                bunifuVScrollBar1.Visible = false;
            }
            dataGridView1.ClearSelection();
        }
        public void Clear_data_gride_view()
        {
            dataGridView1.DataSource = null;    
            dataGridView1.Rows.Clear();
        }
        private void Tickets_Load(object sender, EventArgs e)
        {
            Refresh_Data();
            account.set_UserName(username);
            account.get_Employee_info();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                bunifuVScrollBar1.Maximum = dataGridView1.RowCount - 1;
                
            }
            catch (Exception)
            {

            }
        }
        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            try
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[e.Value].Index;
            }catch(Exception)
            {

            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Stad_seat_Book stad_Seat_Book = new Stad_seat_Book();
            Stad_seat_Book.Instance.set_username(username);
            Clear_data_gride_view();
            stad_Seat_Book.ShowDialog();
            Refresh_Data();
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if(bunifuTextBox1.Text != "")
            {
                int id;
                if (int.TryParse(bunifuTextBox1.Text, out id))
                {
                    dataGridView1.Refresh();
                    Ticket ticket = new Ticket();
                    DataTable dt = new DataTable();
                    dt = ticket.search_by_id(id);
                    Clear_data_gride_view();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(imageList1.Images[0], dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Teams_name"].ToString(), dt.Rows[i]["Match_Date"].ToString(), dt.Rows[i]["Number_of_Seats"].ToString(), dt.Rows[i]["Booking_Date"].ToString(), dt.Rows[i]["Price"].ToString(), dt.Rows[i]["Employee_Name"].ToString());
                    }
                    dataGridView1.ClearSelection();
                }
                else
                {
                    label_error.Text = "Search With ID Number!";
                }
            }
            else
            {
                Refresh_Data();
            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if(account.get_type() != "Employee")
            {
                Ticket ticket = new Ticket();
                ticket.Delete(x);
                Refresh_Data();
                iconButton2.Visible = false;
            }
        }
        private void bunifuTextBox1_Enter(object sender, EventArgs e)
        {
            label_error.Text = string.Empty;
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            iconButton2.Visible = false;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (account.get_type() != "Employee")
                {
                    iconButton2.Visible = true;
                }
                x = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            iconButton2.Visible = false;
        }
    }
}

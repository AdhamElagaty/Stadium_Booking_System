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
using System.Security.Principal;

namespace Stadium_Booking_Systerm
{
    public partial class Mange : Form
    {
        private string x = "";
        public Mange()
        {
            InitializeComponent();
        }
        public void Refresh_Data()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                Account account = new Account();
                DataTable dt = new DataTable();
                dt = account.view_All_Account();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(imageList1.Images[0], dt.Rows[i]["UserName"].ToString(), dt.Rows[i]["Employee_Name"].ToString(), dt.Rows[i]["Phone_Number"].ToString(), dt.Rows[i]["Type"].ToString());
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
                pictureBox1.Visible = false;
            }
            catch (Exception)
            {
                return;
            }
        }
        public void Clear_data_gride_view()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(imageList1.Images[0], "", "", "", "", "");
            }
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
            }
            catch (Exception)
            {

            }
        }

        private void Mange_Load(object sender, EventArgs e)
        {
            Refresh_Data();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            iconButton2.Visible = false;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Refresh_Data();
            pictureBox1.Image = null;
            iconButton2.Visible = false;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Clear_data_gride_view();
            pictureBox1.Image = null;
            if (bunifuTextBox1.Text != "")
            {
                dataGridView1.Refresh();
                Account account = new Account();
                DataTable dt = new DataTable();
                dt = account.search_by_id(bunifuTextBox1.Text);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add(imageList1.Images[0], dt.Rows[i]["UserName"].ToString(), dt.Rows[i]["Employee_Name"].ToString(), dt.Rows[i]["Phone_Number"].ToString(), dt.Rows[i]["Type"].ToString());
                }
                try
                {
                    pictureBox1.Image = Image.FromFile(account.get_persone_image());
                    pictureBox1.Visible = true;
                }catch(Exception)
                {

                }
            }
            else
            {
                Refresh_Data();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Add_account add_Account = new Add_account();
            add_Account.ShowDialog();
            Refresh_Data();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Delete(x);
            Refresh_Data();
            iconButton2.Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                x = dataGridView1.Rows[e.RowIndex].Cells["User_name"].Value.ToString();
                iconButton2.Visible = true;
            }catch(Exception) { }
            Account account = new Account();
            account.set_UserName(x);
            account.get_Employee_info();
            try
            {
                pictureBox1.Image = Image.FromFile(account.get_persone_image());
                pictureBox1.Visible = true;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}

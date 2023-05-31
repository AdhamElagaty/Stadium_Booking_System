using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Policy;

namespace Stadium_Booking_Systerm
{
    public partial class Match : Form
    {
        public static Match Instance;
        Account account = new Account();
        private string UserName = "";
        private int x = 0;
        public void set_user_name(string name)
        {
            this.UserName = name;
        }
        public Match()
        {
            InitializeComponent();
            Instance = this;
        }
        public void Refresh_Data()
        {
            Clear_data_gride_view();
            Mange_Matche mange_Matche = new Mange_Matche();
            DataTable dt = new DataTable();
            dt = mange_Matche.view_All_ticket();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(imageList1.Images[0], dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Teams_name"].ToString(), dt.Rows[i]["Match_Date"].ToString());
            }
            if (dataGridView1.RowCount > 10)
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
            dataGridView1.Rows.Clear();
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
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
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

        private void Match_Load(object sender, EventArgs e)
        {
            account.set_UserName(UserName);
            account.get_Employee_info();
            if(account.get_type() == "Employee")
            {
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                dateTimePicker1.Visible = false;
                iconButton1.Visible = false;
                iconButton2.Visible = false;
                panel1.Location = new Point(850,277);
                label1.Visible = true;
            }
            dateTimePicker1.CustomFormat = "hh:mm:ss tt MM/dd/yyyy";
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Programing\Project\Stadium_Booking_System\Stadium_Booking_System\Stadium Booking Systerm\Stadium_System_Data.mdf"";Integrated Security=True");
            try
            {
                cn.Open();
                string Query = "select * from Teams";
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    while (sdr.Read())
                    {
                        comboBox1.Items.Add(sdr.GetString(1));
                        comboBox2.Items.Add(sdr.GetString(1));
                    }
                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
            Refresh_Data();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Mange_Matche mange_Matche = new Mange_Matche();
            mange_Matche.First_team_name = comboBox1.Text;
            mange_Matche.Second_team_name= comboBox2.Text;
            mange_Matche.Match_date_time = dateTimePicker1.Value;
            mange_Matche.insert_match();
            Refresh_Data();
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if(account.get_type() != "Employee")
            {
                Mange_Matche mange_Matche = new Mange_Matche();
                mange_Matche.Delete(x);
                dataGridView1.ClearSelection();
                Refresh_Data();
                iconButton2.Visible = false;
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            iconButton2.Visible = false;
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                if(account.get_type() != "Employee")
                {
                    iconButton2.Visible = true;
                }
                x = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                Mange_Matche mange_Matche = new Mange_Matche();
                mange_Matche.Id = x;
                mange_Matche.Get_id_teams_by_match_id();
                comboBox1.SelectedIndex = mange_Matche.Team1_id - 1;
                comboBox2.SelectedIndex = mange_Matche.Team2_id - 1;
            }
            catch (Exception)
            {
                return;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells == null)
            {
                iconButton2.Visible =false;
            }
        }
        private void get_pictur(int id, ref PictureBox b)
        {
            id++;
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Programing\Project\Stadium_Booking_System\Stadium_Booking_System\Stadium Booking Systerm\Stadium_System_Data.mdf"";Integrated Security=True");
            try
            {
                cn.Open();
                string Query = "select * from Teams where Id = " + id;
                string x;
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    while (sdr.Read())
                    {
                        b.Image = Image.FromFile(sdr.GetSqlValue(2).ToString());
                    }
                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_pictur(comboBox2.SelectedIndex,ref pictureBox3);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_pictur(comboBox1.SelectedIndex, ref pictureBox2);
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text != "")
            {
                int id;
                if (int.TryParse(bunifuTextBox1.Text, out id))
                {
                    Clear_data_gride_view();
                    dataGridView1.Refresh();
                    Mange_Matche mange_Matche = new Mange_Matche();
                    DataTable dt = new DataTable();
                    dt = mange_Matche.search_by_id(id);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(imageList1.Images[0], dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Teams_name"].ToString(), dt.Rows[i]["Match_Date"].ToString());
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.ClearSelection();
            iconButton2.Visible = false;
        }

        private void bunifuTextBox1_Enter(object sender, EventArgs e)
        {
            label_error.Text = string.Empty;
        }
    }
}

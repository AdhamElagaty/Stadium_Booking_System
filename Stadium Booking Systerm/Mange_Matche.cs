using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Stadium_Booking_Systerm
{
    internal class Mange_Matche
    {
        private SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Programing\Project\Stadium_Booking_System\Stadium_Booking_System\Stadium Booking Systerm\Stadium_System_Data.mdf"";Integrated Security=True");
        private string first_team_name = "", second_team_name = "", team1_pic_dis = "", team2_pic_dis = "";
        private int team1_id, team2_id;
        private DateTime match_date_time = new DateTime();
        private int number_of_audience = 0, id;
        private int[] Seats = new int[550];
        public string First_team_name
        {
            get{
                return this.first_team_name;
            }
            set
            {
                this.first_team_name = value;
            }
        }
        public string Second_team_name
        {
            get
            {
                return this.second_team_name;
            }
            set
            {
                this.second_team_name = value;
            }
        }
        public DateTime Match_date_time
        {
            get
            {
                return this.match_date_time;
            }
            set
            {
                this.match_date_time = value;
            }
        }
        public string Team1_pic_dis
        {
            get { 
                return this.team1_pic_dis;
            }
            set
            {
                this.team1_pic_dis = value;
            }
        }
        public string Team2_pic_dis
        {
            get
            {
                return this.team2_pic_dis;
            }
            set
            {
                this.team2_pic_dis = value;
            }
        }
        public int Number_of_audience
        {
            get
            {
                return this.number_of_audience;
            }
            set
            {
                this.number_of_audience = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int[] seats
        {
            get
            {
                return Seats;
            }
            set { 
                Seats = value;
            }
        }
        public int Team1_id
        {
            get
            {
                return this.team1_id;
            }
            set 
            { 
            this.team1_id = value;
            }
        }
        public int Team2_id
        {
            get 
            { 
                return this.team2_id;
            }
            set 
            { 
                this.team2_id = value; 
            }
        }
        public void set_mange(string s)
        {
            int x;
            string y = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ',' && i != s.Length-1)
                {
                    if (s[i] != ' ')
                    {
                        y += s[i];
                    }
                }
                else
                {
                    x = Convert.ToInt32(y);
                    y = "";
                    if (this.Seats[x] != 1)
                    {
                        this.number_of_audience++;
                        this.Seats[x] = 1;
                    }
                }
            }
        }
        public DataTable search_by_id(int sid)
        {
            try
            {
                cn.Open();
                string Query = "select Id , Teams_name , Match_Date from Matches where Id = " + sid;
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public bool Check_this_chair_Avalibal(int n)
        {
            if (Seats[n] == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Generat_Id()
        {
            try
            {
                cn.Open();
                string Query = "select top 1 Id from Matches order by Id DESC";
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    while (sdr.Read())
                    {
                        this.id = sdr.GetInt32(0);
                    }
                    this.id += 1;
                    cn.Close();
                    return true;
                }
                id = 1000;
                cn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void Get_id_teams_by_match_id()
        {
            try
            {
                cn.Open();
                string Query = "select Team1_id , Team2_id from Matches where Id = " + this.id;
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    while (sdr.Read())
                    {
                        this.team1_id = sdr.GetInt32(0);
                        this.team2_id = sdr.GetInt32(1);
                    }
                }
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }
        public bool insert_match()
        {
            try
            {
                cn.Open();
                string Query = "select Id from Teams where name = '" + this.first_team_name +"'";
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    while (sdr.Read())
                    {
                        this.team1_id = sdr.GetInt32(0);
                    }
                }
                else
                {
                    cn.Close();
                    return false;
                }
                sdr.Close();
                string q = "select Id from Teams where name = '" + this.second_team_name + "'";
                SqlCommand c = new SqlCommand(q, cn);
                SqlDataAdapter s = new SqlDataAdapter(c);
                DataTable d = new DataTable();
                s.Fill(d);
                SqlDataReader sd = c.ExecuteReader();
                if (d.Rows.Count > 0)
                {
                    while (sd.Read())
                    {
                        this.team2_id = sd.GetInt32(0);
                    }
                }
                sd.Close();
                cn.Close();
                Generat_Id();
                cn.Open();
                string t = this.first_team_name + " vs " + this.second_team_name;
                string Q = "insert into Matches (Id, Team1_id, Team2_id, Match_Date, Teams_name) values ( " + this.id + " , " + this.team1_id + " , " + this.team2_id + " , '" + this.match_date_time + "' , '" + t +"')";
                SqlCommand C = new SqlCommand(Q, cn);
                C.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public DataTable view_All_ticket()
        {
            try
            {
                cn.Open();
                string Query = "select Id , Teams_name , Match_Date from Matches";
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public bool get_next_match()
        {
            try
            {
                DateTime a = DateTime.Now;
                int x = 0, y = 0;
                string z = "";
                cn.Open(); 
                string Query = "select top 1 Id, Team1_id , Team2_id , Match_Date , Booking_Seats from Matches where Match_Date >= '" + a + "' ORDER BY Match_Date Asc";
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    while (sdr.Read())
                    {
                        this.id = sdr.GetInt32(0);
                        x = sdr.GetInt32(1);
                        y = sdr.GetInt32(2);
                        this.match_date_time = sdr.GetDateTime(3);
                        try
                        {
                            z = sdr.GetString(4);
                        }
                        catch(Exception)
                        {

                        }
                    }
                    this.set_mange(z);
                }
                else
                {
                    cn.Close();
                    return false;
                }
                sdr.Close();
                string q = "select * from Teams where Id = " + x;
                SqlCommand c = new SqlCommand(q, cn);
                SqlDataAdapter s = new SqlDataAdapter(c);
                DataTable d = new DataTable();
                s.Fill(d);
                SqlDataReader sd = c.ExecuteReader();
                if (d.Rows.Count > 0)
                {
                    while (sd.Read())
                    {
                        this.first_team_name = sd.GetValue(1).ToString();
                        this.team1_pic_dis = sd.GetValue(2).ToString();
                    }
                }
                sd.Close();
                string Q = "select * from Teams where Id = " + y;
                SqlCommand C = new SqlCommand(Q, cn);
                SqlDataAdapter S = new SqlDataAdapter(C);
                DataTable D = new DataTable();
                S.Fill(D);
                SqlDataReader Sd = C.ExecuteReader();
                if (D.Rows.Count > 0)
                {
                    while (Sd.Read())
                    {
                        this.second_team_name = Sd.GetValue(1).ToString();
                        this.team2_pic_dis = Sd.GetValue(2).ToString();
                    }
                }
                cn.Close();
                return true;
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool Check_FK_ID_Ticket(int sID)
        {
            try
            {
                cn.Open();
                string Query = "select Match_ID from Ticket where Match_ID = " + sID;
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cn.Close();
                    return true;
                }
                cn.Close();
                return false;
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void Delete(int sid)
        {
            if (this.Check_FK_ID_Ticket(sid))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Ticket where Match_ID = " + sid, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    cn.Close();
                }
            }
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("delete from Matches where Id = " + sid, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }
    }
}

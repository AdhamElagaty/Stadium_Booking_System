using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Stadium_Booking_Systerm
{
    internal class Ticket
    {
        private SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Programing\Project\Stadium_Booking_System\Stadium_Booking_System\Stadium Booking Systerm\Stadium_System_Data.mdf"";Integrated Security=True");
        private int id, number_of_seats, match_id, price;
        private string name, Employee_username, name_of_Employee, set_num;
        private DateTime d = new DateTime();
        public int Id {
            get {
                return this.id; 
            } 
            set { 
                id = value;
            } 
        }
        public string Name {
            get { 
                return this.name; 
            } 
            set { 
                name = value;
            }
        }
        public string name_of_employee
        {
            get { 
                return this.name_of_Employee;
            }
            set { 
                name_of_Employee = value; 
            }
        }
        public int Number_of_seats
        {
            get
            {
                return this.number_of_seats;
            }
            set
            {
                this.number_of_seats = value;
            }
        }
        public int Match_id
        {
            get
            {
                return this.match_id;
            }
            set
            {
                this.match_id = value;
            }
        }
        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
        public DateTime D
        {
            get
            {
                return this.d;
            }
            set
            {
                this.d = value;
            }
        }
        public string employee_username
        {
            get
            {
                return this.Employee_username;
            }
            set 
            { 
                this.Employee_username = value;
            }
        }
        public string Set_num
        {
            get
            {
                return this.set_num;
            }
            set
            {
                this.set_num = value;
            }
        }
        public bool Generat_Id()
        {
            try
            {
                cn.Open();
                string Query = "select top 1 Id from Ticket order by Id DESC";
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
                cn.Close();
                this.id = 1000;
                return true;
            }
            catch (SqlException ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool insert_ticket()
        {
            if (Generat_Id())
            {
                try
                {
                    cn.Open();
                    string Query = "insert into Ticket values ( " + this.id + " , '" + this.name + "' , " + this.number_of_seats + " , " + this.price + " , " + this.match_id + " , '" + this.d + "' , '" + this.Employee_username + "' , '" + this.set_num + "')";
                    SqlCommand cmd = new SqlCommand(Query, cn);
                    cmd.ExecuteNonQuery();
                    string z = "";
                    string q = "select Booking_Seats from Matches where Id = " + this.match_id;
                    SqlCommand c = new SqlCommand(q, cn);
                    SqlDataAdapter s = new SqlDataAdapter(c);
                    DataTable d = new DataTable();
                    s.Fill(d);
                    SqlDataReader sd = c.ExecuteReader();
                    if (d.Rows.Count > 0)
                    {
                        while (sd.Read())
                        {
                            z = sd.GetValue(0).ToString();
                        }
                        if (z == "")
                        {
                            z += set_num;
                        }
                        else
                        {
                            z += "," + set_num;
                        }
                    }
                    else
                    {
                        cn.Close();
                        return false;
                    }
                    cn.Close();
                    cn.Open();
                    string Q = "update Matches set Booking_Seats = '" + z + "' where Id = " + this.match_id;
                    SqlCommand C = new SqlCommand(Q, cn);
                    C.ExecuteNonQuery();
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
            else
            {
                return false;
            }
        }
        public DataTable view_All_ticket()
        {
            try
            {
                cn.Open();
                string Query = "select Ticket.Id , Ticket.Name , Matches.Teams_name , Matches.Match_Date , Ticket.Booking_Date ,CONCAT(Account.Firste_Name , ' ' , Account.Second_Name) AS Employee_Name from Ticket , Matches , Account where Ticket.Match_ID=Matches.Id AND Ticket.Employee_username=Account.UserName";
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

        public DataTable search_by_id(int sid)
        {
            try
            {
                cn.Open();
                string Query = "select Ticket.Id , Ticket.Name , Matches.Teams_name , Matches.Match_Date , Ticket.Booking_Date ,CONCAT(Account.Firste_Name , ' ' , Account.Second_Name) AS Employee_Name from Ticket , Matches , Account where Ticket.Match_ID=Matches.Id AND Ticket.Employee_username=Account.UserName AND Ticket.Id = " + sid;
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
        private string Delate_seats_from_match(string z, string m)
        {
            string w = "";
            if(z.IndexOf(m) + m.Length == z.Length)
            {
                w = z.Replace("," + m, "");
            }
            else
            {
                w = z.Replace(m + ",", "");
            }
            return w;
        }
        public void Delete(int sid)
        {
            cn.Open();
            try
            {
                string m = "";
                int x = 0;
                string Q = "select Match_ID , Sets_number from Ticket where Id = " + sid;
                SqlCommand C = new SqlCommand(Q, cn);
                SqlDataAdapter S = new SqlDataAdapter(C);
                DataTable D = new DataTable();
                S.Fill(D);
                SqlDataReader Sd = C.ExecuteReader();
                if (D.Rows.Count > 0)
                {
                    while (Sd.Read())
                    {
                        x = Sd.GetInt32(0);
                        m = Sd.GetValue(1).ToString();
                    }
                }
                else
                {
                    cn.Close();
                    return;
                }
                Sd.Close();
                string z = "";
                string q = "select Booking_Seats from Matches where Id = " + x;
                SqlCommand c = new SqlCommand(q, cn);
                SqlDataAdapter s = new SqlDataAdapter(c);
                DataTable d = new DataTable();
                s.Fill(d);
                SqlDataReader sd = c.ExecuteReader();
                if (d.Rows.Count > 0)
                {
                    while (sd.Read())
                    {
                        z = sd.GetValue(0).ToString();
                    }
                }
                else
                {
                    cn.Close();
                    return;
                }
                sd.Close();
                string w = this.Delate_seats_from_match(z, m);
                SqlCommand cm = new SqlCommand("update Matches set Booking_Seats = '" + w + "' where Id = " + x , cn);
                cm.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("delete from Ticket where Id = " + sid, cn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }
    }
}

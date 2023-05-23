using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stadium_Booking_Systerm
{
    internal class Account
    {
        private SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Programing\Project\Stadium_Booking_System\Stadium_Booking_System\Stadium Booking Systerm\Stadium_System_Data.mdf"";Integrated Security=True");
        private string UserName, Password, type, first_name, second_name, phone_number;
        public Account() { }
        public Account(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }
        public Account(string userName, string password, string type) : this(userName, password)
        {
            this.type = type;
        }
        public Account(string userName, string password, string type, string first_name, string second_name) : this(userName, password, type)
        {
            this.first_name = first_name;
            this.second_name = second_name;
        }
        public Account(string userName, string password, string type, string first_name, string second_name, string phone_number) : this(userName, password, type, first_name, second_name)
        {
            this.phone_number = phone_number;
        }
        public void set_UserName(string userName)
        {
            this.UserName = userName;
        }
        public void set_Password(string password)
        {
            this.Password = password;
        }
        public void set_type(string type)
        {
            this.type = type;
        }
        public void set_UserName_Password(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }
        public void set_UserName_Password_type(string username, string password, string type)
        {
            this.UserName = username;
            this.Password = password;
            this.type = type;
        }
        public void set_first_name(string first_name)
        {
            this.first_name = first_name;
        }
        public void set_second_name(string second_name)
        {
            this.second_name = second_name;
        }
        public void set_first_second_name(string first_name, string second_name)
        {
            this.first_name = first_name;
            this.second_name = second_name;
        }
        public void set_phone_number(string phone_number)
        {
            this.phone_number = phone_number;
        }
        public void set_account_data(string username, string password, string type, string first_name, string second_name, string phone_number)
        {
            this.UserName = username;
            this.Password = password;
            this.type = type;
            this.first_name = first_name;
            this.second_name = second_name;
            this.phone_number = phone_number;
        }
        public string get_UserName()
        {
            return this.UserName;
        }
        public string get_password()
        {
            return this.Password;
        }
        public string get_type()
        {
            return this.type;
        }
        public string get_first_name()
        {
            return this.first_name;
        }
        public string get_second_name()
        {
            return this.second_name;
        }
        public string get_name()
        {
            return (this.first_name + " " + this.second_name);
        }
        public string get_phone_number()
        {
            return this.phone_number;
        }
        public bool is_valid()
        {
            try
            {
                cn.Open();
                string Query = "select * from Account where UserName = '" + this.UserName + "'";
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cn.Close();
                    this.UserName = "";
                    return false;
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
        public bool login_Check()
        {
            try
            {
                cn.Open();
                string Query = "select * from Account where UserName = '" + this.UserName + "' AND Password = '" + this.Password + "'";
                SqlCommand cmd = new SqlCommand(Query, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    while (sdr.Read())
                    {
                        type = sdr.GetValue(2).ToString();
                        first_name = sdr.GetValue(3).ToString();
                        second_name = sdr.GetValue(4).ToString();
                        phone_number = sdr.GetValue(5).ToString();
                    }
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
                return true;
            }
        }
        public bool creat_acconut()
        {
            try
            {
                cn.Open();
                string Query = "insert into Account values ( '" + this.UserName + "' , '" + this.Password + "' , '" + this.type + "' , '" + this.first_name + "' , '" + this.second_name + "' , '" + this.phone_number + "' )";
                SqlCommand cmd = new SqlCommand(Query, cn);
                cmd.ExecuteNonQuery();
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
    }
}


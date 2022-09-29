using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;

namespace book_project.Models
{

    public class AdminSqlImpl : IAdminRepositoy
    {
        SqlConnection conn;
        SqlCommand comm;
        public AdminSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Admin AdminLogin(string id, string pswd)
        {


            

                comm.CommandText = "select * from [admin] where AdminId='" + id + "' and Password='" + pswd + "'";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string adminid = reader["AdminId"].ToString();
                    string pwd = reader["Password"].ToString();

                    Admin admin = new Admin(adminid, pwd);
                    return admin;
                }
                conn.Close();
                return null;
            


        }
        public void RemoveUser(int id)
        {
            comm.CommandText = "delete from [User] where UserId=" + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        public void ActivateUser(int id)
        {
            comm.CommandText = "update [User] set Status='active' where UserId=" + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void DeactivateUser(int id)
        {
            comm.CommandText = "update [User] set Status='inactive' where UserId=" + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
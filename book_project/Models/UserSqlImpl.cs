using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace book_project.Models
{
    public class UserSqlImpl : IUserRepository

    {
        SqlConnection conn;
        SqlCommand comm;
        public UserSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            comm.CommandText = "select * from [user]";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int userid = Convert.ToInt32(reader["UserId"]);
                string pwd = reader["Password"].ToString();
                string status = reader["Status"].ToString();
                string name = reader["Name"].ToString();
                list.Add(new User(userid, pwd, status, name));
            }
            conn.Close();
            return list;
        }

        public User GetById(int id)
        {

            comm.CommandText = "select * from [user] where UserId=" + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int userid = Convert.ToInt32(reader["UserId"]);
                string pwd = reader["Password"].ToString();
                string status = reader["Status"].ToString();
                string name = reader["Name"].ToString();
                User user = new User(userid, pwd, status, name);
                return user;
            }
            conn.Close();
            return null;
        }
        public User GetLogin(int id,string pswd)
        {

            comm.CommandText = "select * from [user] where UserId=" + id+"and Password='"+pswd+"'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int userid = Convert.ToInt32(reader["UserId"]);
                string pwd = reader["Password"].ToString();
                string status = reader["Status"].ToString();
                string name = reader["Name"].ToString();
                User user = new User(userid, pwd, status, name);
                return user;
            }
            conn.Close();
            return null;
        }


        public User RegisterUser(User user)
        {
            comm.CommandText = "insert into [user] values(" + user.UserId + ",'" + user.Password + "','" + user.Status + "','" + user.Name + "')";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            if (rows > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        
        public void AddToWishList(int uid, int bid)
        {
            comm.CommandText = "insert into WishList values("+bid+","+uid+")";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

        }
        public List<Book> ViewWishList(int id)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select Book.BookId,Book.CategoryId,Book.Title,Book.ISBN,Book.Year,Book.Price,Book.Description,Book.Position,Book.Status,Book.Image from Book join WishList on Book.BookId=WishList.BookId where WishList.UserId=" + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookid = Convert.ToInt32(reader["BookId"]);
                int catid = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["title"].ToString();
                string ISBN = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                double price = Convert.ToDouble(reader["Price"]);
                string Description = reader["Description"].ToString();
                string Position = reader["Position"].ToString();
                string Status = reader["Status"].ToString();
                string Image = reader["Image"].ToString();
                list.Add(new Book(bookid, catid, title, ISBN, year, price, Description, Position, Status, Image));
               
            }
            conn.Close();
            return list;
        }
        public void AddToCart(int uid, int bid)
        {
            comm.CommandText = "insert into Cart values(" + bid + "," + uid + ")";
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

        }
        public List<Book> ViewCart(int id)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select Book.BookId,Book.CategoryId,Book.Title,Book.ISBN,Book.Year,Book.Price,Book.Description,Book.Position,Book.Status,Book.Image from Book join Cart on Book.BookId=Cart.BookId where Cart.UserId=" + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int bookid = Convert.ToInt32(reader["BookId"]);
                int catid = Convert.ToInt32(reader["CategoryId"]);
                string title = reader["title"].ToString();
                string ISBN = reader["ISBN"].ToString();
                int year = Convert.ToInt32(reader["Year"]);
                double price = Convert.ToDouble(reader["Price"]);
                string Description = reader["Description"].ToString();
                string Position = reader["Position"].ToString();
                string Status = reader["Status"].ToString();
                string Image = reader["Image"].ToString();
                list.Add(new Book(bookid, catid, title, ISBN, year, price, Description, Position, Status, Image));

            }
            conn.Close();
            return list;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace book_project.Models
{
    public class BookSqlImpl : IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public BookSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Book AddBook(Book book)
        {
            comm.CommandText = "insert into Book values(" + book.BookId + "," + book.CategoryId + ",'" + book.Title + "','" + book.ISBN + "'," + book.Year + "," + book.Price + ",'" + book.Description + "','" + book.Position + "','"+book.Status+"','"+book.Image+"')";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            if (rows > 0)
            {
                return book;
            }
            else
            {
                return null;
            }

        }

        public void DeleteBook(int bookid)
        {
            comm.CommandText = "delete from book where BookId=" + bookid;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Book> GetAll()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from book";
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
                list.Add(new Book(bookid, catid, title, ISBN, year, price, Description, Position,Status,Image));
            }
            conn.Close();
            return list;
        }

        public List<Book> GetByCategory(int bcatid)
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from book where CategoryId="+bcatid;
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
                list.Add(new Book(bookid, catid, title, ISBN, year, price, Description, Position,Status,Image));
                
            }
            conn.Close();
            return list;
        }

        public Book GetByISBN(string bISBN)
        {

            comm.CommandText = "select * from book where ISBN='" + bISBN+"'";
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
                Book book = new Book(bookid, catid, title, ISBN, year, price, Description, Position,Status,Image);
                return book;
            }
            conn.Close();
            return null;
        }

        public Book GetByTitle(string btitle)
        {
            comm.CommandText = "select * from book where Title='" + btitle + "'";
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
                Book book = new Book(bookid, catid, title, ISBN, year, price, Description, Position,Status,Image);
                return book;
            }
            conn.Close();
            return null;
        }

        public void UpdateBook(Book book)
        {
            comm.CommandText = "update book set CategoryId=" + book.CategoryId + ",Title='" + book.Title + "',ISBN='" + book.ISBN + "',Year=" + book.Year + ",Price=" + book.Price + ",Description='" + book.Description + "',Position='" + book.Position + "',Status='"+book.Status+"',Image='"+book.Image+"' where BookId=" + book.BookId;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
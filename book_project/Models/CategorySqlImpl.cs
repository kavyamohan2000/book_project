using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace book_project.Models
{
    public class CategorySqlImpl : ICategoryRepository
    {
        SqlConnection conn;
        SqlCommand comm;
        public CategorySqlImpl() {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public Category AddCategory(Category cat)
        {
            comm.CommandText = "insert into Category(CategoryId,CategoryName,Description,Image,Status,Position) values(" + cat.CategoryId + ",'" + cat.CategoryName + "','" + cat.Description + "','" + cat.Image + "'," + cat.Status + ",'" + cat.Position + "')";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                return cat;
            }
            else
            {
                return null;
            }
        }

        public void DeleteCategory(int id)
        {
            comm.CommandText = "delete from category where CategoryId=" + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from Category where Status=1 order by Position";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["CategoryId"]);
                string name = reader["CategoryName"].ToString();
                string desc = reader["Description"].ToString();
                string img = reader["Image"].ToString();
                int sts = Convert.ToInt32(reader["Status"]);
                string pos = reader["Position"].ToString();
                //DateTime createdat = Convert.ToDateTime(reader["CreatedAt"]);
                list.Add(new Category(id, name, desc, img, sts, pos));

;
            }
            conn.Close();
            return list;

        }

        public Category GetByName(string catname)
        {
            
            comm.CommandText = "select * from Category where CategoryName='"+catname+"'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["CategoryId"]);
                string name = reader["CategoryName"].ToString();
                string desc = reader["Description"].ToString();
                string img = reader["Image"].ToString();
                int sts = Convert.ToInt32(reader["Status"]);
                string pos = reader["Position"].ToString();
                //DateTime createdat = Convert.ToDateTime(reader["CreatedAt"]);
                Category cat=new Category(id, name, desc, img, sts, pos);

                return cat;
            }
            conn.Close();
            return null;

        }

        public void UpdateCategory(Category cat)
        {
            comm.CommandText = "update category set CategoryName='"+cat.CategoryName+"',Description='"+cat.Description+"',Image='"+cat.Image+"',Status="+cat.Status+", Position='"+cat.Position+"' where CategoryId="+cat.CategoryId;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
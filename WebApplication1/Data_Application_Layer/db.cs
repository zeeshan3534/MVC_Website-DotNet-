using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using WebApplication1.Models;
using System.IO;

namespace WebApplication1.Data_Application_Layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
        public DataSet fetch()

        {
            string query = "select * from Slide";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataAdapter rd = new SqlDataAdapter(com);
            //SqlDataReader rd = com.ExecuteReader();
            DataSet ds = new DataSet();
            rd.Fill(ds);
            return ds;
            

        }
        public DataSet show_All()
        {
            SqlCommand com = new SqlCommand("Show_All_rec", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Update_record(Admin ad)
        {
            SqlCommand com = new SqlCommand("Update_Data", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sliderId",ad.sliderId);
            com.Parameters.AddWithValue("@ImageTitle", ad.ImageTitle);
            com.Parameters.AddWithValue("@ImageDescription", ad.ImageDescription);
            com.Parameters.AddWithValue("@ImagePath", ad.ImagePath);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet show_record(int sliderId)
        {
            SqlCommand com = new SqlCommand("show_record", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@sliderId",sliderId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        /// SHow data
        public DataSet Show_All_Data()
        {
            SqlCommand com = new SqlCommand("Show_All_Data", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Show_All_Featured()
        {
            SqlCommand com = new SqlCommand("Show_All_Featured", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet show_record_brand(int id)
        {
            SqlCommand com = new SqlCommand("Brand_Get", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@brandId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void add_record_brand(product p)
        {
            SqlCommand com = new SqlCommand("Insert_Data_prod", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductName", p.ProductName);
            com.Parameters.AddWithValue("@CategoryId", p.CategoryId);
            com.Parameters.AddWithValue("@IsActive", p.IsActive);
            com.Parameters.AddWithValue("@Description", p.Description);
            com.Parameters.AddWithValue("@ProductImage", p.ProductImage);
            com.Parameters.AddWithValue("@Quantity", p.Quantity);
            com.Parameters.AddWithValue("@Price", p.Price);
            com.Parameters.AddWithValue("@Featured", p.Featured);
            
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet show_All_Brand()
        {
            SqlCommand com = new SqlCommand("Show_All_Brand", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Update_Brand(product p)
        {
            SqlCommand com = new SqlCommand("Update_Brand", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", p.ProductId);
            com.Parameters.AddWithValue("@ProductName", p.ProductName);
            com.Parameters.AddWithValue("@CategoryID", p.CategoryId);
            com.Parameters.AddWithValue("@IsActive", p.IsActive);
            com.Parameters.AddWithValue("@Description", p.Description);
            com.Parameters.AddWithValue("@ProductImage", p.ProductImage);
            com.Parameters.AddWithValue("@Quantity", p.Quantity);
            com.Parameters.AddWithValue("@Price", p.Price);
            com.Parameters.AddWithValue("@Featured", p.Featured);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public DataSet show_brand_id(int pid)
        {
            SqlCommand com = new SqlCommand("recordById", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", pid);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void Delete_record(int ProductId)
        {
            SqlCommand com = new SqlCommand("Delete_Data", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", ProductId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }



        //Category
        public DataSet Show_All_Category()
        {
            SqlCommand com = new SqlCommand("Category_show_all", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet show_record_Categroy(int id)
        {
            SqlCommand com = new SqlCommand("Category_show_id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void add_record_category(Category c)
        {
            SqlCommand com = new SqlCommand("CategoryInsert", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryName", c.CategoryName);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update_Category(Category c)
        {
            SqlCommand com = new SqlCommand("CategoryUpdate", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", c.CategoryId);
            com.Parameters.AddWithValue("@CategoryName", c.CategoryName);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void Delete_Category(int CategoryId)
        {
            SqlCommand com = new SqlCommand("CategoryDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CategoryId", CategoryId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

    }
}
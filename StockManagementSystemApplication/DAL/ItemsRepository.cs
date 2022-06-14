using StockManagementSystemApplication.Modals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApplication.DAL
{
    public class ItemsRepository
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-B7EDMJ9\SQLEXPRESS;database=Stock Management System;integrated security=true");

        public bool Add(Item item)
        {
            
            string query = @"INSERT INTO Item VALUES ('" + item.ItemName + "','" + item.CategoryId + "','" + item.CompanyId + "','" + item.ReorderLevel + "')";
            SqlCommand commend = new SqlCommand(query, con);
            con.Open();
            bool isAdded = commend.ExecuteNonQuery() > 0;
            con.Close();
            return isAdded;



        }
        public DataTable GetItem(Item item)
        {

            SqlCommand command = new SqlCommand(@"Select * FROM Item", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable GetCompany(Item item)
        {

            SqlCommand command = new SqlCommand(@"Select * FROM Company", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable GetCatagory(Item item)
        {

            SqlCommand command = new SqlCommand(@"Select * FROM Category", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable SetCategoryTable(string selectedCategoryName)
        {
            SqlCommand command = new SqlCommand(@"Select * From vm_StockIn WHERE CategoryName='" + selectedCategoryName + "'", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable SetCompanyTable(string selectedCompanyName)
        {
            SqlCommand command = new SqlCommand(@"Select * From vm_StockIn WHERE CompanyName='" + selectedCompanyName + "'", con);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int GetCatagoryId(Item  item)
        {
            int itemId = 0;
            SqlCommand command = new SqlCommand(@"Select * From Category WHERE CategoryName='" + item.CategoryName + "'", con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {

                itemId = (int)dr["CategoryId"];
            }
            con.Close();
            return itemId;
        }
        public int GetCompanyId(Item  item)
        {
            int itemId = 0;
            SqlCommand command = new SqlCommand(@"Select * From Company WHERE CompanyName='" + item.CompanyName + "'", con);
            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {

                itemId = (int)dr["CompanyId"];
            }
            con.Close();
            return itemId;
        }
    }
}

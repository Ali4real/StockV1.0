using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApplication.Modals;


namespace StockManagementSystemApplication.DAL
{
    class ItemsSummeryRepository
    {

        SqlConnection connection = new SqlConnection(@"server=DESKTOP-B7EDMJ9\SQLEXPRESS;database=Stock Management System;integrated security=true");
        public DataTable GetCategoryTable(Category category)
        {
            SqlCommand command = new SqlCommand(@"Select * From Category", connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;
        }

        public DataTable GetCompanyTable(Company company)
        {
            SqlCommand command = new SqlCommand(@"Select * From Company", connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;
        }

        public DataTable SetCategoryTable(string selectedCategoryName)
        {
            SqlCommand command = new SqlCommand(@"Select * From vm_StockIn WHERE CategoryName='" + selectedCategoryName + "'", connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public DataTable SetCompanyTable(string selectedCompanyName)
        {
            SqlCommand command = new SqlCommand(@"Select * From vm_StockIn WHERE CompanyName='" + selectedCompanyName + "'", connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;
        }

        public DataTable GetDataTable(ItemsSummeryClass itemsSummeryClass)
        {
            SqlCommand command = new SqlCommand(@"Select * From vm_StockIn WHERE CompanyName='" + itemsSummeryClass.CompanyName + "'  "+itemsSummeryClass.Operation+" CategoryName='" + itemsSummeryClass.CategoryName + "'", connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;
        }

    }
}

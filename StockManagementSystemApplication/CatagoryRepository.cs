using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApplication.Modals;
using System.Data;

namespace StockManagementSystemApplication.DAL
{
    public class CatagoryRepository
    {
        SqlConnection connection = new SqlConnection(@"server=DESKTOP-75IR95H\SQLEXPRESS;database=Stock Management System;integrated security=true");
        public bool Add(Category category)
        {
         
            SqlCommand command = new SqlCommand(@"INSERT INTO Category(CategoryName) values('" + category.CategoryName + "')", connection);
            connection.Open();
            bool isAdded = command.ExecuteNonQuery() > 0;
            connection.Close();
            return isAdded;

        }
        public bool Update(Category category)
        {

            SqlCommand command = new SqlCommand(@"Update Category SET CategoryName='" + category.CategoryName + "'WHERE CategoryId='"+category.CategoryId+"'", connection);
            connection.Open();
            bool isAdded = command.ExecuteNonQuery() > 0;
            connection.Close();
            return isAdded;

        }
        public DataTable Show()
        {

            SqlCommand command = new SqlCommand(@"SELECT CategoryId SerialNo,CategoryName As Name FROM Category", connection);
            connection.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;

        }
        
    }
}

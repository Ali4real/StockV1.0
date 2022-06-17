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
    class StockInRepository
    {
        SqlConnection connection = new SqlConnection(@"server=DESKTOP-75IR95H\SQLEXPRESS;database=Stock Management System;integrated security=true");
        public DataTable GetCategoryTable(Category category)
        {
            SqlCommand command = new SqlCommand(@"Select * From Category",connection);
            connection.Open();
            DataTable dt=new DataTable();
            SqlDataAdapter da=new SqlDataAdapter(command);
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

        public DataTable GetItemTable(Item item)
        {
            SqlCommand command = new SqlCommand(@"Select * From Item", connection);
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
        public DataTable SetCompanyTable(string selectedCompanyName,string selectedCategoryName)
        {
            SqlCommand command = new SqlCommand(@"Select *  From vm_StockIn WHERE CompanyName='" + selectedCompanyName + "' AND CategoryName='" + selectedCategoryName + "'", connection);
         //   SqlCommand command2 = new SqlCommand(@"Select Distinct CompanyName From vm_StockIn WHERE CompanyName='" + selectedCompanyName + "' AND CategoryName='" + selectedCategoryName + "'",connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
          //  DataTable dt2=new DataTable();
          //  SqlDataAdapter da2=new SqlDataAdapter(command2);
          //  da2.Fill(dt2);
            connection.Close();
            return dt;
        }
        public DataTable SetCompany(string selectedCategoryName)
        {
            SqlCommand command = new SqlCommand(@"Select DISTINCT CompanyName From vm_StockIn WHERE CategoryName='" + selectedCategoryName + "'", connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public DataTable SetItemTable(string selectedItemName)
        {
            SqlCommand command = new SqlCommand(@"Select * From vm_StockIn WHERE ItemName='" + selectedItemName + "'", connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;
        }
        public bool Update(StockInClass stockIn)
        {
            bool isUpdated;
            SqlCommand command = new SqlCommand(@"SELECT * FROM Transanction
INNER JOIN Item On Item.ItemId=Transanction.ItemId
 WHERE Item.ItemName='" + stockIn.ItemName + "'", connection);
            connection.Open();
          //  SqlDataAdapter da = new SqlDataAdapter(command);
            SqlDataReader dr = command.ExecuteReader();
            
            if (dr.HasRows)
            {
                connection.Close();
                connection.Open();
                SqlCommand command2 = new SqlCommand(@"Update Transanction Set AvailableQuantity='" + stockIn.AvailableQuantity + "'Where ItemId='" + stockIn.ItemId + "'", connection);
                isUpdated = command2.ExecuteNonQuery() > 0;
            }
            else
            {
                connection.Close();
                connection.Open();
                SqlCommand command2 = new SqlCommand(@"INSERT INTO Transanction(ItemId,AvailableQuantity) values('" + stockIn.ItemId + "','" + stockIn.AvailableQuantity + "')", connection);
                isUpdated = command2.ExecuteNonQuery() > 0;
            }
            connection.Close();
            return isUpdated;
        }

        public int GetItemId(StockInClass stockIn)
        {
            int itemId=0;
             SqlCommand command = new SqlCommand(@"Select ItemId From Item WHERE ItemName='"+stockIn.ItemName+"'",connection);
            connection.Open();
           SqlDataReader dr=command.ExecuteReader();
            if (dr.Read())
            {

               itemId = (int) dr["ItemId"];
            }
            connection.Close();
            return itemId;
        }
    }
}

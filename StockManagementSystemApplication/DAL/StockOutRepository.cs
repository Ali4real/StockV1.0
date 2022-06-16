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
    class StockOutRepository
    {

        SqlConnection connection = new SqlConnection(@"server=DESKTOP-75IR95H\SQLEXPRESS;database=Stock Management System;integrated security=true");
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
        public DataTable SetCompanyTable(string selectedCompanyName, string selectedCategoryName)
        {
            SqlCommand command = new SqlCommand(@"Select * From vm_StockIn WHERE CompanyName='" + selectedCompanyName + "'  AND CategoryName='"+selectedCategoryName+"'", connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
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

        public bool AddStockOut(List<string> gridViewData)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO [Stock Out](ItemId,StockOutQuantity,StockOutType,Date) values('" + Convert.ToInt32(gridViewData[4]) + "','" + gridViewData[3] + "','" + gridViewData[5] + "',GETDATE())", connection);
            connection.Open();
            bool isAdded = command.ExecuteNonQuery() > 0;
            connection.Close();
            return isAdded;
        }


        public bool UpdateTable(List<string> gridViewData)
        {
            SqlCommand command = new SqlCommand(@"Update Transanction Set AvailableQuantity-='" + Convert.ToInt64(gridViewData[3]) + "' WHERE ItemId='"+Convert.ToInt32(gridViewData[4])+"'", connection);

            connection.Open();
            bool isUpdated = command.ExecuteNonQuery() > 0;
            connection.Close();
            return isUpdated;

        }



//        public bool  AddStockOut(List<string> gridViewData)
//        {
//            bool isUpdated;
//            SqlCommand command = new SqlCommand(@"SELECT * FROM [Stock Out]
//        
//         WHERE ItemId='" + Convert.ToInt32(gridViewData[4]) + "'", connection);
//            connection.Open();
//            //  SqlDataAdapter da = new SqlDataAdapter(command);
//            SqlDataReader dr = command.ExecuteReader();

//            if (dr.HasRows)
//            {
//                connection.Close();
//                connection.Open();
//                SqlCommand command2 = new SqlCommand(@"Update [Stock Out] Set StockOutQuantity+='" + Convert.ToInt64(gridViewData[3]) + "' WHERE ItemId='" + Convert.ToInt32(gridViewData[4]) + "'", connection);
//                isUpdated = command2.ExecuteNonQuery() > 0;
//            }
//            else
//            {
//                connection.Close();
//                connection.Open();
//                SqlCommand command2 = new SqlCommand(@"INSERT INTO [Stock Out](ItemId,StockOutQuantity,StockOutType,Date) values('" + Convert.ToInt32(gridViewData[4]) + "','" + gridViewData[3] + "','" + gridViewData[5] + "',GETDATE())", connection);
//                isUpdated = command2.ExecuteNonQuery() > 0;
//            }
//            connection.Close();
//            return isUpdated;
//        }

        public int GetItemId(string ItemName)
        {
            int itemId = 0;
            SqlCommand command = new SqlCommand(@"Select ItemId From Item WHERE ItemName='" + ItemName + "'", connection);
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {

                itemId = (int)dr["ItemId"];
            }
            connection.Close();
            return itemId;
        }
        
    }
}

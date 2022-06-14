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
    class SalesDatesRepository
    {
        SqlConnection connection = new SqlConnection(@"server=DESKTOP-B7EDMJ9\SQLEXPRESS;database=Stock Management System;integrated security=true");
        public DataTable GetSalesReport(SalesDatesClass salesDatesClass)
        {
            SqlCommand command = new SqlCommand(@"Select i.ItemName AS Item,Sum(s.StockOutQuantity) AS Quantity From [Stock Out] s
Inner Join Item i On i.ItemId=s.ItemId
WHERE Date Between '" + salesDatesClass.FromDateTime + "' AND '" + salesDatesClass.ToDateTime + "' AND StockOutType='Sell' Group By i.ItemName ORDER BY Item DESC", connection);
           
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;
        }

    }
}

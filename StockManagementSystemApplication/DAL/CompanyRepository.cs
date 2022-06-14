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
    public class CompanyRepository
    {
        SqlConnection connection = new SqlConnection(@"server=DESKTOP-B7EDMJ9\SQLEXPRESS;database=Stock Management System;integrated security=true");
        public bool Add(Company company)
        {
           
            SqlCommand command = new SqlCommand(@"INSERT INTO Company(CompanyName) values('" + company.CompanyName + "')", connection);
            connection.Open();
            bool isAdded = command.ExecuteNonQuery() > 0;
            connection.Close();
            return isAdded;

        }
        public DataTable Show()
        {

            SqlCommand command = new SqlCommand(@"SELECT CompanyId SerialNo,CompanyName Name  FROM Company", connection);
            connection.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            connection.Close();
            return dt;

        }
    }
}

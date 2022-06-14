using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApplication.Modals;

namespace StockManagementSystemApplication.DAL
{
    class RegisterRepository
    {
        SqlConnection connection = new SqlConnection(@"server=DESKTOP-B7EDMJ9\SQLEXPRESS;database=Stock Management System;integrated security=true");
       
        public bool Add(RegistrationInformation registrationInformation)
        {

            SqlCommand command = new SqlCommand(@"INSERT INTO UserInformation values('" + registrationInformation.Username + "','" + registrationInformation.Password + "','" + registrationInformation.FirstName + "','" + registrationInformation.LastName + "','" + registrationInformation.Email + "')", connection);
            connection.Open();
            bool isAdded = command.ExecuteNonQuery() > 0;
            connection.Close();
            return isAdded;

        }
        public bool Check(string userName)
        {

            SqlCommand command = new SqlCommand(@"Select * FROM UserInformation WHERE UserName='" + userName + "'", connection);
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;

        }

    }
}

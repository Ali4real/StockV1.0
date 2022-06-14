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
    public class LogInPageRepository
    {
        public bool Check(LogInPageClass login)
        {
            SqlConnection con = new SqlConnection(@"server=DESKTOP-B7EDMJ9\SQLEXPRESS;database=Stock Management System;integrated security=true");
            string query = @"SELECT Count(*) FROM UserInformation Where [UserName]='" + login.Username + "' and [Password]='" + login.Password + "'";
            con.Open();            
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bool isAdded =dt.Rows[0][0].ToString() == "1";
            con.Close();
            return isAdded;
            
            

        }

        
    }
}

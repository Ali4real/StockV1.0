using StockManagementSystemApplication.DAL;
using StockManagementSystemApplication.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApplication.BLL
{
    
    public class LogInPageManager
    {   
        LogInPageRepository loginrepo = new LogInPageRepository();
        public bool Check(LogInPageClass login)
        {
            bool isAdded = loginrepo.Check(login);
            return isAdded;

        }
        
    }
}

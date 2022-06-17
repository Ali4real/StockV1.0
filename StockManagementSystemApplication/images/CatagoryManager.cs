using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApplication.DAL;
using StockManagementSystemApplication.Modals;
using System.Data;
using System.Text.RegularExpressions;

namespace StockManagementSystemApplication.BLL
{

  
    public  class CatagoryManager
    {
        CatagoryRepository categorySetupRepository = new CatagoryRepository();
        public static Regex regex = new Regex(@"[A-Za-z]");
        public bool Add(Category category)
        {
            bool isAdded = false;
             if (category.CategoryId == 0)
                {
                   DataTable dt=categorySetupRepository.Show();
                    foreach (DataRow check in dt.Rows)
                    {
                        if (check["Name"].ToString() == category.CategoryName)
                        {
                            return false;
                        }
                    }

                    isAdded = categorySetupRepository.Add(category);
                }
                else
                {
                    isAdded = categorySetupRepository.Update(category);
                }
            return isAdded;
        }

        public bool Validation(string categoryName)
        {
            if (regex.IsMatch(categoryName))
            {
                return true;
            }
            return false;
        }

        public DataTable Show()
        {
            DataTable dt = categorySetupRepository.Show();
            return dt;
        }
    }
}

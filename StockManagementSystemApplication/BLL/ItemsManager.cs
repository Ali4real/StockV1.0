using StockManagementSystemApplication.DAL;
using StockManagementSystemApplication.Modals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystemApplication.BLL
{
    public class ItemsManager
    {
        ItemsRepository itemsRepository = new ItemsRepository();
        public static Regex regex = new Regex(@"[A-Za-z \D]");
        public bool Add(Item item)
        {
            DataTable dt = itemsRepository.GetItem(item);
            foreach (DataRow check in dt.Rows)
            {
                if (check["ItemName"].ToString() == item.ItemName)
                {
                    return false;
                }
            }
           if ((item.ItemName == null && item.ItemName.Length > 3))
            {
                throw new Exception("Invalied Item name");
            }
            if (item.CategoryId < 1)
            {
                throw new Exception("Select a Catagory");
            }
            if (item.CompanyId < 1)
            {
                throw new Exception("Select a Company");
            }
           
            bool isAdded = itemsRepository.Add(item);
            return isAdded;

        }
        public DataTable GetCompany(Item item)
        {
            DataTable dt = new DataTable();
            dt = itemsRepository.GetCompany(item);
            return dt;
        }
        public DataTable GetCatagory(Item item)
        {
            DataTable dt = new DataTable();
            dt = itemsRepository.GetCatagory(item);
            return dt;
        }
        public DataTable SetCategoryTable(string selectedCategoryName)
        {
            DataTable dt = new DataTable();
            dt = itemsRepository.SetCategoryTable(selectedCategoryName);
            return dt;
        }
        public DataTable SetCompanyTable(string selectedCompanyName)
        {
            DataTable dt = new DataTable();
            dt = itemsRepository.SetCompanyTable(selectedCompanyName);

            return dt;
        }
        public int GetCatagoryId(Item  item)
        {
            int itemId = itemsRepository.GetCatagoryId(item);
            return itemId;
        }
        public int GetCompanyId(Item  item)
        {
            int itemId = itemsRepository.GetCompanyId(item);
            return itemId;
        }

        public  bool Validation(string reorderLevel)
        {
            if (regex.IsMatch(reorderLevel))
            {
                return false;
            }
            return true;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StockManagementSystemApplication.DAL;
using StockManagementSystemApplication.Modals;


namespace StockManagementSystemApplication.BLL
{
    class StockOutManager
    {
        public static Regex regex = new Regex(@"\D");
        StockOutRepository stockOutRepository = new StockOutRepository();
        public DataTable GetCategoryTable(Category category)
        {
            DataTable dt = stockOutRepository.GetCategoryTable(category);
            return dt;
        }
        public DataTable GetCompanyTable(Company company)
        {
            DataTable dt = stockOutRepository.GetCompanyTable(company);
            return dt;
        }
        public DataTable GetItemTable(Item item)
        {
            DataTable dt = stockOutRepository.GetItemTable(item);
            return dt;
        }
        public DataTable SetCategoryTable(string selectedCategoryName)
        {
            DataTable dt = new DataTable();
            dt = stockOutRepository.SetCategoryTable(selectedCategoryName);
            return dt;
        }
        public DataTable SetCompanyTable(string selectedCompanyName, string selectedCategoryName)
        {
            DataTable dt = new DataTable();
            dt = stockOutRepository.SetCompanyTable(selectedCompanyName,selectedCategoryName);

            return dt;
        }
        public DataTable SetItemTable(string selectedItemName)
        {
            DataTable dt = new DataTable();
            dt = stockOutRepository.SetItemTable(selectedItemName);
            return dt;
        }

        public bool AddStockOut(List<string>gridViewData)
        {
           bool  isAdded= stockOutRepository.AddStockOut(gridViewData);
            return isAdded;
        }


        //public bool StockOutDataAdded(StockOutClass stockOut)
        //{
        //    bool isAdded = stockOutRepository.StockOutDataUpdated(stockOut);
        //    return isAdded;
        //}








      public bool UpdateTable(List<string> gridViewData)
      {
          bool  isUpdated= stockOutRepository.UpdateTable(gridViewData);
          return isUpdated;
      }

       public int GetItemId(string ItemName)
       {
            int itemId = stockOutRepository.GetItemId(ItemName);
            return itemId;
        }

       public DataTable SetCompany(string selectedCategoryName)
       {
           DataTable dt = new DataTable();
           dt = stockOutRepository.SetCompany(selectedCategoryName);

           return dt;
       }
        public bool Validation(string stockOutQuantity)
        {
            if (regex.IsMatch(stockOutQuantity))
            {
               return false;
            }
            return true;
        }
    }
}

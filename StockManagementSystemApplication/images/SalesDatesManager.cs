using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystemApplication.DAL;
using StockManagementSystemApplication.Modals;

namespace StockManagementSystemApplication.BLL
{
    class SalesDatesManager
    {
        SalesDatesRepository salesDatesRepository=new SalesDatesRepository();

        public DataTable GetSalesReport(SalesDatesClass salesDatesClass)
        {
            DataTable dt=new DataTable();
            dt=salesDatesRepository.GetSalesReport(salesDatesClass);
            return dt;
        }

    }
}

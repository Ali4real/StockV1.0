using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApplication.Modals
{
    class SalesDatesClass
    {
        public DateTime FromDateTime{ get; set; }
        public DateTime ToDateTime { get; set; }
        public string ItemName { get; set; }
        public long StockOutQuantity { get; set; }

    }
}

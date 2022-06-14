using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApplication.Modals
{
    class StockOutClass
    {
      
        public int ItemId { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; } 
        public int TransanctionId { get; set; }
        public string ItemName { get; set; }
        public long ReorderLevel { get; set; }
        public long Quantity { get; set; }
        public string StockOutType { get; set; }
        public DateTime Date { get; set; }
    }
}

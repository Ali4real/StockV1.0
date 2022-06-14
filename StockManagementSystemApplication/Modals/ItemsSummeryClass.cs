using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApplication.Modals
{
    class ItemsSummeryClass
    {
        public int CaegoryId { get; set; }
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public long ReorderLevel { get; set; }
        public long AvailableQuantity { get; set; }
        public string Operation { get; set; }   
    }
}

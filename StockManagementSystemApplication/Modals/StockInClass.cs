using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystemApplication.Modals
{
    public class StockInClass
    {
        
        public long ItemId { get; set; }
        public string ItemName { get; set; }
      //  public string ItemName { get; set; }
        public long AvailableQuantity { get; set; }
        public long StockInQuantity { get; set; }   
    }
}

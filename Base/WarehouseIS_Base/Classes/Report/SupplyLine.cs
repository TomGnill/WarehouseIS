using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseIS_Base.Classes.Report
{
    public class SupplyLine : ReportLine
    {
        public double Price { get; set; }
        public int Amount { get; set; }
        public SupplyLine(double price, int amount, Item.Item item) : base(item)
        {
            Price = price;
            Amount = amount;
        }
    }
}

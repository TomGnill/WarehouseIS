using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseIS_Base.Classes.Report
{
    public class SaleLine : ReportLine
    {
        public double BuyPrice { get; set; }
        public double SalePrice { get; set; }
        public int Amount { get; set; }

        public SaleLine(Item.Item item, double buyPrice, double salePrice, int amount) : base(item)
        {
            BuyPrice = buyPrice;
            SalePrice = salePrice;
            Amount = amount;
        }

    }

}

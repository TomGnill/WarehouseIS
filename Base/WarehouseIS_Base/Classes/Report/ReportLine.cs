using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseIS_Base.Classes.Report
{
    public class ReportLine
    {
        public Item.Item Item {  get; set; }

        public ReportLine(Item.Item item)
        {
            Item = item;
        }
    }
}

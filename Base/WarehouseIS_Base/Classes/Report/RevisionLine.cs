using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseIS_Base.Classes.Report
{
    public class RevisionLine : ReportLine
    {
        public int Amount { get; set; }

        public RevisionLine(Item.Item item) : base(item)
        {
            Amount = item.Count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseIS_Base.Classes.User
{
    public class Deliveryman : User
    {
        public Deliveryman(int id, string name) : base(id, name)
        { }

        public Report.Report CreateReport(List<Item.Item> items)
        {
            Report.Report report = new Report.Report(Report.ReportType.Delivered);
            
            foreach (Item.Item item in items)
            {
                var line = new Report.SaleLine(item, item.BuyPrice, item.Price, item.Count);
                report.AddLine(line);
            }
            report.Save();
            return report;
        }
    }
}

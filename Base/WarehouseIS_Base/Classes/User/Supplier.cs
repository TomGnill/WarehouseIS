using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseIS_Base.Classes.Report;

namespace WarehouseIS_Base.Classes.User
{
    public class Supplier : User
    {
        public Supplier(int id, string name) : base(id, name)
        { }

        public Report.Report Revision(DateTime dateTime)
        {
            var report = new Report.Report(Report.ReportType.Revision);
            var itemList = DBsimulation.Items.Where(s => (DateTime.Now - s.BuyDate).Days > 14).ToList();
            foreach (var line in itemList.Select(item => new RevisionLine(item)))
            {
                report.AddLine(line);
            }
            report.Save();
            return report;

        }
        public Report.Report Supply(List<Item.Item> items)
        {
            var report = new Report.Report(ReportType.Supply);
            foreach (var line in items.Select(item => new SupplyLine(item.Price, item.Count, item)))
            {
                report.AddLine(line);
            }
            report.Save();
            return report;

        }
    }
}

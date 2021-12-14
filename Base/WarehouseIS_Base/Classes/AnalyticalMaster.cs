using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseIS_Base.Classes.Report;

namespace WarehouseIS_Base.Classes
{
    public static class AnalyticalMaster
    {
        private static List<ReportLine> Lines { get; } = new List<ReportLine>();
        private static string itemsDescription { get; set; } = String.Empty;

        private static string incomeDescription { get; set; } = "\n";
        public static Report.Report CompileStatistics(List<Report.Report> reports)
        {
            itemsDescription = String.Empty;
            incomeDescription = String.Empty;
            foreach (var report in reports)
            {
                Lines.AddRange(report.Lines);
            }

            ItemsStats();
            incomeDescription += $"\n получен доход: {IncomeStats()}";

            var newReport = new Report.Report(ReportType.None);
            newReport.AddLine(Lines);
            newReport.AddDescription(itemsDescription + "\n" + itemsDescription);
            return newReport;
        }

        private static void ItemsStats()
        {
            List<Item.Item> items = new List<Item.Item>();
            foreach (var line in Lines)
            {
                if (line.GetType() == typeof(SaleLine))
                {
                    var seline = (SaleLine)line;
                    itemsDescription +=
                        $"\n {seline.Item.Name} в количестве {seline.Amount} на сумму {seline.SalePrice * seline.Amount}(куплено {seline.BuyPrice} за шт.)";
                    items.Add(new Item.Item(seline.Item.Id,seline.Item.Name, seline.SalePrice, seline.BuyPrice, seline.Amount));
                }
                if (line.GetType() == typeof(SupplyLine))
                {
                    var supLine = (SupplyLine)line;
                    itemsDescription += $"\n товар {supLine.Item.Name} был доставлен в кол-ве {supLine.Amount}";
                    items.Add(new Item.Item(supLine.Item.Id, supLine.Item.Name, supLine.Item.Price, supLine.Item.BuyPrice, supLine.Amount));

                }
                if (line.GetType() == typeof(RevisionLine))
                {
                    var revLine = (RevisionLine)line;
                    itemsDescription += $"\n товар {revLine.Item.Name} был удалён со склада";
                    items.Add(new Item.Item(revLine.Item.Id, revLine.Item.Name, revLine.Item.Price, revLine.Item.BuyPrice, revLine.Amount));
                }

            }
        }

        private static double IncomeStats()
        {
            double income = 0;
            foreach (var line in Lines)
            {
                if (line.GetType() == typeof(SaleLine))
                {
                    var seline = (SaleLine)line;
                    income += seline.SalePrice*seline.Amount;
                }
            }

            
            return income;
        }
    }
}

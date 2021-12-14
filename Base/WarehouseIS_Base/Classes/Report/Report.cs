using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseIS_Base.Classes.Report
{
    public class Report
    {
        public string Description { get; set; }
        public List<Report> Reports { get; set; }
        public ReportType Type { get; set; }

        public DateTime CreateTime { get; set; }

        public List<ReportLine> Lines { get; set; }

        public Report(ReportType type)
        {
            Type = type;
            CreateTime = DateTime.Now;
            Lines = new List<ReportLine>();
            Reports = new List<Report>();
            Description = string.Empty;
        }

        public void AddLine(ReportLine line)
        {
            Lines.Add(line);
        }
        public void AddLine(List<ReportLine> line)
        {
            Lines.AddRange(line);
        }
        public void DelLine(int index)
        {
            Lines.RemoveAt(index);
        }

        public void AddDescription(string descr)
        {
            Description = Description;
        }

        public void AddReports(List<Report> reports)
        {
            Reports.AddRange(reports);
        }

        public void Save()
        {
            DBsimulation.Reports.Add(this);
        }
        public override string ToString()
        {
            string report = string.Empty;
            report += $"\nДата создания:{this.CreateTime}";
            report += $"\nТип:{this.Type}";
            report += $"\nОписание:{this.Description}";
            report += $"\nЗатронутые товары:";
            foreach(ReportLine line in Lines)
            {
                report += $"\nid:{line.Item.Id}, {line.Item.Name}, цена:{line.Item.Price}";
            }

            if (Type == ReportType.Period)
            {
                double salesPeriod = 0;
                double buyPeriod = 0;
                double income = 0;
                foreach (ReportLine line in Lines)
                {
                    if(line is SaleLine)
                    {
                        var selLine = (SaleLine)line;
                        salesPeriod += selLine.SalePrice * selLine.Amount;
                        buyPeriod += selLine.BuyPrice * selLine.Amount;
                    }
                }
                income = salesPeriod - buyPeriod;

                report += $"\nЗатраты:{buyPeriod}";
                report += $"\nВыручка:{salesPeriod}";
                report += $"\nЧистый доход:{income}";

                return report; 
            }

            if (Type == ReportType.Supply)
            {
                double buyPeriod = 0;
                foreach (ReportLine line in Lines)
                {
                    if (line is SupplyLine)
                    {
                        var buyLine = (SupplyLine)line;
                        buyPeriod += buyLine.Price * buyLine.Amount;
                    }
                }
                report += $"\nЗатраты:{buyPeriod}";
                return report;
            }

            if (Type == ReportType.Revision)
            {
                double allAmount = 0;
                foreach (ReportLine line in Lines)
                {
                    if (line is RevisionLine)
                    {
                        var revLine = (RevisionLine)line;
                        allAmount += revLine.Amount;
                    }
                }
                report += $"\nОбщее кол-во:{allAmount}";
                return report;
            }

            if (Type == ReportType.Delivered)
            {
                report += $"\nБыли доставлены";
                return report;
            }
            return base.ToString();
        }
    }
}

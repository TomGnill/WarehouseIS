using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseIS_Base.Classes.Report;

namespace WarehouseIS_Base.Classes.User
{
    public class Booker : User
    {
        public Booker(int id, string name) : base(id, name)
        { }

        public Report.Report PeriodReport(DateTime from, DateTime to)
        {
            var perReports = DBsimulation.Reports.Where(s => s.CreateTime < to && s.CreateTime > from).ToList();
            var report = new Report.Report(ReportType.Period);
            report.AddReports(perReports);
            foreach (var preport in perReports)
            {
                report.AddLine(preport.Lines);
            }

            return report;
        }
    }
}

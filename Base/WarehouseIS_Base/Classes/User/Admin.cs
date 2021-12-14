using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseIS_Base.Classes.User
{
    public class Admin : User
    {
        public Admin(int id, string name) : base(id, name)
        { }

        public List<Report.Report> CheckReports(DateTime date)
        {
            return DBsimulation.Reports.Where(s => s.CreateTime > date).ToList();
        }

        public Report.Report InitAnalysis(DateTime date)
        {
            return AnalyticalMaster.CompileStatistics(CheckReports(date));
        }
    }
}

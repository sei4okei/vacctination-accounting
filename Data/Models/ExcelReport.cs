using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseproject.Data.Models
{
    public class ExcelReport
    {
        public List<Drug> DrugList { get; set; } 
        public List<int> DrugUsageList { get; set; }

        public List<Region> RegionList { get; set; }
        public List<int> RegionUsageList { get; set; }

        public List<View> ViewList { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static ExcelReport GetReport()
        {
            ExcelReport report = new ExcelReport();

            using (VacctinationAccountingDb db = new VacctinationAccountingDb())
            {
                report.StartDate = db.Report.First().StartDate;
                report.EndDate = db.Report.First().EndDate;


                string[] str;
                DateTime vaccinedate;
                report.ViewList = new List<View>();
                foreach (var item in View.GetList())
                {
                    str = item.VacctinationDate.Split('.');
                    vaccinedate = new DateTime(int.Parse(str[2]), int.Parse(str[1]), int.Parse(str[0]));

                    if (vaccinedate > report.StartDate && vaccinedate < report.EndDate)
                    {
                        report.ViewList.Add(item);
                    }
                }

                report.DrugUsageList = new List<int>();

                report.DrugList = db.Drug.ToList();
                foreach (var drug in report.DrugList)
                {
                    report.DrugUsageList.Add(db.PatientReception.Count(d => d.DrugId == drug.Id));
                }

                report.RegionUsageList = new List<int>();

                report.RegionList = db.Region.ToList();
                foreach (var region in report.RegionList)
                {
                    report.RegionUsageList.Add(report.ViewList.Count(o => o.Region == region.Id));
                }

            }

            return report;
        }

    }
}

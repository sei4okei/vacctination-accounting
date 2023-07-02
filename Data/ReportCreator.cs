using courseproject.Data.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseproject.Data
{
    internal class ReportCreator
    {
        public byte[] Create(ExcelReport report)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            var package = new ExcelPackage();

            var sheet = package.Workbook.Worksheets.Add("Отчет Вакцианции");

            sheet.Cells["A1"].Value = report.StartDate;
            sheet.Cells["B1"].Value = " - ";
            sheet.Cells["C1"].Value = report.EndDate;

            sheet.Cells[10, 2].Value = "Использование привки:";
            sheet.Cells[10, 6].Value = "Обращений с участков:";

            sheet.Cells[11, 2, 11, 3].LoadFromArrays(new object[][] { new[] { "Название прививки", "Кол-во использований" } });
            sheet.Cells[11, 2, 11 + report.DrugList.Count, 13].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
            sheet.Cells[11, 2, 11, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[11, 6, 11, 7].LoadFromArrays(new object[][] { new[] { "Номер участка", "Кол-во обращений" } });
            sheet.Cells[11, 6, 11 +report.RegionList.Count, 7].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
            sheet.Cells[11, 6, 11, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


            int row = 12;
            int col = 2;

            for (int i = 0; i < report.DrugList.Count; i++)
            {
                sheet.Cells[row, col].Value = report.DrugList[i].Name;
                sheet.Cells[row, col + 1].Value = report.DrugUsageList[i];


                sheet.Cells[row, col + 4].Value = report.RegionList[i].Id;
                sheet.Cells[row, col + 5].Value = report.RegionUsageList[i];

                row++;
            }

            sheet.Cells[11, 10, 11, 15].LoadFromArrays(new object[][] { new[] { "ФИО", "Привика", "Дата прививки", "Участок", "ФИО доктора" } });
            sheet.Cells[11, 10, 11 + report.ViewList.Count, 15].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Double);
            sheet.Cells[11, 10, 11, 15].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            row = 12;
            col = 10;

            foreach (var item in report.ViewList)
            {
                sheet.Cells[row, col].Value = item.AllName;
                sheet.Cells[row, col + 1].Value = item.DrugName;
                sheet.Cells[row, col + 2].Value = item.VacctinationDate;
                sheet.Cells[row, col + 3].Value = item.Region;
                sheet.Cells[row, col + 4].Value = item.DoctorAllName;
            }

            return package.GetAsByteArray();
        }
    }
}

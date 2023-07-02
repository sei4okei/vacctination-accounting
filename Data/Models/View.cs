using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace courseproject.Data.Models
{
    public class View
    {
        public int Id { get; set; }
        public string AllName { get; set; }
        public string DrugName { get; set; }
        public string VacctinationDate { get; set; }
        public int Region { get; set; }
        public string DoctorAllName { get; set; }

        public static List<View> GetList()
        {
            VacctinationAccountingDb db = new VacctinationAccountingDb();

            List<View> list = new List<View>() { };
            List<PatientReception> patientReceptions = db.PatientReception.ToList();

            foreach (var record in patientReceptions)
            {
                var patient = db.Patient.FirstOrDefault(x => x.Id == record.PatientId);
                var drug = db.Drug.FirstOrDefault(x => x.Id == record.DrugId);
                var region = db.Region.FirstOrDefault(x => x.Id == patient.RegionId);
                var employee = db.Employee.FirstOrDefault(x => x.Id == record.EmployeeId);

                list.Add(new View
                {
                    Id = record.Id,
                    AllName = patient.LastName + " " + patient.FirstName + " " + patient.MiddleName,
                    DrugName = drug.Name,
                    VacctinationDate = record.Date.ToShortDateString(),
                    Region = region.Id,
                    DoctorAllName = employee.SecondName + " " + employee.FirstName.Substring(0, 1) + "." + employee.MiddleName.Substring(0, 1) + "."
                });
            }
            
            return list;
        }
    }
}

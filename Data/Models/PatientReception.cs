using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseproject.Data.Models
{
    internal class PatientReception
    {
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("Drug")]
        public int DrugId { get; set; }
        [ForeignKey("DrugId")]
        public Drug Drug { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseproject.Data.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dosage { get; set; }
        public string Contraindicators { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

using courseproject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseproject.Data
{
    internal class VacctinationAccountingDb : DbContext
    {
        public DbSet<Account> Account { get; set;}
        public DbSet<Drug> Drug { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientReception> PatientReception { get; set; }
        public DbSet<Region> Region { get; set; }

        public VacctinationAccountingDb()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=228322Qw;Database=vacctinationaccounting;");
        }
    }
}

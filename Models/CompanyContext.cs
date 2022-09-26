using System;
using System.Data.Entity;
using System.Linq;

namespace WebAPI.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext()
            : base(@"Data source = SABER;Initial catalog = companyDBase;Integrated security = true")
        {
        }

       
        public virtual DbSet<Employee> Employees { get; set; }
    }

 
}
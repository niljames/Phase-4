using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Employee> tblEmployees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuring Connection String.
            optionsBuilder.UseSqlServer("Server=H5CG125CX26;Database=EmployeeDB;Integrated Security=true");
        }
    }
}

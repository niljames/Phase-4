using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public float EmployeeSalary { get; set; }
    }
}

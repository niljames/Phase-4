using System;
using System.Collections.Generic;

namespace EmployeeServices.Models
{
    public partial class TblEmployees
    {
        public int Id { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? Salary { get; set; }
    }
}

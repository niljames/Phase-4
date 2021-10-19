using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeServices.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        EmployeeDBContext emp = new EmployeeDBContext();
        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<TblEmployees> Get()
        {
            return emp.TblEmployees.ToList();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public TblEmployees Get(int id)
        {
            return emp.TblEmployees.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] TblEmployees value)
        {
            emp.TblEmployees.Add(value);
            emp.SaveChanges();
        }

        // PUT api/<EmployeesController>/5
        //[HttpPut("{id}")]
        public void Put([FromBody] TblEmployees value)
        {
          
            emp.TblEmployees.Update(value);
            emp.SaveChanges();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employee = emp.TblEmployees.Find(id);

            emp.TblEmployees.Remove(employee);
            emp.SaveChanges();
        }
    }
}

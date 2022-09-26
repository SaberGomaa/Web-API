using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {

        public static List<Employee> employees { get; set; } = new List<Employee>
        {
            new Employee{Id = 12 , Name = "saber"},
            new Employee{Id = 13 , Name = "maher"},
            new Employee{Id = 14 , Name = "ahmed"}
        };


        [Route("api/emps")]
        [HttpGet]
        public List<Employee> AllEmployees()
        {
            return employees;
        }
        
        [HttpGet]
        [Route("api/emps/{id:int}")]
        public Employee employeeById(int id)
        {
            return employees.FirstOrDefault(e=>e.Id == id);
        }

        [HttpGet]
        [Route("api/emps/{name:alpha}")]
        public Employee employeeByName(string name)
        {
            return employees.FirstOrDefault(e => e.Name.ToLower() == name.ToLower());
        }

    }
}

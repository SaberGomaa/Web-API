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

        public List<Employee> getemployees()
        {
            return new List<Employee> { 
                new Employee{Id = 12 , Name = "saber"},
                new Employee{Id = 13 , Name = "maher"},
                new Employee{Id = 14 , Name = "ahmed"}
            };
        }
    }
}

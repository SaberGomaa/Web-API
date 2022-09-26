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
        CompanyContext db;

        public EmployeeController()
        {
            db = new CompanyContext();
        }

        public List<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }

    }
}

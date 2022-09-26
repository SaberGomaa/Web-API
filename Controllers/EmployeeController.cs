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

        public IHttpActionResult GetEmployees()
        {
            return Ok(db.Employees.ToList());
        }

        public IHttpActionResult GetEmployeeById(int id)
        {
            var emp = db.Employees.Find(id);

            if(emp is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
        }

        public IHttpActionResult GetEmployeeByName(string Name)
        {
            var emp = db.Employees.FirstOrDefault(e=>e.Name.ToLower() == Name.ToLower());

            if (emp is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
        }

        public IHttpActionResult PostEmployee(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Employee is Not Valid !");
            }
            
            db.Employees.Add(emp);

            try
            {
                db.SaveChanges();
            }
            catch(Exception)
            {
                if (foundEmp(emp.Id))
                {
                    return Conflict();
                }
                throw;
            }
            // success
            //return Ok();
            //return Ok(emp);           //  200

            //return Created("",emp);     //  201

            return CreatedAtRoute("DefaultApi", new {id = emp.Id},emp);
        }


        // fn to check if emp is found in DB 

        public bool foundEmp(int id)
        {
            if(db.Employees.Any(e=>e.Id == id)) return true;
            else return false;
        }

        public IHttpActionResult DeleteEmployee(int id)
        {
            var emp = db.Employees.Find(id);

            if(emp is null)
            {
                return NotFound();
            }
            db.Employees.Remove(emp);
            db.SaveChanges();
            return Ok(emp);
        }
    }
}

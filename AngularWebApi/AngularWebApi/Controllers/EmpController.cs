using AngularWebApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class EmpController : ControllerBase
    {
        private readonly DatabaseContext context;

        public EmpController(DatabaseContext _context)
        {
            this.context = _context;
        }

       [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
             return Ok(context.Employees.ToList<Employee>());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee=context.Employees.FirstOrDefault<Employee>(a=>a.id==id);
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut]
        public ActionResult<Employee> Put(Employee employee)
        {
            var employeeInDb= context.Employees.FirstOrDefault<Employee>(a => a.id ==employee.id);
            employeeInDb.name = employee.name;
            employeeInDb.email = employee.email;
            employeeInDb.password = employee.password;
            context.SaveChanges();
            return Ok(employee);
        }


        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(int id)
        {
            var employeeInDb = context.Employees.FirstOrDefault<Employee>(a=>a.id==id);
            context.Remove<Employee>(employeeInDb);
            context.SaveChanges();
            return Ok(employeeInDb);
        }
    }
}

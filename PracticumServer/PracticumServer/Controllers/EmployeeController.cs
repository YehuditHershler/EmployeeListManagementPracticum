using Microsoft.AspNetCore.Mvc;
using PracticumServer.Core.DTOs;
using PracticumServer.Core.Entities;
using PracticumServer.Core.Services;

namespace PracticumServer.API.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_employeeService.GetById(id));
        }
        //[HttpGet]
        //public List<Employee> Get()
        //{
        //    return employees;
        //}

        //[HttpGet("{id}")]
        //public Employee Get(int id)
        //{
        //    var employee = employees.Find(x => x.Id == id);
        //    if (employee != null)
        //        return employee;
        //    return null;
        //}


        [HttpPost]
        public ActionResult Post([FromBody] Employee employee)
        {
            return Ok(_employeeService.Add(employee));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Employee value)
        {
            return Ok(_employeeService.Update(id, value));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee is null)
                return NotFound();
            _employeeService.Delete(id);
            return NoContent();
        }
    }
}

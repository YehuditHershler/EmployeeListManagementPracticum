using Microsoft.AspNetCore.Mvc;
using PracticumServer.Core.Entities;
using PracticumServer.Core.Services;

namespace PracticumServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Employee_RoleController : ControllerBase
    {

        private readonly IEmployee_RoleService _employee_RoleService;

        public Employee_RoleController(IEmployee_RoleService employee_RoleService)
        {
            _employee_RoleService = employee_RoleService;
        }

        // GET: api/<UsersController>
        [HttpGet]
            public ActionResult Get()
            {
                return Ok(_employee_RoleService.GetAll());
            }
        //[HttpGet]
        //public List<Employee_Role> Get()
        //{
        //    return employeesRoles;
        //}

            [HttpGet("{id}")]
            public ActionResult Get(int id)
            {
                return Ok(_employee_RoleService.GetById(id));
            }
        //[HttpGet("{id}")]
        //public List<Employee_Role> Get(int id)
        //{
        //    List<Employee_Role> employeeRole = employeesRoles.FindAll(x => x.EmployeeId == id);
        //    if (employeeRole != null)
        //        return employeeRole;
        //    return null;
        //}

            [HttpPost]
            public ActionResult Post([FromBody] Employee_Role value)
            {
                return Ok(_employee_RoleService.Add(value));
            }

            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] Employee_Role value)
            {
                return Ok(_employee_RoleService.Update(id, value));
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                var employee_Role = _employee_RoleService.GetById(id);
                if (employee_Role is null)
                {
                    return NotFound();
                }
                _employee_RoleService.Delete(id);
                return NoContent();
            }
    }
}

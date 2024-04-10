using Microsoft.AspNetCore.Mvc;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Employee_RoleController : ControllerBase
    {
        public static List<Employee_Role> employeesRoles = new List<Employee_Role>()
        {
            new Employee_Role() {Id=1, RoleId = 1, EmployeeId=1, RoleStartDate=new DateTime(2022, 1,1, 7, 30, 38), IsManagerial=true},
            new Employee_Role() {Id=2, RoleId = 2, EmployeeId=1, RoleStartDate=new DateTime(2010,1,1 , 7, 30, 38), IsManagerial=true},
            new Employee_Role() {Id=3 ,RoleId = 3, EmployeeId=2, RoleStartDate=new DateTime(2021, 1,1, 7, 30, 38), IsManagerial=true},
            new Employee_Role() {Id=4, RoleId = 9, EmployeeId=3, RoleStartDate=new DateTime(2023, 1,1, 7, 30, 38), IsManagerial=true},
        };

        private readonly ILogger<Employee_RoleController> _logger;

        public Employee_RoleController(ILogger<Employee_RoleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Employee_Role> Get()
        {
            return employeesRoles;
        }

        [HttpGet("{id}")]
        public List<Employee_Role> Get(int id)
        {
            List<Employee_Role> employeeRole = employeesRoles.FindAll(x => x.EmployeeId == id);
            if (employeeRole != null)
                return employeeRole;
            return null;
        }


        [HttpPost]
        public void Post([FromBody] Employee_Role value)
        {
            value.Id = Employee_Role.toId++;
            employeesRoles.Add(value);
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Employee_Role value)
        //{
        //    List<Employee_Role> employeeRolesById = employeesRoles.FindAll(x => x.EmployeeId == id);
        //    if (employeeRolesById != null)
        //    {
        //        foreach (Employee_Role employeeRole in employeeRolesById)
        //        {
        //            employeeRole.RoleId = value.RoleId;
        //            employeeRole.StartDate = value.StartDate;
        //        }
        //    }
        //}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee_Role value)
        {
            Employee_Role employeeRoleById = employeesRoles.Find(x => x.Id == id);
            if (employeeRoleById != null)
            {
                employeeRoleById.RoleId = value.RoleId;
                employeeRoleById.RoleStartDate = value.RoleStartDate;
                employeeRoleById.IsManagerial = value.IsManagerial;

            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employeeRole = employeesRoles.Find(x => x.Id == id);
            if (employeeRole != null)
                employeesRoles.Remove(employeeRole);
        }
    }
}
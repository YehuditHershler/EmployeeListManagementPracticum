using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> employees = new List<Employee>()
        {
            new Employee() {Id = 1, TZ ="325934024", FirstName = "ראובן", LastName = "אשר", Gender = Gender.Female, StartDate = new DateTime(2021, 11, 2, 7, 30, 0), BirthDate = new DateTime(2001, 1, 2, 7, 30, 0), Status=true },
            new Employee() {Id = 2, TZ ="315286013", FirstName = "שמעון", LastName = "דן", Gender = Gender.Female, StartDate = new DateTime(2022, 3, 2, 7, 30, 0), BirthDate = new DateTime(1998, 10, 1, 7, 30, 0), Status=true },
            new Employee() {Id = 3, TZ ="032127698", FirstName = "לוי", LastName = "נפתלי", Gender = Gender.Female,StartDate = new DateTime(2022, 1, 2, 7, 30, 0), BirthDate = new DateTime(2000, 1, 1, 7, 30, 0), Status=true },
            new Employee() {Id = 4, TZ ="325934024", FirstName = "יהודה", LastName = "יוסף", Gender = Gender.Female, StartDate = new DateTime(2021, 3, 2, 7, 30, 0), BirthDate = new DateTime(2003, 1, 1, 7, 30, 0), Status=true },
            new Employee() {Id = 5, TZ ="123456782", FirstName = "יששכר", LastName = "בנימין", Gender = Gender.Female, StartDate = new DateTime(2021, 1, 2, 7, 30, 0), BirthDate = new DateTime(2003, 5, 1, 7, 30, 0), Status=true },
            new Employee() {Id = 6, TZ ="325934024", FirstName = "זבולון", LastName = "אברהם", Gender = Gender.Female, StartDate = new DateTime(2024, 3, 2, 7, 30, 0), BirthDate = new DateTime(2004, 1, 10, 7, 30, 0), Status=true },
            new Employee() {Id = 7, TZ ="315986013", FirstName = "גד", LastName = "יצחק", Gender = Gender.Female, StartDate = new DateTime(2023, 1, 4, 7, 30, 0), BirthDate = new DateTime(2002, 7, 15, 7, 30, 0), Status=true },
            new Employee() {Id = 8, TZ ="123456782", FirstName = "דינה", LastName = "יעקב", Gender = Gender.Male, StartDate = new DateTime(2019, 1, 2, 7, 30, 0), BirthDate = new DateTime(1997, 1, 3, 7, 30, 0), Status=true },
            new Employee() {Id = 9, TZ ="741085203", FirstName = "שרה", LastName = "כהן", Gender = Gender.Male, StartDate = new DateTime(2021, 1, 2, 7, 30, 0), BirthDate = new DateTime(1997, 1, 3, 7, 30, 0), Status=true },
            new Employee() {Id = 10, TZ ="223362120", FirstName = "חני", LastName = "הרשלר", Gender = Gender.Male, StartDate = new DateTime(2020, 1, 2, 7, 30, 0), BirthDate = new DateTime(1997, 1, 3, 7, 30, 0), Status=true },
            new Employee() {Id = 11, TZ ="223362120", FirstName = "אלישבע", LastName = "הרשלר", Gender = Gender.Male, StartDate = new DateTime(2020, 1, 2, 7, 30, 0), BirthDate = new DateTime(1997, 1, 3, 7, 30, 0), Status=true },


        };
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return employees;
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var employee = employees.Find(x => x.Id == id);
            if (employee != null)
                return employee;
            return null;
        }

        [HttpPost]
        public Employee Post([FromBody] Employee value)
        {
            value.Id = Employee.toId++;
            if (CheckTZ(value.TZ))
            {
                employees.Add(value);
                return value;
            }
            value.TZ += "! not valid!!";
            return value;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            var employee = employees.Find(x => x.Id == id);
            if (employee != null)
            {
                employee.FirstName = value.FirstName;
                employee.LastName = value.LastName;
                employee.BirthDate = value.BirthDate;
                employee.StartDate = value.StartDate;
                employee.Status = value.Status;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employee = employees.Find(x => x.Id == id);
            if (employee != null)
                employees.Remove(employee);
        }

        public bool CheckTZ(string TZ)
        {
            int[] tz = new int[9];
            int i = 0;
            //בלולאה נפרדת intהמרה ל
            foreach (char t in TZ)
                tz[i++] = int.Parse(t.ToString());
            int sum = 0;
            for (i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
                    sum += tz[i];
                else if (tz[i] * 2 < 10)
                    sum += tz[i] * 2;
                else
                    sum += 1 + tz[i] * 2 % 10;
            }
            return sum % 10 == 0;
        }

    }
}
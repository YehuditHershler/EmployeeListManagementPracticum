using Microsoft.AspNetCore.Mvc;
using webApi;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {

        public static List<Role> roles = new List<Role>()
        {
            //new Role() { Id = 1, NameRole="Software developer", IsManagerial=false },
            //new Role() { Id = 2, NameRole="Product manager", IsManagerial=true },
            //new Role() { Id = 3,NameRole="DevOps Engineer", IsManagerial=false },
            //new Role() { Id = 4,NameRole="Information Security Manager", IsManagerial=true },
            //new Role() { Id = 5,NameRole="Network manager", IsManagerial=true },
            //new Role() { Id =6,NameRole="SEO expert", IsManagerial=false },
            //new Role() { Id = 7,NameRole="Hiring manager", IsManagerial=true },
            //new Role() { Id = 8,NameRole="HR manager", IsManagerial=true },
            //new Role() { Id =9,NameRole="Finance manager", IsManagerial=true },

            //new Role() { Id = 1, NameRole="Software developer"},
            //new Role() { Id = 2, NameRole="Product manager"},
            //new Role() { Id = 3,NameRole="DevOps Engineer" },
            //new Role() { Id = 4,NameRole="Information Security Manager" },
            //new Role() { Id = 5,NameRole="Network manager" },
            //new Role() { Id =6,NameRole="SEO expert" },
            //new Role() { Id = 7,NameRole="Hiring manager"},
            //new Role() { Id = 8,NameRole="HR manager" },
            //new Role() { Id =9,NameRole="Finance manager" },

            new Role() { Id = 1, NameRole="מפתח תוכנה"},
            new Role() { Id = 2, NameRole="מנהל מוצר"},
            new Role() { Id = 3,NameRole="מהנדס DevOps" },
            new Role() { Id = 4,NameRole="מנהל אבטחת מידע" },
            new Role() { Id = 5,NameRole="מנהל רשת" },
            new Role() { Id =6,NameRole="מומחה לקידום אתרים" },
            new Role() { Id = 7,NameRole="מנהל גיוס"},
            new Role() { Id = 8,NameRole="מנהל משאבי אנוש" },
            new Role() { Id =9,NameRole="מנהל כספים" },
        };

        private readonly ILogger<RoleController> _logger;

        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Role> Get()
        {
            return roles;
        }

        [HttpGet("{id}")]
        public Role Get(int id)
        {
            var role = roles.Find(x => x.Id == id);
            if (role != null)
                return role;
            return null;
        }

        [HttpPost]
        public void Post([FromBody] Role value)
        {
            roles.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Role value)
        {
            var role = roles.Find(x => x.Id == id);
            if (role != null)
            {
                role.Id = value.Id;
                role.NameRole = value.NameRole;
                //role.IsManagerial = value.IsManagerial;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var role = roles.Find(x => x.Id == id);
            if (role != null)
                roles.Remove(role);
        }

    }
}
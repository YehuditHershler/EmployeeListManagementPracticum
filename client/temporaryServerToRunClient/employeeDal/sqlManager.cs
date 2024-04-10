using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webApi;

namespace employeeDal
{
    public class sqlManager
    {




        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Gender Gender { get; set; }
            public List<Role> Roles { get; set; }
            public bool Status { get; set; }
        }
    }
}

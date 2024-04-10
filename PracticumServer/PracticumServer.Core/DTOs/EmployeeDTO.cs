using PracticumServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MinLength(9)]
        [MaxLength(9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The TZ must contain only digits.")]
        public string TZ { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        //public List<Employee_Role> Roles { get; set; }
    }
}

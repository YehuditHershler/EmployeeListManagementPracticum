using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(9), MinLength(9)]
        public string? TZ { get; set; }
        [Required]
        [MaxLength(20)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string? LastName { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool Status { get; set; }
        public List<Employee_Role> Roles { get; set; }
    }
    public enum Gender
    {
        Female,
        Male
    }
}

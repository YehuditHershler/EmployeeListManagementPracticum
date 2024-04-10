using PracticumServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracticumServer.Core.DTOs
{
    public class Employee_RoleDTO
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        //[JsonIgnore]
        //public Employee? Emoployee { get; set; }
        public int RoleId { get; set; }
        public DateTime RoleStartDate { get; set; }
        public bool IsManagerial { get; set; }
    }
}

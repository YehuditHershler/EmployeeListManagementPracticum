using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PracticumServer.Core.Entities
{
    public class Employee_Role
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee? Emoployee { get; set; }
        public int RoleId { get; set; }
        public DateTime RoleStartDate { get; set; }
        public bool IsManagerial { get; set; }
    }
}

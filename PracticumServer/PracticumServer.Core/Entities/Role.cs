using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string? NameRole { get; set; }
        //public bool IsManagerial { get; set; }
    }
}

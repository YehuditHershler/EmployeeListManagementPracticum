using Microsoft.EntityFrameworkCore;
using PracticumServer.Core.Entities;
using System.Numerics;

namespace PracticumServer.Data
{
    public class DataContext :DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee_Role> Employee_Roles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("PracticumDB");

        }
    }
}
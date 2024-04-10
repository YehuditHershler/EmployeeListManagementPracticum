using Microsoft.EntityFrameworkCore;
using PracticumServer.Core.Entities;
using PracticumServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Data.Repositories
{
    public class Employee_RoleRepository: IEmployee_RoleRepository
    {
        private readonly DataContext _context;
        public Employee_RoleRepository(DataContext context)
        {
            _context = context;
        }
        public Employee_Role Add(Employee_Role employee_role)
        {
            _context.Employee_Roles.Add(employee_role);
            _context.SaveChanges();
            return employee_role;
        }
        public void Delete(int id)
        {
            var employee_role = GetById(id);
            _context.Employee_Roles.Remove(employee_role);
            _context.SaveChanges();
        }
        public IEnumerable<Employee_Role> GetAll()
        {
            return _context.Employee_Roles.Include(e => e.Emoployee);
        }
        public Employee_Role GetById(int id)
        {
            return _context.Employee_Roles.Find(id);
        }
        public Employee_Role Update(int id, Employee_Role employee_role)
        {
            var existEmployee_Role = GetById(id);

            existEmployee_Role.JobStartDate = employee_role.JobStartDate;
            existEmployee_Role.IsManagerial = employee_role.IsManagerial;


            _context.SaveChanges();
            return existEmployee_Role;
        }
    }
}

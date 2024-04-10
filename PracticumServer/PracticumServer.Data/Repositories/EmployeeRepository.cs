using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Client;
using PracticumServer.Core.Entities;
using PracticumServer.Core.Repositories;
using PracticumServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PracticumServer.Data.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public Employee Add(Employee employee)
        {
            if (CheckTZ(employee.TZ))
            {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
            }
            employee.TZ += " ! not valid !!";
            return employee;
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.Roles);
        }
        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }
        public Employee Update(int id,  Employee employee)
        {
            var existEmployee = GetById(id);

            existEmployee.FirstName = employee.FirstName;
            existEmployee.LastName = employee.LastName;
            existEmployee.TZ = employee.TZ;
            existEmployee.BirthDate = employee.BirthDate;
            existEmployee.StartDate = employee.StartDate;
            existEmployee.Gender = employee.Gender;
            existEmployee.Status = employee.Status;

            _context.SaveChanges();
            return existEmployee;
        }

        public bool CheckTZ(string TZ)
        {
            int[] tz = new int[9];
            int i = 0;
            //בלולאה נפרדת intהמרה ל
            foreach (char t in TZ)
                tz[i++] = int.Parse(t.ToString());
            int sum = 0;
            for (i = 0; i < 9; i++) {
                if (i % 2 == 0)
                    sum+= tz[i];
                else if (tz[i] * 2 < 10)
                    sum+= tz[i]*2;
                else
                    sum += 1 + tz[i] * 2 % 10;
            }
            return sum % 10 == 0;
        }
    
    }
}

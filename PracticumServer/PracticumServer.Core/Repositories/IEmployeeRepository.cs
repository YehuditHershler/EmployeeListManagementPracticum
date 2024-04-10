using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticumServer.Core.Entities;

namespace PracticumServer.Core.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Add(Employee employee);
        Employee Update(int id, Employee employee);
        void Delete(int id);
    }
}

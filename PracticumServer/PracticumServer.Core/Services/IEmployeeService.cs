using PracticumServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(int id);

        Employee Add(Employee employee);

        Employee Update(int id, Employee employee);

        void Delete(int id);
    }
}

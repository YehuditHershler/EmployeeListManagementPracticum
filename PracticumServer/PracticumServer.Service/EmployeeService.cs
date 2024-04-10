using PracticumServer.Core.Entities;
using PracticumServer.Core.Repositories;
using PracticumServer.Core.Services;

namespace PracticumServer.Service
{
    public class EmployeeService :IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Add(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }
        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }
        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }
        public Employee Update(int id, Employee employee)
        {
            return _employeeRepository.Update(id, employee);
        }
    }
}


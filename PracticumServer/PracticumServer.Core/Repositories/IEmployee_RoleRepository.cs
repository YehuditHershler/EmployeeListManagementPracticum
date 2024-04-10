﻿using PracticumServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Repositories
{
    public interface IEmployee_RoleRepository
    {
        IEnumerable<Employee_Role> GetAll();
        Employee_Role GetById(int id);
        Employee_Role Add(Employee_Role employee_role);
        Employee_Role Update(int id, Employee_Role employee_role);
        void Delete(int id);
    }
}
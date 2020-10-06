using IdentityRolesEF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityRolesEF.Models.Repositories
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }

        public IEnumerable<Employee> AllEmployees => _appDbContext.Employees;

        public void CreateEmployee(string firstName, string lastName, string id)
        {
            Employee employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                UserId = id
            };

            _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
        }

    }
}

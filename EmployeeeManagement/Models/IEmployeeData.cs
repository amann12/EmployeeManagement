using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeeManagement.Models
{
    public interface IEmployeeData
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> EmployeeDetails();

        Employee Add(Employee employee);
        Employee Delete(int Id);
        Employee Update(Employee employeeChange);
    }
}

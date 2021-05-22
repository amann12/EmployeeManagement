using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeeManagement.Models
{
    public class MockEmployee : IEmployeeData
    {
        private List<Employee> _employeeList;
        public MockEmployee()
        {
            //_employeeList = new List<Employee>()
            //{
            //    new Employee()/*{Id=1,Name="Aman",EmailId="Amangn12@gmail.com",Number=987654,Department=dept.IT},*/
            //    new Employee()/*{Id=2,Name="Dhruv",EmailId="Dhruv@gmail.com",Number=98735564,Department=dept.CSE},*/
            //    new Employee()/*{Id=3,Name="Yash",EmailId="Yash@gmail.com",Number=987654,Department=dept.Marketing},*/
            //    new Employee()/*{Id=4,Name="akhil",EmailId="akhil@gmail.com",Number=987654,Department=dept.none},*/
            //};
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id);
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if(employee!=null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> EmployeeDetails()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChange)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChange.Id);
            if(employee!=null)
            {
                employee.Name = employeeChange.Name;
                employee.EmailId = employeeChange.EmailId;
                employee.Number = employeeChange.Number;
                employee.Department = employeeChange.Department;
            }
            return employee;
        }
    }
}

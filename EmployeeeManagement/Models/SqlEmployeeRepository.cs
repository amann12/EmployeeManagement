using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeeManagement.Models
{
    public class SqlEmployeeRepository : IEmployeeData
    {
        private readonly AppDbcontext context;
        public SqlEmployeeRepository(AppDbcontext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if(employee!=null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> EmployeeDetails()
        {
            //this is use to display the whole table
            return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            //this is use to display a particular record
            return context.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChange)
        {
            var employee = context.Employees.Attach(employeeChange);
            //this use to write the whole table row data in one go with us writing them
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChange;
        }
    }
}

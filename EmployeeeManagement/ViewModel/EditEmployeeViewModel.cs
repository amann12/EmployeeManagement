using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeeManagement.ViewModel
{
    public class EditEmployeeViewModel:EmployeeViewModel
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
    }
}

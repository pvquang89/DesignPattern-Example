using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class EmployeeBL
    {
        // public EmployeeDAL employeeDAL;
        // public List<Employee> GetAllEmployees()
        // {
        //     //Tạo 1 instance của dependency class => Tight Coupling
        //     employeeDAL = new EmployeeDAL();
        //     return employeeDAL.SelectAllEmployees();
        // }

        //Client Class or Dependent Object
        //Class này sử dụng các dịch vụ cuả class IEmployeeDAL
        public IEmployeeDAL employeeDAL;
        //Injecting the Dependency Object using Constructor => Loose Coupling
        //Thay vì tạo 1 obj EmployeeDAL ta lại đang inject nó dưới dạng tham số cho constructor của class EmployeeBL
        public EmployeeBL(IEmployeeDAL employeeDAL)
        {
            this.employeeDAL = employeeDAL;
        }
        public List<Employee> GetAllEmployees()
        {
            return employeeDAL.SelectAllEmployees();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern
{
    //Service Class or Dependency Object : cung cấp các service cho class khác sử dụng
    //Class EmployeeBL sẽ dùng class này => class này là đối tượng phụ thuộc(Dependency Object) 
    public class EmployeeDAL: IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> ListEmployees = new List<Employee>
            {
                new Employee() { ID = 1, Name = "Quang1", Department = "Phong1" },
                new Employee() { ID = 2, Name = "Quang2", Department = "Phong2" },
                new Employee() { ID = 3, Name = "Quang3", Department = "Phong3" }
            };
            return ListEmployees;
        }
    }
}
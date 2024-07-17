using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern
{
    //Class model 
    //Class này sẽ được sử dụng bởi EmployeeDL và EmployeeDAL
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
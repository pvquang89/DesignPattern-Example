using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPattern
{

    //Lưu ý khi dùng DI : Object dependency phải là interface 
    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployees();
    }
}
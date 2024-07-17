﻿using DesignPattern;

internal class Program
{
    //Injector class : class này sẽ inject dependency object(EmployeeDAL Object) vào Client class(EmployeeBL Class)
    //Class này quyết định instance EmployeeDAL nào sẽ được sử dụng bởi EmployeeBL thông qua Contructor
    private static void Main(string[] args)
    {
        //Inject Dependency object(EmployeeDAL Object) làm argument cho constructor
        EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());
        
        List<Employee> listEmp = employeeBL.GetAllEmployees();
        foreach (var emp in listEmp)
        {
            Console.WriteLine($"ID = {emp.ID}, Name = {emp.Name}, Department = {emp.Department}");
        }

    }
}
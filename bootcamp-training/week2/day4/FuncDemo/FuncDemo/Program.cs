using System;
using System.Collections.Generic;
namespace FuncDemo
{
    //    delegate bool isPromote(Employee emp);

    class Demo
    {
        public static void Main()
        {
            List<Employee> empl = new List<Employee>();
            empl.Add(new Employee() { ID = 101, Name = "Ravi", salary = 20000, Experiance = 3 });
            empl.Add(new Employee() { ID = 102, Name = "John", salary = 30000, Experiance = 5 });
            empl.Add(new Employee() { ID = 103, Name = "Mary", salary = 50000, Experiance = 8 });
            empl.Add(new Employee() { ID = 104, Name = "Mike", salary = 10000, Experiance = 2 });
            Func<Employee,bool> IsEligible=promote;
            Employee.PromoteEmp(empl, IsEligible);
        }

        public static bool promote(Employee emp)
        {
            return emp.Experiance >= 5;
        }
    }
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int salary { get; set; }
        public float Experiance { get; set; }
        public static void PromoteEmp(List<Employee> EmployeeList, Func<Employee,bool> IsEligible)
        {
            foreach (Employee emp in EmployeeList)
            {
                if (IsEligible(emp))//logic condition  
                {
                    Console.WriteLine(emp.Name + " Promoted");
                }
            }
        }
    }
    
}

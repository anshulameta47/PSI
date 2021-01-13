using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EF_Demo_DBEntities DBEntities = new EF_Demo_DBEntities())
            {


                AddDepartment();
                ShowTransaction();

                List<Department> listDepartments = DBEntities.Departments.ToList();

                foreach (Department dept in listDepartments)
                {
                    Console.WriteLine("  Department = {0}, Location = {1}", dept.Name, dept.Location);
                    foreach (Employee emp in dept.Employees)
                    {
                        Console.WriteLine("\t Name = {0}, Email = {1}, Gender = {2}, salary = {3}",
                            emp.Name, emp.Email, emp.Gender, emp.Salary);
                    }
                    Console.WriteLine();

                }
                Console.ReadKey();
            }
        }
        public static void AddDepartment()
        {

            using (EF_Demo_DBEntities DBEntities = new EF_Demo_DBEntities())
            {

                Department department = new Department();
                department.ID = 4;
                department.Name = "Delivery";
                department.Location = "Udaipur";
                DBEntities.Departments.Add(department);
                DBEntities.SaveChanges();
            }
        }

        public static void ShowTransaction()
        {
            using (EF_Demo_DBEntities DBEntities = new EF_Demo_DBEntities())
            {
                using (var dbContextTransaction = DBEntities.Database.BeginTransaction())
                {
                    try
                    {
                        Department department = new Department();
                        department.ID = 5;
                        department.Name = "Makreting";
                        department.Location = "Jaipur";
                        DBEntities.Departments.Add(department);
                        DBEntities.SaveChanges();

                        Employee employee = new Employee()
                        {
                            ID = 1,
                            Name = "anshul",
                            Email = "anshulameta@gmail.com",
                            Gender = "M"
                        };
                        DBEntities.Employees.Add(employee);
                        DBEntities.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}


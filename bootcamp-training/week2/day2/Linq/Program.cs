using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> mylist=new List<int>()
            {
                1,2,3,4,5,6,7,8,9
            };
            var QuerySyntex= from obj in mylist 
                            where obj>5 select obj;

            foreach (var item in QuerySyntex)
            {
                Console.Write(item +" ");
            } 

            Console.WriteLine();
            
            IEnumerable<int> QueryLambdaSyntax=mylist.Where(obj=>obj>5).ToList();
             foreach (var item in QueryLambdaSyntax)
            {
                Console.Write(item +" ");
            } 
            Console.ReadKey();        


            List<Student> studentlist=new List<Student>()
            {
                new Student(){ID=1;nameof="anshul"}
            }
            IQueryable<Student> MethodSyntax=studentlist.AsQuearyale().where(std=> std.id>5);



            StudentDBContext dBContext = new StudentDBContext();
            IEnumerable<Student> listStudents = dBContext.Students.Where(x => x.Gender == "Male");
            listStudents = listStudents.Take(2);

            foreach(var std in listStudents)
            {
                Console.WriteLine(std.FirstName + " " + std.LastName);
            }
        }
    }

    class Student
    {
        public int ID{get;set;}
        public string name{get;set;}
    }
}

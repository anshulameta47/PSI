using System;

namespace Proj1
{

    
    public class GenericList<T> 
    {
        public void Add(T input){}
    
    }

    public class GenericConstraint<T> where T:class
    {
        public void Add(T input){}
    
    }
    

    public class MultipleConstraint<T,U>
    {
        public void Add(T a,U b)
        {

        }
    }
    
    class TestGeneric
    {
        
        
        private class ExampleClass { }
    static void Main()
    {
    
        GenericList<int> list1 = new GenericList<int>();
        list1.Add(1);
        Console.WriteLine(list1);

        GenericList<string> list2 = new GenericList<string>();
        list2.Add("");

        GenericList<ExampleClass> list3 = new GenericList<ExampleClass>();
        list3.Add(new ExampleClass());

        GenericConstraint<ExampleClass> list4=new GenericConstraint<ExampleClass>();


        MultipleConstraint<int,string> list5=new MultipleConstraint<int,string>();


    }
    }

}

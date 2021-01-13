using System;

namespace Proj1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArrayDemo();
        }

        private static void ArrayDemo()
        {
            int[] Arr=new int[4];
            int[] Arr2=new int[4]{1,2,3,4};
            int index=0;

            for( index=0;index<Arr.Length;index++)
            {
                Arr[index]=index;
            }

            Console.WriteLine("Elements of Arr2:");           
            
            foreach(var item in Arr2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Elements of Arr");index=0;
            
            while(index<Arr.Length)
            {
                Console.WriteLine(Arr[index]);index++;
            }

            try
            {
                 Console.WriteLine(Arr2[5]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

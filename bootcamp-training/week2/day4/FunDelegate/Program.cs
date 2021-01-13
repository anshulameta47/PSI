using System;

namespace FunDelegate
{
    class Program
    {

        static int sum(int x,int y)
        {
            return x+y;
        }
        static void Main(string[] args)
        {
            Func<int,int,int> add=sum;
            int result=add(10,10);
            Console.WriteLine("output of addition "+result);

            Func<int,int,int> mul=(x,y)=>x*y;
            result=mul(20,20);
            Console.WriteLine("output of multiplication "+result);

            Func<int> getRandomNumber=delegate()
            {
                Random random=new Random();
                return random.Next(1,100);
            };
            Console.WriteLine(getRandomNumber());
        }
    }
}

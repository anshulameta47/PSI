using System;

namespace Proj2
{

    class Base
    {
        public virtual string Name{get;set;} 

        public virtual int Sum(int a ,int b)
        {
            return a+b;
        }

        protected virtual int Sub(int a ,int b)
        {
            return a-b;
        }
        
    }


    class Derived:Base
    {
        
        private string name;

        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                Console.WriteLine("from derived class");

                name = !string.IsNullOrEmpty(value)? value: "unknown";            }
        }


        public override int Sum(int a,int b)
        {
            return a+b+3;
        }

        protected override int Sub(int a ,int b)
        {
            return a-b-3;
        }

        public static void Main(string[] args)
        {
            Base BDerived=new Derived();
            BDerived.Name="Anshul";
            
            Console.WriteLine(BDerived.Sum(3,4));


            Derived DDerived=new Derived();
            Console.WriteLine(DDerived.Sub(8,2));   //For accessing Protected member refrence should be of Derived class 



        } 


    }

    
}







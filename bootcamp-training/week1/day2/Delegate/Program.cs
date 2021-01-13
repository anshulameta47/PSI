using System;

namespace Delegate
{

    public delegate void Mydelegate(string m);
    public delegate void Notify();
    class Program
    {
        static void Main(string[] args)
        {
            Mydelegate del1=A.MethodA;
            InvokeDelegate(del1);

            Mydelegate del2=B.MethodB;
            InvokeDelegate(del2);

            Mydelegate del3=C.MethodC;
            InvokeDelegate(del3);

            Mydelegate del4=(string msg)=>Console.WriteLine("from lambda expression "+msg);
            InvokeDelegate(del4);

            Console.WriteLine("After performing del1+del2+del3+del4 ");
            Mydelegate del=del1+del2+del3+del4;
            InvokeDelegate(del);


            ProcessBusinessLogic b1=new ProcessBusinessLogic();
            b1.ProcessCompleted+=b1_ProcessCompleted;
            b1.StartProcess();


        }


        public static void InvokeDelegate(Mydelegate del)
        {
            del("hello anshul!!");
        }

        public static void b1_ProcessCompleted()
        {
            Console.WriteLine("Process completed");
        }
    }


    class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("process started");
            OnProcessCompleted();
        }

        public virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
    }


    class A
    {
        public static void MethodA(string msg)
        {
            Console.WriteLine("from class A " +msg);
        }
    }

    class B
    {
        public static void MethodB(string msg)
        {
            Console.WriteLine("from class B "+msg);
        }
    }

}

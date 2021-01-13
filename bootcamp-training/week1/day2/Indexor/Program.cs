using System;

namespace Indexor
{

    public interface ISomeInterface
    {
        int this[int index]
        {
            get;
            set;
        }
    }

    class IndexerClass:ISomeInterface
    {
         private int[] arr = new int[100];
    public int this[int index]   
    {
        get => arr[index];
        set => arr[index] = value;
    }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IndexerClass test = new IndexerClass();
            System.Random rand = new System.Random();

        for (int i = 0; i < 10; i++)
         {
             test[i] = rand.Next();
          }
        for (int i = 0; i < 10; i++)
        {
            System.Console.WriteLine($"Element #{i} = {test[i]}");
        }

        }
    }
}

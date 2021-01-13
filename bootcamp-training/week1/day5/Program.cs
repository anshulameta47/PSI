using System;
using System.IO;


namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f=new FileStream("abc.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            char i='a';
            f.WriteByte((byte)i);
        }
    }
}

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlogDemoApplication
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Error("Eroor");
            logger.Trace("This is an trace message");

            Console.Read();
        }
    }
}

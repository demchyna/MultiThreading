using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "Main Thread";

            Console.WriteLine("Thread name: " + mainThread.Name);
            Console.WriteLine("Thread priority: " + mainThread.Priority);
            Console.WriteLine("Thread ID: " + mainThread.ManagedThreadId);
            Console.WriteLine("Thread state: " + mainThread.ThreadState);
            Console.WriteLine("Thread background: " + mainThread.IsBackground);
            Console.WriteLine("Thread pool: " + mainThread.IsThreadPoolThread);

            Console.ReadKey();
        }
    }
}

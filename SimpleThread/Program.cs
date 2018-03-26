using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();

            Thread firstThread = new Thread(new ThreadStart(app.FirstThread));
            firstThread.Start();

            Thread.CurrentThread.Name = "Main Thread";
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(500);
            }

            Console.ReadKey();
        }

        public void FirstThread()
        {
            Thread.CurrentThread.Name = "First Thread";
            
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(1000);
            }
        }
    }
}

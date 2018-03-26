using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DaemonThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();

            Thread daemonThread = new Thread(new ThreadStart(app.DaemonThread));
            daemonThread.Start();

            Thread.CurrentThread.Name = "Main Thread";
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(500);
            }
        }

        public void DaemonThread()
        {
            Thread.CurrentThread.Name = "Daemon Thread";
            Thread.CurrentThread.IsBackground = true;

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(1000);
            }
        }
    }
}

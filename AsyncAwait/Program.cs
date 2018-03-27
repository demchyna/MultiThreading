using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();
            app.AsyncAwaitMethod();

            Thread.CurrentThread.Name = "Main Thread";
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(500);
            }

            Console.ReadKey();
        }

        public async void AsyncAwaitMethod()
        {
            string message =  await DoSomethingAsync(10);
            Console.WriteLine(message);
        }


        public async static Task<string> DoSomethingAsync(int count)
        {
            return await Task.Run(() =>
            {
                Thread.CurrentThread.Name = "My Thread";
                //Thread.CurrentThread.IsBackground = false;

                int counter = 0;
                for (; counter < count; counter++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name);
                    Thread.Sleep(1000);
                }

                return string.Format("{0} was executed {1} times", Thread.CurrentThread.Name, counter);
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParametrizedThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();
            Data data = new Data(10, "This is second Thread!");

            Thread secondThread = new Thread(new ParameterizedThreadStart(app.SecondThread));
            secondThread.Start(data);

            Thread.CurrentThread.Name = "Main Thread";
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(500);
            }

            Console.ReadKey();
        }

        public void SecondThread(object obj)
        {
            if (obj is Data data)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    Console.WriteLine(data.Message);
                    Thread.Sleep(1000);
                }
            }
        }

        private class Data
        {
            public int Count { get; set; }
            public string Message { get; set; }

            public Data(int count, string message)
            {
                Count = count;
                Message = message;
            }
        }
    }
}

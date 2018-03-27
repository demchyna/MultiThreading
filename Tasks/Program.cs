using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();

            Task firstTask = new Task(app.FirstTask);
            firstTask.Start();

            Task secondTask = Task.Factory.StartNew(app.SecondTask);

            app.ThirdTask();

            Thread.CurrentThread.Name = "Main Thread";
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(500);
            }

            firstTask.Wait();
            secondTask.Wait();

            //Console.ReadKey();
        }

        public void FirstTask()
        {
            Thread.CurrentThread.Name = "First Task";

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(1000);
            }
        }

        public void SecondTask()
        {
            Thread.CurrentThread.Name = "Second Task";

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(1000);
            }
        }

        public async void ThirdTask()
        {
            await Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Third Task";

                for (int i = 0; i < 15; i++)
                {
                    Console.WriteLine(Thread.CurrentThread.Name);
                    Thread.Sleep(1000);
                }
            });
        }
    }
}

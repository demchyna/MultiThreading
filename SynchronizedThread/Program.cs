using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizedThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();
            Bank bank = new Bank(500, 500);

            Thread transferThread1 = new Thread(new ParameterizedThreadStart(app.TransferThread));
            Thread transferThread2 = new Thread(new ParameterizedThreadStart(app.TransferThread));

            transferThread1.Start(bank);
            transferThread2.Start(bank);

            Console.ReadKey();
        }

        public void TransferThread(object obj)
        {
            if (obj is Bank bank)
            {
                for (int i = 0; i < 100; i++)
                {
                    //lock(this)
                        bank.Transfer();
                }
            }
        }
    }
}

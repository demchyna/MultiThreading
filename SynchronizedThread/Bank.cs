using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizedThread
{
    //[Synchronization]
    class Bank //: ContextBoundObject
    {
        private int account1, account2;

        public Bank(int acc1, int acc2)
        {
            account1 = acc1;
            account2 = acc2;
        }

        //private object threadLock = new object();

        public void Transfer()
        {
            int amount = new Random().Next(500);

            //lock (threadLock)
            //{
                if (account1 > amount)
                {
                    account1 = account1 - amount;
                    Thread.Sleep(2000);
                    account2 = account2 + amount;
                }
                else
                {
                    account1 = account1 + amount;
                    Thread.Sleep(2000);
                    account2 = account2 - amount;
                }
            
                Console.WriteLine("Account #1: " + account1 + "\t" + 
                    "Account #2: " + account2 + "\t" + 
                    "Total balance: " + TotalBalance() + "\t");
            //}
        }
   
        private int TotalBalance()
        {
            return account1 + account2;
        }
    }
}

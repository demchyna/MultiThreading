using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsCommunication
{
    [Synchronization]
    class Basket : ContextBoundObject
    {
        private string fruit;

        public string GetFruit()
        {
            Console.WriteLine("Get: " + fruit);
            return fruit;
        }

        public void PutFruit(string fruit)
        {
            this.fruit = fruit;
            Console.WriteLine("Put: " + fruit);
        }
    }
}

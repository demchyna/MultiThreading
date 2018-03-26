using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsCommunication
{
    class Basket
    {
        private string fruit;

        private static AutoResetEvent waitHandle1 = new AutoResetEvent(false);
        private static AutoResetEvent waitHandle2 = new AutoResetEvent(false);

        private bool fruitPutted = false;

        public void PutFruit(string fruit)
        {
            if (fruitPutted)
            {
                waitHandle1.WaitOne();
            }

            this.fruit = fruit;

            fruitPutted = true;

            Console.WriteLine("Put: " + fruit);

            waitHandle2.Set();
        }

        public string GetFruit()
        {
            if (!fruitPutted)
            {
                waitHandle2.WaitOne();
            }

            Console.WriteLine("Get: " + fruit);

            fruitPutted = false;

            waitHandle1.Set();

            return fruit;
        }
    }
}

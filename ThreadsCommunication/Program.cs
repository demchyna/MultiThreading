using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();
            Basket basket = new Basket();

            Thread producerThread = new Thread(new ParameterizedThreadStart(app.ProducerThread));
            Thread consumerThread = new Thread(new ParameterizedThreadStart(app.ConsumerThread));

            producerThread.Start(basket);
            consumerThread.Start(basket);

            Console.ReadKey();
        }

        private static AutoResetEvent waitHandle1 = new AutoResetEvent(false);
        private static AutoResetEvent waitHandle2 = new AutoResetEvent(false);

        private bool fruitPutted = false;

        public void ProducerThread(object obj)
        {
            string[] fruits = {"Apple", "Orange", "Lemon", "Cherry", "Mango"};

            if (obj is Basket basket)
            {
                for (int i = 0; i < fruits.Length; i++)
                {
                    if (fruitPutted)
                    {
                        waitHandle1.WaitOne();
                    }

                    basket.PutFruit(fruits[i]);

                    fruitPutted = true;

                    waitHandle2.Set();
                }           
            } 
        }

        public void ConsumerThread(object obj)
        {
            if (obj is Basket basket)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!fruitPutted)
                    {
                        waitHandle2.WaitOne();
                    }

                    fruitPutted = false;

                    basket.GetFruit();

                    waitHandle1.Set();
                }
                
            }
        }
    }
}

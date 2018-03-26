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
     

        public void ProducerThread(object obj)
        {
            string[] fruits = {"Apple", "Orange", "Lemon", "Cherry", "Mango"};

            if (obj is Basket basket)
            {
                for (int i = 0; i < fruits.Length; i++)
                {
                    basket.PutFruit(fruits[i]);
                }           
            } 
        }

        public void ConsumerThread(object obj)
        {
            if (obj is Basket basket)
            {
                for (int i = 0; i < 5; i++)
                {
                    basket.GetFruit();
                }
            }
        }
    }
}

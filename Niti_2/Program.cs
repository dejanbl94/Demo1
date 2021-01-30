using System;
using System.Threading;

namespace Niti_2
{
    public class Program
    {
        public static void Ispis()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread proc {0}", i);
                Thread.Sleep(20);
            }
        }

        private static void Main(string[] args)
        {
            bool flag = true;

            Thread t = new Thread(new ThreadStart(() =>
            {
                while (flag)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine("Main thread {0}", i);
                        Thread.Sleep(20);
                    }
                }
            }));

            t.Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            flag = false;
        }
    }
}
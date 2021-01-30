using System;
using System.Threading;

namespace Niti
{
    public class Program
    {
        public static void Ispis()
        {
            Thread.Sleep(5000);
        }

        public static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(Ispis));
            t.Start();

            for (int i = 0; i < 50; i++)//This will not wait for Ispis() to finish as we have separated threads for the methods..
            {
                Console.WriteLine("Main thread: {0} ", i);
                Console.WriteLine("ANASTASIJA");
                Console.WriteLine("STREFA");
                Thread.Sleep(0);
            }
            t.Join();
        }
    }
}
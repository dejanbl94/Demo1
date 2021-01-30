using System;
using System.Threading;

namespace Niti
{
    public class Program
    {
        private int mojBroj = 123456;
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
                Console.WriteLine("dejo prdonja");
                Console.WriteLine(mojBroj);

                Thread.Sleep(0);
            }
            t.Join();
        }
    }
}
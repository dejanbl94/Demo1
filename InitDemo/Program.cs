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
            Ispis();

            for (int i = 0; i < 50; i++) //this process will be stopped until Ispis() finishes...
            {
                Console.WriteLine("Main thread: {0} ", i);
                Thread.Sleep(0);
            }
        }
    }
}
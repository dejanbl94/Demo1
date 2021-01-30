using System;
using System.Threading;

namespace ForegroungBackgroundThreads
{
    internal class Program
    {
        public static void Ispis()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread proc {0}", i);
                Thread.Sleep(20);
            }
        }

        public static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Ispis));
            //t1.IsBackground = true;//terminates imediately, but when set to false, program waits for all threads to finish and then terminates the program.
            t1.IsBackground = false;
            t1.Start();
        }
    }
}
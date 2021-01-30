using System;
using System.Threading;

namespace ParametrizedThreadStart
{
    internal class Program
    {
        public static void Ispis(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("Thread proc {0}...", i);
            }
        }

        public static void Main(string[] args)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Ispis));
            t.Start(10);
        }
    }
}
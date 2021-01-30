using System;
using System.Threading;

namespace ThreadStatic
{
    public class Program
    {
        /*With the ThreadStaticAttribute applied, the maximum value of _field becomes 10. If you remove it, you can see that both threads
         * access the same value and it becomes 20.*/

        [ThreadStatic]
        public static int _field;

        private static void Main(string[] args)
        {
            new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                    Thread.Sleep(5);
                }
            })).Start();

            new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        _field++;
                        Console.WriteLine("Thread B: {0}", _field);
                    }
                }
            })).Start();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ZenOfAsync
{
    public class EmptyBodyOverhead
    {
        private static void EmptyBody() { }
        private static async void EmptyBodyAsync() { }

        internal static void Run()
        {
            var sw = new Stopwatch();
            const int ITERS = 1000000 ;

            EmptyBody();
            EmptyBodyAsync();

            while (true)
            {
                sw.Restart();
                for (int i = 0; i < ITERS; i++) EmptyBody();
                var emptyBodyTime = sw.Elapsed;

                sw.Restart();
                for (int i = 0; i < ITERS; i++) EmptyBodyAsync();
                var emptyBodyAsyncTime = sw.Elapsed;

                Console.WriteLine($"Sync : {emptyBodyTime},");
                Console.WriteLine($"Async : {emptyBodyAsyncTime}");
                Console.WriteLine($"--{emptyBodyTime / emptyBodyAsyncTime}--");

                Console.ReadLine();
            }
        }
    }
}

using System;
using System.Threading;

namespace ThreadJoinDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Main method started");

            Thread t1 = new Thread(Thread1);
            t1.Start();

            Thread t2 = new Thread(Thread2);
            t2.Start();

            t1.Join();
            //Console.WriteLine("Thread 1 method completed...");

            t2.Join();
            //Console.WriteLine("Thread 2 method completed...");

            Console.WriteLine("Main method completed");
        }

        public static void Thread1()
        {
            Console.WriteLine("Thread 1 completed");
        }

        public static void Thread2()
        {
            Console.WriteLine("Thread 2 completed");
        }
    }
}
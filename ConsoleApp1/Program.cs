using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<Action> measure = (body) => {
                var start = DateTime.Now;
                body();
                Console.WriteLine(DateTime.Now - start);

            };


        }
    }
}

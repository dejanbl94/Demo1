using System;
using System.Linq;

namespace SimpleParallelIteration
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            var numbers = Enumerable.Range(0, 10);
            var iterate = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                    .ToArray();

            Console.WriteLine("The result of this query are in no particular oder, they are executed in parallel\n");
            foreach (int i in iterate)
            {
                result += i;
                Console.WriteLine(i);
            }
            Console.WriteLine("\nResult of parallel iteration for even numbers is {0}!", result);
        }
    }
}

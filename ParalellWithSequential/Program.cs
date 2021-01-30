using System;
using System.Linq;

namespace ParalellWithSequential
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("One scenario where this is required is to preserve the ordering of your query. Listing 1-25 shows how you can use the AsSequential operator to make sure that the Take method doesn’t mess up your order.");

            var numbers = Enumerable.Range(0, 10);

            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).AsSequential();

            Console.WriteLine("\nUse AsSequential() to make sure that the Take method doesn't mess up your order.\n");
            foreach (int i in parallelResult.Take(5))
            {
                Console.WriteLine(i);
            }
        }
    }
}

using System;
using System.Linq;

namespace OrderedParallelIteration
{
    class Program
    {
        static void Main(string[] args)
        {
            int res = 0;

            var numbers = Enumerable.Range(0, 10);
            var parallel = numbers.AsParallel().AsOrdered()
                    .Where(i => i % 2 == 0)
                        .ToArray();

            Console.WriteLine("Query is still processed in parallel, but the results are buffered and sorted...\n");
            foreach (int i in parallel)
            {
                Console.WriteLine(i);
            }
        }
    }
}

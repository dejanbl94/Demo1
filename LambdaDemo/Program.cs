using System;

namespace LambdaDemo
{
    class Program
    {
        public delegate int Calculate(int x, int y);
        static void Main(string[] args)
        {

            int result1 = Program.add(3, 4);
            int result2 = Program.mult(3, 4);
        }

        static Calculate add = (x, y) =>
        {
            int z = x + y;
            Console.WriteLine($"Adding numbers {x} and {y} gives the result of {z}.");
            return z;
        };

        static Calculate mult = (x, y) =>
        {
            int z = x * y;
            Console.WriteLine($"Multiplying numbers {x} and {y} gives the result of {z}.");
            return z;
        };
    }
}

using System;

namespace FuncDemo
{
    public class Program
    {
        static int Add(int x, int y) { int z = x + y; Console.WriteLine($"The addition of {x} and {y} gives {z}."); return z; }
        static int Subtract(int x, int y) { int z = x - y; Console.WriteLine($"The subtraction of {x} and {y} gives {z}."); return z; }
        static int Multiply(int x, int y) { int z = x * y; Console.WriteLine($"The multiplication of {x} and {y} gives {z}."); return z; }

        private static void InvokeFuncDelegate(int x, int y)
        {
            //Another way around with lambdas
            /*
            Func<int, int, int> sum = (a, b) => { int z = x + y; Console.WriteLine($"The addition of {a} and {b} gives {z}."); return z; };
            Func<int, int, int> subtract = (a, b) => { int z = x - y; Console.WriteLine($"The subtraction of {a} and {b} gives {z}."); return z; };
            Func<int, int, int> multiply = (a, b) => { int z = x * y; Console.WriteLine($"The multiplication of {a} and {b} gives {z}."); return z; };
            sum(x, y);
            */
            Func<int, int, int> funcDelegate = Add;
            funcDelegate += Subtract;
            funcDelegate += Multiply;

            funcDelegate(x, y);
        }

        static void Main(string[] args)
        {
            InvokeFuncDelegate(3, 4);   
        }
    }
}

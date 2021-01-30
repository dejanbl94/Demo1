using System;

namespace SimpleDelegateDemo
{
    class Program
    {
        public delegate void Calculate(int x, int y);

        public void Add(int x, int y) { Console.WriteLine(x + y); }
        public void Multiply(int x, int y) { Console.WriteLine(x * y); }

        /* public void UseDelegate()
         {
             Calculate calc = Add;
             Console.WriteLine(calc(3, 4));

             calc = Multiply;
             Console.WriteLine(calc(3, 4));
         }*/

        public void UseDelegateMulticast()
        {
            Calculate calc = Add;
            calc += Multiply;
            calc(3, 4);

            Console.WriteLine($"Multicast delegate will call {calc.GetInvocationList().GetLength(0)} methods...");
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.UseDelegate();
            p.UseDelegateMulticast();
        }
    }
}

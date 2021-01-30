using System;

namespace FuncDelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var executionManager = new ExecutionManager();
            var opManager = new OperationManager(20, 11, executionManager);
            var result = opManager.Execute(Operation.Modulo);
            Console.WriteLine($"The result of the operation is {result}");

            Console.ReadKey();
        }
    }
}

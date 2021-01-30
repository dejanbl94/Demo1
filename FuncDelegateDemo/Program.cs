using System;

namespace FuncDelegateDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var execManager = new ExecutionManager();
            var opManager = new OperationManager(20, 0, execManager);
            opManager.OnChangeDivide += _onChange;

            var result = opManager.Execute(Operation.Divide);
         
            Console.WriteLine($"The result of our operation is {result}.");
        }

        static void _onChange()
        {
            Console.WriteLine("Subscription to the event triggered by the publisher trying to divide by zero!");
        }
    }
}

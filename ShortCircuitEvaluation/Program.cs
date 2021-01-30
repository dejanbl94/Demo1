using System;

namespace ShortCircuitEvaluation
{
    public class Program
    {
        bool firstEvaluator()
        {
            return false;
        }

        bool secondEvaluator()
        {
            return true;
        }

        public void evaluate()
        {
            if (firstEvaluator() & secondEvaluator())
            {
                Console.WriteLine("Will not execute, but secondEvaluator is checked...");
            }

            if (firstEvaluator() | secondEvaluator())
            {
                Console.WriteLine("Will execute");
            }
        }

            public void evaluateShortCircuit()
            {
                if (firstEvaluator() && secondEvaluator())
                {
                    Console.WriteLine("Will not execute, stop after firstEvaluatorCheck!");
                }

                if (firstEvaluator() || secondEvaluator())
                {
                    Console.WriteLine("Will execute");
                }
            }


        static void Main(string[] args)
        {
            Program p = new Program();
            //p.evaluate();
           p.evaluateShortCircuit();
        }
    }
}

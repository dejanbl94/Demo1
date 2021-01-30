using System;
using System.Collections.Generic;
using System.Text;

namespace FuncDelDemo
{
    public class ExecutionManager
    {
        public Dictionary<Operation, Func<int>> FuncExecute { get; set; }
        private Func<int> _sum;
        private Func<int> _subtract;
        private Func<int> _multiply;
        private Func<int> _divide;
        private Func<int> _modulo;

        public ExecutionManager()
        {
            FuncExecute = new Dictionary<Operation, Func<int>>(5);
        }

        public void PopulateFunctions(Func<int> Sum, Func<int> Subtract, Func<int> Multiply, Func<int> Divide, Func<int> Modulo)
        {
            _sum = Sum;
            _subtract = Subtract;
            _multiply = Multiply;
            _divide = Divide;
            _modulo = Modulo;
        }

        public void PrepareExecution()
        {
            FuncExecute.Add(Operation.Add, _sum);
            FuncExecute.Add(Operation.Subtract, _subtract);
            FuncExecute.Add(Operation.Multiply, _multiply);
            FuncExecute.Add(Operation.Divide, _divide);
            FuncExecute.Add(Operation.Modulo, _modulo);
        }
    }
}

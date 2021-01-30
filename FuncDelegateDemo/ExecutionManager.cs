using System;
using System.Collections.Generic;

namespace FuncDelegateDemo
{
    public class ExecutionManager
    {
        private Func<int> add;
        private Func<int> subtract;
        private Func<int> multiply;
        private Func<int> divide;
        private Func<int> modulo;

        public ExecutionManager()
        {
            FuncExec = new Dictionary<Operation, Func<int>>(5);
        }

        public Dictionary<Operation, Func<int>> FuncExec { get; set; }

        public void PopulateFunc(Func<int> add, Func<int> subtract, Func<int> multiply, Func<int> divide, Func<int> modulo)
        {
            this.add = add;
            this.subtract = subtract;
            this.multiply = multiply;
            this.divide = divide;
            this.modulo = modulo;
        }

        public void PrepareFunc()
        {
            FuncExec.Add(Operation.Add, add);
            FuncExec.Add(Operation.Subtract, subtract);
            FuncExec.Add(Operation.Multiply, multiply);
            FuncExec.Add(Operation.Divide, divide);
            FuncExec.Add(Operation.Modulo, modulo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FuncDelDemo
{
    public class OperationManager
    {
        private int _firstOperand;
        private int _secondOperand;
        private readonly ExecutionManager _executionManager;

        public OperationManager(int first, int second, ExecutionManager execManager)
        {
            _firstOperand = first;
            _secondOperand = second;
            _executionManager = execManager;
            execManager.PopulateFunctions(Sum, Subtract, Multiply, Divide, Modulo);
            execManager.PrepareExecution();
        }

        public int Execute(Operation operation)
        {
            return _executionManager.FuncExecute.ContainsKey(operation) ? _executionManager.FuncExecute[operation]() : -1;
        }

        private int Sum()
        {
            return _firstOperand + _secondOperand;
        }

        private int Subtract()
        {
            return _firstOperand - _secondOperand;
        }

        private int Multiply()
        {
            return _firstOperand * _secondOperand;
        }

        private int Divide()
        {
            return _firstOperand / _secondOperand;
        }

        private int Modulo()
        {
            return _firstOperand % _secondOperand;
        }
    }
}

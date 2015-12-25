using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    ret: 18
    remove the top element from the stack and jump to it; empty stack = halt
    */
    public class ReturnOperation : IOperation
    {
        public int RequiredArgumentsCount
        {
            get
            {
                return 0;
            }
        }

        public ushort Calculate(Stack<ushort> stack, IMemory memory, ushort IP, ushort modulo, params ushort[] args)
        {
            if (stack.Count > 0)
            {
                return stack.Pop();
            }
            else return ushort.MaxValue;
        }
    }
}
using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    pop: 3 a
    remove the top element from the stack and write it into <a>; empty stack = error
    */
    public class PopOperation : IOperation
    {
        public int RequiredArgumentsCount
        {
            get
            {
                return 1;
            }
        }

        public ushort Calculate(Stack<ushort> stack, IMemory memory, ushort IP, ushort modulo, params ushort[] args)
        {
            var poped = stack.Pop();
            memory[args[0]] = poped;
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
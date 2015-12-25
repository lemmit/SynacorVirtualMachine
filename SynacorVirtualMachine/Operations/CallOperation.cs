using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    call: 17 a
    write the address of the next instruction to the stack and jump to <a>
    */
    public class CallOperation : IOperation
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
            stack.Push((ushort)(IP + 1 + RequiredArgumentsCount));
            var a = ProcessorHelpers.IsRegister(args[0]) ? memory[args[0]] : args[0];
            return a;
        }
    }
}
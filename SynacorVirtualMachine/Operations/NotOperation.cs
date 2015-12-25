using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    not: 14 a b
    stores 15-bit bitwise inverse of <b> in <a>
    */
    public class NotOperation : IOperation
    {
        public int RequiredArgumentsCount
        {
            get
            {
                return 2;
            }
        }

        public ushort Calculate(Stack<ushort> stack, IMemory memory, ushort IP, ushort modulo, params ushort[] args)
        {
            var b = ProcessorHelpers.IsRegister(args[1]) ? memory[args[1]] : args[1];
            memory[args[0]] = (ushort)(~b & 0x7FFF);
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
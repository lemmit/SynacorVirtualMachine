using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    jt: 7 a b
    if <a> is nonzero, jump to <b>
    */
    public class JumpIfNonZeroOperation : IOperation
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
            var a = ProcessorHelpers.IsRegister(args[0]) ? memory[args[0]] : args[0];
            var b = ProcessorHelpers.IsRegister(args[1]) ? memory[args[1]] : args[1];
            if (a != 0)
            {
                return b;
            }
            else
            {
                return (ushort)(IP + 1 + RequiredArgumentsCount);
            }
        }
    }
}
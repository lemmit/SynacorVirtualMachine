using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    eq: 4 a b c
    set <a> to 1 if <b> is equal to <c>; set it to 0 otherwise
    */
    public class SetIfEqualOperation : IOperation
    {
        public int RequiredArgumentsCount
        {
            get
            {
                return 3;
            }
        }

        public ushort Calculate(Stack<ushort> stack, IMemory memory, ushort IP, ushort modulo, params ushort[] args)
        {
            var b = ProcessorHelpers.IsRegister(args[1]) ? memory[args[1]] : args[1];
            var c = ProcessorHelpers.IsRegister(args[2]) ? memory[args[2]] : args[2];
            if (b == c)
            {
                memory[args[0]] = 1;
            }
            else
            {
                memory[args[0]] = 0;
            }
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
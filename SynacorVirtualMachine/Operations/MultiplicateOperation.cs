using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    mult: 10 a b c
    store into <a> the product of <b> and <c> (modulo 32768)
    */
    public class MultiplicateOperation : IOperation
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

            memory[args[0]] = (ushort)((b*c) % modulo);
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
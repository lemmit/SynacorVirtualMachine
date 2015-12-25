using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    rmem: 15 a b
    read memory at address <b> and write it to <a>
    */
    public class ReadMemoryOperation : IOperation
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
            memory[args[0]] = memory[b];
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
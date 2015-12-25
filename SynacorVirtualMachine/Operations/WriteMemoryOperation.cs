using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    wmem: 16 a b
    write the value from <b> into memory at address <a>
     */
    internal class WriteMemoryOperation : IOperation
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
            memory[a] = b;
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
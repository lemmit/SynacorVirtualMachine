using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    or: 13 a b c
    stores into <a> the bitwise or of <b> and <c>
    */
    public class OrOperation : IOperation
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
            memory[args[0]] = (ushort)(b | c);
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
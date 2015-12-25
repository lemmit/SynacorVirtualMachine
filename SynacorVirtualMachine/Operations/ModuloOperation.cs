using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    mod: 11 a b c
    store into <a> the remainder of <b> divided by <c>
    */
    public class ModuloOperation : IOperation
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
            if (!ProcessorHelpers.IsRegister(args[0]))
            {
                throw new ArgumentException();
            }
            memory[args[0]] = (ushort)(b%c);
            return (ushort)(IP+1+RequiredArgumentsCount);
        }
    }
}
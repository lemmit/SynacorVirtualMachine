using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    set: 1 a b
    set register <a> to the value of <b>
    */
    public class SetOperation : IOperation
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
            memory[args[0]] = b;
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    jmp: 6 a
    jump to <a>
    */
    public class JumpOperation : IOperation
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
            var a = ProcessorHelpers.IsRegister(args[0]) ? memory[args[0]] : args[0];
            return a;
        }
    }
}
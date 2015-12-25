using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    halt: 0
    stop execution and terminate the program
    */
    public class HaltOperation : IOperation
    {
        public int RequiredArgumentsCount
        {
            get
            {
                return 0;
            }
        }

        public ushort Calculate(Stack<ushort> stack, IMemory memory, ushort IP, ushort modulo, params ushort[] args)
        {
            return ushort.MaxValue;
        }
    }
}
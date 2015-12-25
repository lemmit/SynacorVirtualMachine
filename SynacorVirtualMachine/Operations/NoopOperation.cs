using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    noop: 21
    no operation
    */
    public class NoopOperation : IOperation
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
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
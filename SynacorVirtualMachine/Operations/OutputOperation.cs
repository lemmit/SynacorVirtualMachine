using SynacorVirtualMachine.IO;
using System;
using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    out: 19 a
    write the character represented by ascii code <a> to the terminal
    */

    public class OutputOperation : IOperation
    {
        private readonly IOutputWriter outputWriter;
        public OutputOperation(IOutputWriter writer)
        {
            outputWriter = writer;
        }

        public int RequiredArgumentsCount
        {
            get
            {
                return 1;
            }
        }

        public ushort Calculate(Stack<ushort> stack, IMemory memory, ushort IP, ushort modulo, params ushort[] args)
        {
            char a = (char)(ProcessorHelpers.IsRegister(args[0]) ? memory[args[0]] : args[0]);
            outputWriter.Write(a);
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
using SynacorVirtualMachine.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SynacorVirtualMachine.Operations
{
    /*
    in: 20 a
    read a character from the terminal and write its ascii code to<a>; it can be assumed that once input starts, it will continue until a newline is encountered; this means that you can safely read whole lines from the keyboard and trust that they will be fully read
    */
    public class InputOperation : IOperation
    {
        public int RequiredArgumentsCount
        {
            get
            {
                return 1;
            }
        }
        private readonly IInputReader reader;
        public InputOperation(IInputReader reader)
        {
            this.reader = reader;
        }
        public ushort Calculate(Stack<ushort> stack, IMemory memory, ushort IP, ushort modulo, params ushort[] args)
        {
            //var a = ProcessorHelpers.IsRegister(args[0]) ? memory[args[0]] : args[0];
            var c = reader.Read();
            memory[args[0]] = c;
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
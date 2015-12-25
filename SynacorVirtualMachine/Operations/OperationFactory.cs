using SynacorVirtualMachine.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVirtualMachine.Operations
{
    class OperationFactory : IOperationFactory
    {
        private readonly IInputReader inputReader;
        private readonly IOutputWriter outputWriter;
        public OperationFactory(IInputReader reader,
                                IOutputWriter writer)
        {
            inputReader = reader;
            outputWriter = writer;
        }
        public IOperation Create(ushort value)
        {
            switch (value)
            {
                /*
                == opcode listing ==
                halt: 0
                stop execution and terminate the program
                */
                case 0:
                    return new HaltOperation();
                /*
                set: 1 a b
                set register <a> to the value of <b>
                */
                case 1:
                    return new SetOperation();
                /*
                push: 2 a
                push <a> onto the stack
                */
                case 2:
                    return new PushOperation();
                /*pop: 3 a
                remove the top element from the stack and write it into <a>; empty stack = error*/
                case 3:
                    return new PopOperation();
                /*eq: 4 a b c
                set <a> to 1 if <b> is equal to <c>; set it to 0 otherwise
                */
                case 4:
                    return new SetIfEqualOperation();
                /*
                gt: 5 a b c
                set <a> to 1 if <b> is greater than <c>; set it to 0 otherwise
                */
                case 5:
                    return new SetIfGreaterOperation();
                /*
                jmp: 6 a
                jump to <a>
                */
                case 6:
                    return new JumpOperation();
                /*
                jt: 7 a b
                if <a> is nonzero, jump to <b>
                */
                case 7:
                    return new JumpIfNonZeroOperation();
                /*
                jf: 8 a b
                if <a> is zero, jump to <b>
                */
                case 8:
                    return new JumpIfZeroOperation();
                /*
                add: 9 a b c
                assign into <a> the sum of <b> and <c> (modulo 32768)
                */
                case 9:
                    return new AddOperation();
                /*
                mult: 10 a b c
                store into <a> the product of <b> and <c> (modulo 32768)
                */
                case 10:
                    return new MultiplicateOperation();
                /*
                mod: 11 a b c
                store into <a> the remainder of <b> divided by <c>
                */
                case 11:
                    return new ModuloOperation();
                /*
                and: 12 a b c
                stores into <a> the bitwise and of <b> and <c>
                */
                case 12:
                    return new AndOperation();
                /*
                or: 13 a b c
                stores into <a> the bitwise or of <b> and <c>
                */
                case 13:
                    return new OrOperation();
                /*
                not: 14 a b
                stores 15-bit bitwise inverse of <b> in <a>
                */
                case 14:
                    return new NotOperation();
                /*
                rmem: 15 a b
                read memory at address <b> and write it to <a>
                */
                case 15:
                    return new ReadMemoryOperation();
                /*
                wmem: 16 a b
                write the value from <b> into memory at address <a>
                */
                case 16:
                    return new WriteMemoryOperation();
                /*
                call: 17 a
                write the address of the next instruction to the stack and jump to <a>
                */
                case 17:
                    return new CallOperation();
                /*
                ret: 18
                remove the top element from the stack and jump to it; empty stack = halt
                */
                case 18:
                    return new ReturnOperation();
                /*
                out: 19 a
                write the character represented by ascii code <a> to the terminal
                */
                case 19:
                    return new OutputOperation(outputWriter);
                /*in: 20 a
                read a character from the terminal and write its ascii code to <a>; it can be assumed that once input starts, it will continue until a newline is encountered; this means that you can safely read whole lines from the keyboard and trust that they will be fully read
                */
                case 20:
                    return new InputOperation(inputReader);
                /*
                noop: 21
                no operation
                */
                case 21:
                    return new NoopOperation();
                default:
                    throw new ArgumentException();
            }
        }
    }
}

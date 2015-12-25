using System.Collections.Generic;

namespace SynacorVirtualMachine
{
    /*
    and: 12 a b c
    stores into <a> the bitwise and of <b> and <c>
    */
    public class AndOperation : IOperation
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
            PerformOperation(memory, modulo, args);
            return Destination(IP);
        }

        private ushort Destination(ushort IP)
        {
            return (ushort)(IP + 1 + (ushort)RequiredArgumentsCount);
        }

        private static void PerformOperation(IMemory memory, ushort modulo, ushort[] args)
        {
            var destination = args[0];
            var b = ProcessorHelpers.IsRegister(args[1]) ? memory[args[1]] : args[1];
            var c = ProcessorHelpers.IsRegister(args[2]) ? memory[args[2]] : args[2];
            memory[destination] = (ushort)(b & c);
        }
    }
}

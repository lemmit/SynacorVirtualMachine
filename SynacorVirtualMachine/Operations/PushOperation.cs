using System.Collections.Generic;

namespace SynacorVirtualMachine.Operations
{
    /*
    push: 2 a
    push <a> onto the stack
    */
    public class PushOperation : IOperation
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
            stack.Push(a);
            return (ushort)(IP + 1 + RequiredArgumentsCount);
        }
    }
}
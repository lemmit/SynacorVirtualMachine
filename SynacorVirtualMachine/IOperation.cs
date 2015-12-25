using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVirtualMachine
{
    public interface IOperation
    {
        int RequiredArgumentsCount { get; }
        ushort Calculate(Stack<ushort> stack, IMemory memory, ushort IP, ushort modulo, params ushort[] args);
    };
}

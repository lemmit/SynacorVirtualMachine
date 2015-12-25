using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVirtualMachine
{
    class Memory : IMemory
    {
        ushort[] mem;
        public Memory(int memorySize)
        {
            mem = new ushort[memorySize];
        }
        public void Initialize(ushort[] memory)
        {
            if (memory.Length > mem.Length)
            {
                throw new ArgumentException();
            }
            Array.Copy(memory, mem, memory.Length);
        }
        public ushort this[int index]
        {
            get
            {
                return mem[index];
            }
            set
            {
                mem[index] = value;
            }
        }
        public ushort[] Slice(int start, int count)
        {
            var slice = new ushort[count];
            Array.Copy(mem, start, slice, 0, count);
            return slice;
        }
    };
}

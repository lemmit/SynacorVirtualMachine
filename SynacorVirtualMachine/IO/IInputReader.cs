using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVirtualMachine.IO
{
    public interface IInputReader
    {
        ushort Read();
    }
}

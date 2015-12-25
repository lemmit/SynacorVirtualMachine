using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVirtualMachine
{
    public class ProcessorHelpers
    {
        public static bool IsRegister(int value)
        {
            return value >= 32768;
        }
    }
}

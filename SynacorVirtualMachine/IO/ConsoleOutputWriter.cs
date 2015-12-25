using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVirtualMachine.IO
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(char c)
        {
            System.Console.Write(c);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVirtualMachine.IO
{
    public class ConsoleInputReader : IInputReader
    {
        private static string _read = null;
        public ushort Read()
        {
            if (string.IsNullOrEmpty(_read))
            {
                _read = System.Console.ReadLine() + "\n";
            }
            var c = _read[0];
            _read = _read.Substring(1);
            return c;
        }
    }
}

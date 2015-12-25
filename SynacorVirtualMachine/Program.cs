using SynacorVirtualMachine.IO;
using SynacorVirtualMachine.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVirtualMachine
{
    
    class Program
    {
        static void Main(string[] args)
        {
            using (var br = new BinaryReader(File.OpenRead("../../challenge.bin")))
            {
                var lengthOfProgram = br.BaseStream.Length / sizeof(ushort);
                var programData = new ushort[lengthOfProgram];
                var dataPointer = 0;
                while(dataPointer < lengthOfProgram)
                {
                    programData[dataPointer++] = br.ReadUInt16();
                }

                ushort memorySpaceSize = 32768;
                int numberOfRegisters = 8;
                var processor = new SynacorVirtualMachineProcessor(
                    memorySpaceSize, 
                    new Memory(memorySpaceSize + numberOfRegisters), 
                    new OperationFactory(new ConsoleInputReader(), new ConsoleOutputWriter())
                );
                processor.InitializeMemory(programData);
                processor.Execute();

                System.Console.WriteLine("Execution finished... Press any key");
                System.Console.ReadLine();
            }
        }
    }
}

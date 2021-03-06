﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorVirtualMachine
{
    class SynacorVirtualMachineProcessor
    {
        private readonly IMemory memory;
        private ushort IP;
        private Stack<ushort> stack;
        private ushort memorySpace;
        private readonly IOperationFactory operationFactory;
        public SynacorVirtualMachineProcessor(ushort memorySpaceSize, IMemory memory, IOperationFactory factory)
        {
            this.stack = new Stack<ushort>();
            this.memorySpace = memorySpaceSize;
            this.memory = memory;
            this.operationFactory = factory;
        }
        public void InitializeMemory(ushort[] mem)
        {
            memory.Initialize(mem);
        }
        public void Execute()
        {
            while (IP < memorySpace)
            {
                var op = operationFactory.Create(memory[IP]);
                var args = memory.Slice(IP + 1, op.RequiredArgumentsCount);
                //DebugStep(op, args);
                IP = op.Calculate(stack,
                                memory,
                                IP,
                                memorySpace,
                                args);
            }
        }

        private void DebugStep(IOperation op, ushort[] args)
        {
            string shortOpCodeName = GetShortOperationName(op.GetType().Name);
            System.Console.Write($"[DEBUG] { shortOpCodeName, -12 } IP: {IP:x4} Args: ");
            foreach (var arg in args)
            {
                if (ProcessorHelpers.IsRegister(arg))
                {
                    System.Console.Write($"{arg}=>{memory[arg]}");
                }
                else
                {
                    System.Console.Write($"{arg}");
                }
                System.Console.Write(", ");
            }
            System.Console.WriteLine();
        }

        private static string GetShortOperationName(string fullOpCodeName)
        {
            return fullOpCodeName.Substring(0, fullOpCodeName.Length - "Operation".Length);
        }
    };
}

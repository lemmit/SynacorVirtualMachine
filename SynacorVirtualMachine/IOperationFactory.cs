namespace SynacorVirtualMachine
{
    public interface IOperationFactory
    {
        IOperation Create(ushort value);
    }
}
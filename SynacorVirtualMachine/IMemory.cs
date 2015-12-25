namespace SynacorVirtualMachine
{
    public interface IMemory
    {
        ushort this[int index] { get; set; }
        void Initialize(ushort[] memory);
        ushort[] Slice(int start, int count);
    }
}
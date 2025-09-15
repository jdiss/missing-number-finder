namespace MissingNumberFinder.MissingNumberFinderXor;
using MissingNumberFinder.Contracts;

public class XorAlgorithmDescriptor : IAlgorithmDescriptor<int>
{
    public string Name => "xor";
    public IMissingNumberFinder<int> CreateFinder() => new XorFinder();
}

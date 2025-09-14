namespace MissingNumberFinder.MissingNumberFinderXor;
using MissingNumberFinder.Contracts;

public class XorAlgorithmDescriptor : IAlgorithmDescriptor
{
    public string Name => "xor";
    public IMissingNumberFinder CreateFinder() => new XorFinder();
}

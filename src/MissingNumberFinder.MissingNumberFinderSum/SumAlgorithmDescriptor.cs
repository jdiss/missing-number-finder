namespace MissingNumberFinder.MissingNumberFinderSum;
using MissingNumberFinder.Contracts;

public class SumAlgorithmDescriptor : IAlgorithmDescriptor
{
    public string Name => "sum";
    public IMissingNumberFinder CreateFinder() => new SumFinder();
}

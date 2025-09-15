namespace MissingNumberFinder.MissingNumberFinderSum;
using MissingNumberFinder.Contracts;

public class SumAlgorithmDescriptor : IAlgorithmDescriptor<int>
{
    public string Name => "sum";
    public IMissingNumberFinder<int> CreateFinder() => new SumFinder();
}

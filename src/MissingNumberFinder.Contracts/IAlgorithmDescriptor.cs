namespace MissingNumberFinder.Contracts;

/// <summary>
/// Describes an algorithm for finding the missing number.
/// Provides a name and a method to create an instance of the algorithm.
/// </summary>
public interface IAlgorithmDescriptor<T>
{
    /// <summary>
    /// The name of the algorithm.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Creates an instance of the algorithm.
    /// </summary>
    /// <returns></returns>
    IMissingNumberFinder<T> CreateFinder();
}


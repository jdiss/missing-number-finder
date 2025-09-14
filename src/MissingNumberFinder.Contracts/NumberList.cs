namespace MissingNumberFinder.Contracts;
/// <summary>
/// Represents the missing number problem.
/// Contains the expected count (n+1) and the actual numbers.
/// </summary>
public record NumberList(int Count, IEnumerable<int> Numbers);

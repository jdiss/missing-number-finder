namespace MissingNumberFinder.Contracts;


/// <summary>
/// Defines a contract for finding the missing number in a list.
/// </summary>
public interface IMissingNumberFinder
{
    /// <summary>
    /// Finds the missing number in the provided list.
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    int FindMissingNumber(NumberList list);
}
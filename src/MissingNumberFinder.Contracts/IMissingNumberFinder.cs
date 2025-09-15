namespace MissingNumberFinder.Contracts;


/// <summary>
/// Defines a contract for finding the missing number in a list.
/// </summary>
public interface IMissingNumberFinder<T>
{
    /// <summary>
    /// Finds the missing number in the provided list.
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    T FindMissingNumber(NumberList list);
}
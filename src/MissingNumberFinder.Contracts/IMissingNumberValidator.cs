namespace MissingNumberFinder.Contracts;


/// <summary>
/// Defines a contract for finding the missing number in a list.
/// </summary>
public interface IMissingNumberValidator
{
     bool IsValid(NumberList list);
}
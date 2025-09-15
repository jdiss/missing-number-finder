namespace MissingNumberFinder.MissingNumberFinderXor;
using MissingNumberFinder.Contracts;

public class XorFinder : IMissingNumberFinder<int>
{
    public int FindMissingNumber(NumberList problem)
    {
        ArgumentNullException.ThrowIfNull(problem);

        int xor = 0;
        for (int i = 0; i < problem.Count; i++)
            xor ^= i;

        foreach (var num in problem.Numbers)
            xor ^= num;

        int missing = xor;

        // ✅ Verify the result is really a single missing number
        var set = new HashSet<int>(problem.Numbers);
        if (set.Contains(missing) || set.Count != problem.Count - 1)
        {
            throw new InvalidOperationException(
                $"Input must contain exactly one missing number in range 0..{problem.Count - 1}"
            );
        }

        return missing;
    }
}

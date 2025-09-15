namespace MissingNumberFinder.MissingNumberFinderSum;
using MissingNumberFinder.Contracts;

public class SumFinder : IMissingNumberFinder<int>
{
    public int FindMissingNumber(NumberList problem)
    {
       if (problem is null) throw new ArgumentNullException(nameof(problem));

        long expected = (long)(problem.Count - 1) * problem.Count / 2;
        long actual = problem.Numbers.Sum(x => (long)x);
        int missing = (int)(expected - actual);

        // ✅ Validation: must be exactly one missing
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

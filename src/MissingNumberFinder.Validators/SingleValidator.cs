using MissingNumberFinder.Contracts;
using System.Linq;

namespace MissingNumberFinder.Validators;

public class SingleValidator : IMissingNumberValidator
{
    public bool IsValid(NumberList nums)
    {
        ArgumentNullException.ThrowIfNull(nums);
        int num = nums.Numbers.Count();
        var seen = new HashSet<int>(num);

        foreach (var v in nums.Numbers)
        {
            if (v < 0 || v > num)
            {
                throw new ArgumentException(
                    $"Value {v} is outside expected range [0..{num}]. Input must contain distinct numbers taken from 0..n.",
                    nameof(nums));
            }

            if (!seen.Add(v))
            {
                throw new ArgumentException($"Duplicate value {v} found in input. Input must contain distinct numbers.", nameof(nums));
            }
        }

        return true;
    }
}

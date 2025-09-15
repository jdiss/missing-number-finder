using MissingNumberFinder.Contracts;
using MissingNumberFinder.MissingNumberFinderXor;
using MissingNumberFinder.MissingNumberFinderSum;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var provider = ConfigureServices();

            if (!TryParseArguments(args, out var numbers, out var algo))
                return;

            var problem = new NumberList(numbers.Length + 1, numbers);

            var descriptor = ResolveAlgorithm(provider, algo);
            if (descriptor == null)
                return;

            var finder = descriptor.CreateFinder();
            int missing = finder.FindMissingNumber(problem);

            Console.WriteLine($"✅ Algorithm: {descriptor.Name}, Missing number: {missing}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"⚠️ Input validation failed: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("⚠️ Input format error. Please use format like: \"[3,0,1]\"");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Unexpected error: {ex.Message}");
        }
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IAlgorithmDescriptor<int>, XorAlgorithmDescriptor>();
        services.AddSingleton<IAlgorithmDescriptor<int>, SumAlgorithmDescriptor>();
        return services.BuildServiceProvider();
    }

    private static bool TryParseArguments(string[] args, out int[] numbers, out string algo)
    {
        numbers = [];
        algo = "xor";

        if (args.Length == 0)
        {
            Console.WriteLine("Usage: MissingNumber.Cli <numbers> [algo]");
            Console.WriteLine("Example: MissingNumber.Cli \"[3,0,1]\" xor");
            return false;
        }

        string input = args[0];
        algo = args.Length > 1 ? args[1] : "xor";

        numbers = ParseInput(input);
        return true;
    }

    private static IAlgorithmDescriptor<int>? ResolveAlgorithm(ServiceProvider provider, string algo)
    {
        var algorithms = provider.GetServices<IAlgorithmDescriptor<int>>();
        var descriptor = algorithms.FirstOrDefault(a =>
            a.Name.Equals(algo, StringComparison.OrdinalIgnoreCase));

        if (descriptor == null)
        {
            Console.WriteLine($"Error: Algorithm '{algo}' not found.");
            Console.WriteLine($"Available algorithms: {string.Join(", ", algorithms.Select(a => a.Name))}");
            return null;
        }

        return descriptor;
    }

    private static int[] ParseInput(string input)
    {
        return input.Trim('[', ']')
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => int.Parse(s.Trim()))
                        .ToArray();
    }
}
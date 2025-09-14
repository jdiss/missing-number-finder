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
            // 1️⃣ Setup DI
            var services = new ServiceCollection();
            services.AddSingleton<IAlgorithmDescriptor, XorAlgorithmDescriptor>();
            services.AddSingleton<IAlgorithmDescriptor, SumAlgorithmDescriptor>();

            var provider = services.BuildServiceProvider();

            // 2️⃣ Parse input
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: MissingNumber.Cli <numbers> [algo]");
                Console.WriteLine("Example: MissingNumber.Cli \"[3,0,1]\" xor");
                return;
            }

            string input = args[0];
            string algo = args.Length > 1 ? args[1] : "xor";

            int[] numbers = ParseInput(input);
            var problem = new NumberList(numbers.Length + 1, numbers);

            // 3️⃣ Resolve algorithm
            var algorithms = provider.GetServices<IAlgorithmDescriptor>();
            var descriptor = algorithms.FirstOrDefault(a => 
                a.Name.Equals(algo, StringComparison.OrdinalIgnoreCase));

            if (descriptor == null)
            {
                Console.WriteLine($"Error: Algorithm '{algo}' not found.");
                Console.WriteLine($"Available algorithms: {string.Join(", ", algorithms.Select(a => a.Name))}");
                return;
            }

            // 4️⃣ Execute algorithm
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

    private static int[] ParseInput(string input)
    {
        return [.. input.Trim('[', ']')
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)];
    }
}

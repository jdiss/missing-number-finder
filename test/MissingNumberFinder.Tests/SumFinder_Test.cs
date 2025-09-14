using MissingNumberFinder.Contracts;
using MissingNumberFinder.MissingNumberFinderSum;
using System.Threading.Tasks;

namespace MissingNumberFinder.Tests;

public class SumFinderTest
{
    [Fact]
        public void FindsSingleMissingNumber()
        {
            var finder = new SumFinder();
            var problem = new NumberList(4, new[] { 3, 0, 1 });

            int result = finder.FindMissingNumber(problem);

            Assert.Equal(2, result);
        }
        [Fact]
        public void ThrowsIfMultipleMissingNumbers()
        {
            var finder = new SumFinder();
            var problem = new NumberList(4, [0, 2]);
            Assert.Throws<InvalidOperationException>(() => finder.FindMissingNumber(problem));
        }
        

        [Fact]
        public void ThrowsIfNoMissingNumber()
        {
            var finder = new SumFinder();
            var problem = new NumberList(3, new[] { 0, 1, 2 });
            Assert.Throws<InvalidOperationException>(() => finder.FindMissingNumber(problem));
        }
}

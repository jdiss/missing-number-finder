using System;
using System.Collections.Generic;
using MissingNumberFinder.Contracts;
using Xunit;

namespace MissingNumberFinder.Validators.Tests
{
    public class SingleValidatorTest
    {
        private readonly SingleValidator _validator = new SingleValidator();

        [Fact]
        public void IsValid_WithValidNumbers_ReturnsTrue()
        {
            var nums = new NumberList(4, new List<int> { 0, 1, 2, 3 });
            Assert.True(_validator.IsValid(nums));
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(5)]
        public void IsValid_WithNumberOutsideRange_ThrowsArgumentException(int invalidValue)
        {
            var nums = new NumberList(5, new List<int> { 0, 1, 2, 10, invalidValue });
            var ex = Assert.Throws<ArgumentException>(() => _validator.IsValid(nums));
            Assert.Contains("outside expected range", ex.Message);
        }

        [Fact]
        public void IsValid_WithDuplicateNumbers_ThrowsArgumentException()
        {
            var nums = new NumberList(4, new List<int> { 0, 1, 2, 2 });
            var ex = Assert.Throws<ArgumentException>(() => _validator.IsValid(nums));
            Assert.Contains("Duplicate value", ex.Message);
        }

        [Fact]
        public void IsValid_WithEmptyList_ReturnsTrue()
        {
            var nums = new NumberList(0, new List<int>());
            Assert.True(_validator.IsValid(nums));
        }
    }
}
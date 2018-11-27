using System;
using Xunit;

namespace Sample.Tests
{
    public class SampleClass_IsEven
    {
        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            var _sample = new SampleClass();
            var result = _sample.IsEven(1);

            Assert.False(result, "1 should not be even");
        }
    }
}

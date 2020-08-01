using System;
using Xunit;
using SampleLibrary;

namespace SampleLibrary.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var adder = new Adder();

            Assert.Equal(5, adder.Add(2, 3));
        }
    }
}

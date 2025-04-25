using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator.App.StringCalculator _calculator = new();

        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            Assert.Equal(0, _calculator.Add(""));
        }

        [Fact]
        public void Add_NewLinesAsDelimiters()
        {
            Assert.Equal(6, _calculator.Add("1\n2,3"));
        }

        [Fact]
        public void Add_CustomDelimiter()
        {
            Assert.Equal(3, _calculator.Add("//;\n1;2"));
        }

        [Fact]
        public void Add_Negatives_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _calculator.Add("1,-2,-3"));
            Assert.Contains("-2", ex.Message);
            Assert.Contains("-3", ex.Message);
        }

        [Fact]
        public void Add_SingleNumber_ReturnsNumber()
        {
            Assert.Equal(1, _calculator.Add("1"));
        }

        [Fact]
        public void Add_TwoNumbers_CommaSeparated()
        {
            Assert.Equal(3, _calculator.Add("1,2"));
        }
    }
}

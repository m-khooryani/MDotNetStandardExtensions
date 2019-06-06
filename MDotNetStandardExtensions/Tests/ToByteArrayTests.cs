using MStringExtensions;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tests
{
    [ExcludeFromCodeCoverage]
    public class ToByteArrayTests
    {
        [Fact]
        public void EmptyStringShouldReturnEmptyArray()
        {
            string s = "";
            var byteArray = s.ToByteArray();
            Assert.Empty(byteArray);
        }

        [Fact]
        public void Sample1()
        {
            string s = "0001FF03ABabAbaB";
            var byteArray = s.ToByteArray();
            byte[] expectedByteArray = new byte[] { 0x00, 0x01, 0xFF, 0x03, 0xAB, 0xAB, 0xAB, 0xAB };
            Assert.Equal(expectedByteArray, byteArray);
        }

        [Fact]
        public void Sample2()
        {
            string s = "00";
            var byteArray = s.ToByteArray();
            byte[] expectedByteArray = new byte[] { 0x00 };
            Assert.Equal(expectedByteArray, byteArray);
        }

        [Fact]
        public void NullStringShoudThrowArgumentNullException()
        {
            string s = null;
            Action action = () => s.ToByteArray();
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void OddLengthStringShouldThrowArgumentException()
        {
            string s = "1";
            Action action = () => s.ToByteArray();
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void NotValidCharsShouldThrowFormatException()
        {
            string s = "$%$%";
            Action action = () => s.ToByteArray();
            Assert.Throws<FormatException>(action);
        }

        [Fact]
        public void WhiteSpaceStringShouldThrowFormatException()
        {
            string s = "  ";
            Action action = () => s.ToByteArray();
            Assert.Throws<FormatException>(action);
        }
    }
}

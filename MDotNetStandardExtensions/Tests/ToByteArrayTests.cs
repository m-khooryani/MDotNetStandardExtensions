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
            var a = s.ToByteArray();
            Assert.Empty(a);
        }

        [Fact]
        public void Sample1()
        {
            string s = "0001FF03ABabAbaB";
            var a = s.ToByteArray();
            byte[] arr = new byte[] { 0x00, 0x01, 0xFF, 0x03, 0xAB, 0xAB, 0xAB, 0xAB };
            Assert.Equal(arr, a);
        }

        [Fact]
        public void Sample2()
        {
            string s = "00";
            var a = s.ToByteArray();
            byte[] arr = new byte[] { 0x00 };
            Assert.Equal(arr, a);
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

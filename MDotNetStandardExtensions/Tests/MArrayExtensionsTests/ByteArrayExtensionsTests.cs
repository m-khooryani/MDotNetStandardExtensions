using MArrayExtensions;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tests.MArrayExtensionsTests
{
    [ExcludeFromCodeCoverage]
    public class ByteArrayExtensionsTests
    {
        [Fact]
        public void EmptyArrayShoudReturnEmptyString()
        {
            byte[] array = new byte[0];
            string s = array.ToHex();
            Assert.Empty(s);
        }

        [Fact]
        public void NullArrayShoudThrowArgumentNullException()
        {
            byte[] array = null;
            Action action = () => array.ToHex();
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void NullArrayWithNullSeparatorShoudThrowArgumentNullException()
        {
            byte[] array = null;
            Action action = () => array.ToHex(null);
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void NullArrayWithSeparatorShoudThrowArgumentNullException()
        {
            byte[] array = null;
            Action action = () => array.ToHex("separator");
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Sample1WithoutSeparator()
        {
            byte[] array = new byte[] { 0x00, 0x56, 0xFF, 0xaB, 0x01 };
            string hex = array.ToHex();
            Assert.Equal("0056FFAB01", hex);
        }

        [Fact]
        public void NullSeparatorShouldBeIgnored()
        {
            byte[] array = new byte[] { 0x00, 0x56, 0xFF, 0xaB, 0x01 };
            string hex = array.ToHex(null);
            Assert.Equal("0056FFAB01", hex);
        }

        [Fact]
        public void Sample2WithSeparator()
        {
            byte[] array = new byte[] { 0x00, 0x56, 0xFF, 0xaB, 0x01 };
            string hex = array.ToHex("-");
            Assert.Equal("00-56-FF-AB-01", hex);
        }

        [Fact]
        public void ArrayWithOneElementWithSeparator()
        {
            byte[] array = new byte[] { 0x00 };
            string hex = array.ToHex("-");
            Assert.Equal("00", hex);
        }

        [Fact]
        public void ArrayWithOneElementWithoutSeparator()
        {
            byte[] array = new byte[] { 0x00 };
            string hex = array.ToHex();
            Assert.Equal("00", hex);
        }
    }
}

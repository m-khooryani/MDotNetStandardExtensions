using System;

namespace MStringExtensions
{
    public static class StringExtensions
    {
        public static byte[] ToByteArray(this string hex)
        {
            if (hex == null)
            {
                throw new ArgumentNullException(nameof(hex));
            }
            if(hex.Length % 2 != 0)
            {
                throw new ArgumentException("length of string must be an even number.");
            }
            byte[] bytes = new byte[hex.Length >> 1];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i >> 1] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}

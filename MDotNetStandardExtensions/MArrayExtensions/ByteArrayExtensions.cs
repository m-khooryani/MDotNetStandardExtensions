using System;
using System.Linq;

namespace MArrayExtensions
{
    public static class ByteArrayExtensions
    {
        public static string ToHex(this byte[] array, string separator)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            var a = array
                .Select(x => x.ToString("X2"))
                .ToArray();
            return string.Join(separator ?? "", a);
        }

        public static string ToHex(this byte[] array)
        {
            return array.ToHex("");
        }
    }
}

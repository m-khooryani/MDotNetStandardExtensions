using System.Text;

namespace MStringExtensions
{
    public static class StringExtensions
    {
        public static string Reverse(this string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = s.Length - 1; i>= 0; i--)
            {
                stringBuilder.Append(s[i]);
            }
            return stringBuilder.ToString();
        }
    }
}

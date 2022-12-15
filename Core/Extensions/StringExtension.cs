using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Trim off the last number of character that you want
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}

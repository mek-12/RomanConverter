using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RomanConvertApp.BLL
{
    public static class BooleanManager
    {
        private static Regex regex;
        private static Regex regexRoman;
        public static Regex GetIntRegex()
        {
            if(regex == null)
            {
                regex = new Regex(@"^[0-9]*$");
            }
            return regex;
        }

        public static Regex GetRomanRegex()
        {
            if (regexRoman == null)
            {
                regexRoman = new Regex(@"^[I|V|X|C|D|M|L]*$");
            }
            return regexRoman;
        }

        internal static bool IsANumber(string input)
        {
            return GetIntRegex().IsMatch(input);
        }

        internal static bool IsARomanNumber(string input)
        {
            bool isRoman = GetRomanRegex().IsMatch(input);

            return isRoman;
        }
    }
}

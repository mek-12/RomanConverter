using System.Text.RegularExpressions;

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
                regexRoman = new Regex(@"^(?=[MDCLXVI])M*(C[MD]|D?C{0,3})(X[CL]|L?X{0,3})(I[XV]|V?I{0,3})$");
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

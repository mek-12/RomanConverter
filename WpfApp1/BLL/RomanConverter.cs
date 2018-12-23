using System;
using System.Linq;

namespace RomanConvertApp.BLL
{
    public static class RomanConverter
    {

        private static string[] romanChars = { ".", "I", "V", "X", "C", "D", "M", "L" };
        private static string[] huns = { ".", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private static string[] tens = { ".", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private static string[] ones = { ".", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        //Charecter off huns,ones and tens

        private static char[] chuns= {'C','D','M'};
        private static char[] ctens = { 'X', 'L', 'C' };
        private static char[] cones = { 'I', 'V', 'X' };
        public static string ConvertToRoman(string input)
        {
            int length = input.Length;
            string result = "";
            int number;

            for (int i = 0; i < length; i++)
            {
                number = Int32.Parse(input[length - i - 1].ToString());
                if (number != 0)
                {
                    result = GetRomanFromStep(i, number)+ result;
                }
            }

            return result;
        }


        private static string GetRomanFromStep(int step, int number)
        {
            switch (step)
            {
                case 0:
                    return ones[number];
                case 1:
                    return tens[number];
                case 2:
                    return huns[number];
                case 3:
                    string thsand = "";

                    for (int i = 0; i < number; i++)
                    {
                        thsand = thsand + "M";
                    }
                    return thsand;
                    
            }
            return "";
        }



        public static string ConvertToNumber(string roman)
        {
            string result = "";

            result = GetOnesToNumber(ref roman, ones, cones)+ result;
            result = GetTensToNumber(ref roman, tens, ctens) + result;
            result = GetHunsToNumber(ref roman, huns, chuns) + result;
            result = GetThusToNumber(ref roman) + result;
            return result;
        }

        private static string GetOnesToNumber(ref string roman, string[] array, char[] chars)
        {
            return GetNumberForRoman(ref roman, array, chars);
        }

        private static string GetTensToNumber(ref string roman, string[] array, char[] chars)
        {
            
            return GetNumberForRoman(ref roman, array, chars);
        }

        private static string GetHunsToNumber(ref string roman, string[] array, char[] chars)
        {
            return GetNumberForRoman(ref roman, array,chars);
        }

        private static string GetThusToNumber(ref string roman)
        {
            return (roman.Length-1).ToString() ;
        }

        private static string GetNumberForRoman(ref string roman, string[] array, char[] chars)
        {
            string queryRoman = "";
            string realRoman = "";
            int realNumber;

            int romanLength = roman.Length;
            //Special case 
            if (roman[romanLength - 1] == chars[2])
            {
                if (roman[romanLength - 2] == chars[0])
                {
                    roman = roman.Substring(0, romanLength - 2);
                    return "9";
                }
                return "0";
            }

            //If the last character is "special1" or "secial2"
            if (roman[romanLength - 1] == chars[0] || roman[romanLength - 1] == chars[1])
            {
                for (int i = 1; i <= 4; i++)
                {
                    queryRoman = roman[romanLength - i].ToString() + queryRoman;
                    if (array.Contains(queryRoman))
                    {
                        realRoman = queryRoman;
                    }
                    else if (realRoman != "")
                    {
                        roman = roman.Substring(0, (romanLength - i + 1));
                        realNumber = Array.IndexOf(array, realRoman);
                        queryRoman = "";
                        realRoman = "";
                        return (realNumber).ToString();
                    }
                    else
                    {
                        queryRoman = "";
                        return "0";
                    }
                }
            }

            return "";
        }
    }
}

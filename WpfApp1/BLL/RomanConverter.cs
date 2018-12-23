using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanConvertApp.BLL
{
    public static class RomanConverter
    {

        private static string[] romanChars = { "", "I", "V", "X", "C", "D", "M", "L" };
        private static string[] huns = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private static string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private static string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        public static string ConvertToRoman( string input)
        {
            int length = input.Length;
            string result = "";
            int number;

            for (int i = (length - 1); i >= 0; i--)
            {
                number = Int32.Parse(input[i].ToString());
                if (number != 0) 
                {
                    result = GetRomanFromStep(i, number) + result;
                } 
            }

            return result;
        }


        private static string GetRomanFromStep(int step, int number)
        {
            switch (step)
            {
                case 0:
                    string thsand = "";

                    for (int i = 0; i < number; i++)
                    {
                        thsand = thsand + "M";
                    }
                    return thsand;
                case 1:
                    return huns[number];
                case 2:
                    return tens[number];
                case 3:
                    return ones[number];
            }
            return "";
        }



        public static string ConvertToNumber(string roman)
        {
            string result = "";

            result = GetOnesToNumber(ref roman)+ result;
            result = GetTensToNumber(ref roman) + result;
            result = GetHunsToNumber(ref roman) + result;

            return result;
        }


        private static string GetOnesToNumber(ref string roman)
        {
            string queryRoman = "";
            string realRoman = "";
            int realNumber;

            int romanLength = roman.Length;
            //Special case (IX)
            if (roman[romanLength - 1 ] == 'X')
            {
                if(roman[romanLength -2] == 'I')
                {
                    roman = roman.Substring(0, romanLength - 2);
                    return "9";
                }
                return "0";
            }

            //If the last character is "I" or "V"
            if (roman[romanLength - 1]=='I' || roman[romanLength - 1] == 'V')
            {
                for(int i = 1; i<=4; i++)
                {
                    queryRoman = roman[romanLength - i].ToString() + queryRoman;
                    if (ones.Contains(queryRoman))
                    {
                        realRoman = queryRoman;
                    }
                    else if(realRoman != "")
                    {
                        roman = roman.Substring(0,(romanLength - i + 1));
                        realNumber = Array.IndexOf(ones, realRoman);
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

        private static string GetTensToNumber(ref string roman)
        {
            string queryRoman = "";
            string realRoman = "";
            int realNumber;

            int romanLength = roman.Length;
            //Special case (XC)
            if (roman[romanLength - 1] == 'C')
            {
                if (roman[romanLength - 2] == 'X')
                {
                    roman = roman.Substring(0, romanLength - 2);
                    return "9";
                }
                return "0";
            }

            if (roman[romanLength - 1] == 'X' || roman[romanLength - 1] == 'L')
            {
                for (int i = 1; i <= 4; i++)
                {
                    queryRoman = roman[romanLength - i].ToString() + queryRoman;
                    if (tens.Contains(queryRoman))
                    {
                        realRoman = queryRoman;
                    }
                    else if (realRoman != "")
                    {
                        roman = roman.Substring(0, (romanLength - i + 1));
                        realNumber = Array.IndexOf(tens, realRoman);
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

        private static string GetHunsToNumber(ref string roman)
        {
            return "";
        }
    }
}

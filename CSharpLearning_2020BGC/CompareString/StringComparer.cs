using System;
using System.Collections.Generic;
using System.Text;

namespace CompareString
{
    public class StringComparer
    {
        public bool CompareString(string str1, string str2)
        {
            int minLength = Math.Min(str1.Length, str2.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (!CompareChar(str1[str1.Length - 1 - i], str2[str2.Length - 1 - i]))
                {
                    return false;
                }
            }
            return true;
        }
        private bool CompareChar(char char1, char char2)
        {
            if (char1 == '*' || char2 == '*')
            {
                return true;
            }
            else
            {
                return char1 == char2 || Char.ToLower(char1) == char2 || Char.ToUpper(char1) == char2;
            }
        }
    }
}

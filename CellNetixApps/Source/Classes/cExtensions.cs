using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellNetixApps.Source.Classes
{
    public static class cExtensions
    {
        public static string SetLength(this string str,int maxLength)
        {
            if (str.Length > maxLength)
                str = str.Substring(0, maxLength);
            return str;
        }

        public static string NoNull(this string str)
        {
            if (str == null)
                str = string.Empty;

            return str;
        }

        public static string IsNull(this string str,string newValue)
        {
            if (str == null)
                str = newValue;

            return str;
        }

        public static int IsNull(this int? oldValue, int newValue)
        {
            if (oldValue == null)
                oldValue = newValue;

            return Convert.ToInt32(oldValue);
        }


        public static int ToInt(this string str)
        {
            int num = 0;
            if (cMethods.isNumeric(str))
            {
                num = Convert.ToInt32(str);
            }

            return num;
        }
    }
}

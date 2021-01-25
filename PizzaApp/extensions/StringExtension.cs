using System;
namespace PizzaApp
{
    public static class StringExtension
    {
        public static string PremiereLettreMaj(this string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }

            string ret = str.ToLower();

            ret = ret.Substring(0, 1).ToUpper() + ret.Substring(1, ret.Length - 1);

            return ret;
        }


    }
}

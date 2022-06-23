using System;

namespace SpecTestProject.Models_and_Utils_for
{
    public static class TextUtils
    {
        public static int GetIntPrice(string price) 
        {
            try
            {
                price = price.Trim(new char[] { '$', '.' }).Replace(",", "");
                return Convert.ToInt32(price);
            }
            catch(System.FormatException ex)
            {
                return int.MaxValue;
            }
        }
    }
}

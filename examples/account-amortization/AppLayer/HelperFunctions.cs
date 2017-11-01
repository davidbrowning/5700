namespace AppLayer
{
    public static class HelperFunctions
    {
        /// <summary>
        /// Convert a dollar amount in a string to a decimal value.   The string may include a dollar signs ($)
        /// and negative amounts may be indicated by a minus signs or parantheses. Also, the string may include
        /// comma.  For example, here are some valid strings:
        /// 
        ///     123.45
        ///     $123.45
        ///     -$123.45
        ///     ($123.45)
        ///     -($123.45)
        ///     -(-($123.45))
        ///     $$$123.45
        ///     123,456.78
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ConvertToDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;

            var isNegative = false;
            while (value[0] == '(' && value[value.Length - 1] == ')')
            {
                isNegative = !isNegative;
                value = value.Substring(1, value.Length - 2).Trim();
            }

            while (value[0] == '-')
            {
                isNegative = !isNegative;
                value = value.Substring(1).Trim();
            }

            while (value[0] == '$')
                value = value.Substring(1).Trim();

            value = value.Replace(",", "");

            decimal result;
            decimal.TryParse(value, out result);

            if (isNegative)
                result = -result;
            return result;
        }

        /// <summary>
        /// Convert a string representation of a precentage to a double.  The string may include a "%" at the end.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ConvertToPercent(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;

            value = value.Trim();
            if (value[value.Length - 1] == '%')
                value = value.Substring(0, value.Length - 1).Trim();

            double result;
            double.TryParse(value, out result);
            result = result / 100;
            return result;
        }

        /// <summary>
        /// Convert an integer representation of a string to a integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ConvertToInt(string value)
        {
            var result = 0;
            if (!string.IsNullOrWhiteSpace(value))
            {
                int.TryParse(value, out result);
            }
            return result;
        }

    }
}

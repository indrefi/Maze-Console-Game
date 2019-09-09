using System.Text.RegularExpressions;

namespace Core.Utils
{
    public class InputFilters
    {
        /// <summary>Filters the string input.</summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string FilterStringInput(string input)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            var result = rgx.Replace(input, "");

            return result;
        }
    }
}

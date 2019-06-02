using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Task2.Abstracts;

namespace Task2.ReplaceRealizations
{
    class DateFindReplace : AbstractFindReplace
    {
        CultureInfo cultureUs = CultureInfo.CreateSpecificCulture("en-US");
        private static Regex regexDate = new Regex(@"(?x) (\b[0-2]\d| \b3[01]| \b\d) ([./-]) (0\d|1[0-2]|\d) \2 (\d{4}\b|\d{2}\b)", RegexOptions.Compiled);
        public override string ReplaceByRegex(string toReplaceDate)
        {
            return ReplaceInLine(toReplaceDate, regexDate);
        }
        public string ReplaceInLine(string toReplace, Regex regexPrecise)
        {
            toReplace = regexPrecise.Replace(toReplace, ReplaceDate);
            return toReplace;
        }
        string ReplaceDate(Match match)
        {
            DateTime dateTime;
            if (!DateTime.TryParse(match.Value, out dateTime))
                return match.Value;
            return dateTime.ToString("MMMM d, yyyy", cultureUs);
        }
    }
}

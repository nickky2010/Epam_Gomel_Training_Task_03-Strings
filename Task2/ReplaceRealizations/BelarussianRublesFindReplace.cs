using System.Text.RegularExpressions;
using Task2.Abstracts;

namespace Task2.ReplaceRealizations
{
    class BelarussianRublesFindReplace : AbstractFindReplace
    {
        private static Regex regexBelarussianRubles = new Regex(@"(\b\d{1,3}(\s+\d{3})*) *(?= belarusian roubles| blr)\b", RegexOptions.Compiled);
        public override string ReplaceByRegex(string toReplaceBelarussianRubles)
        {
            return ReplaceInLine(toReplaceBelarussianRubles, regexBelarussianRubles);
        }

        public string ReplaceInLine(string toReplace, Regex regexPrecise)
        {
            toReplace = regexPrecise.Replace(toReplace, ReplaceBelarussianRubles);
            return toReplace;
        }

        private string ReplaceBelarussianRubles(Match match)
        {
            return match.Value.Replace(" ", "");
        }
    }
}

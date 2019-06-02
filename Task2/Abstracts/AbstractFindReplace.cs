namespace Task2.Abstracts
{
    abstract class AbstractFindReplace
    {
        public abstract string ReplaceByRegex(string toReplace);

        public static string ReplaceIteration(AbstractFindReplace[] findReplaces, int index, string toIterate)
        {
            if (index == -1) return toIterate;
            if (index == 0) return findReplaces[index].ReplaceByRegex(toIterate);

            toIterate = findReplaces[index].ReplaceByRegex(toIterate);
            return ReplaceIteration(findReplaces, index - 1, toIterate); 
        }
    }
}

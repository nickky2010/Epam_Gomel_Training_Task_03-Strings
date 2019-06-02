using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = @"..\..\Input.txt";
            string outputFileName = @"..\..\Output.txt";
            string singleLineComments = @"//([\w\W]*?)\r?\n";               // одностроные комментарии (замена на пустую строку)
            string multiLineComments = @"/\*[\w\W]*?\*/";                   // многострочные комментарии 
            string line = @"(\w*\W*=\s*""(.*?)"";)|(\W*\(\s*""(.*?)""\);)"; // строка с ковычками (переноситься без изменений)
            string textPattern = singleLineComments + "|" + multiLineComments + "|" + line;
            try
            {
                string inputString = File.ReadAllText(inputFileName);
                Regex regex = new Regex(textPattern);
                string outputString = regex.Replace(inputString, ReplaceString);
                File.WriteAllText(outputFileName, outputString);
                Console.WriteLine("Comments was remove from file Input.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        static string ReplaceString(Match match)
        {
            if (match.Value.StartsWith("//"))
                return "\r\n";
            else if (match.Value.StartsWith("/*"))
                return String.Empty;
            else
                return match.Value;
        }
    }
}

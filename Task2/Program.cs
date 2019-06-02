using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Task2.Abstracts;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePathIn = @"..\..\in.txt";
            string filePathOut = @"..\..\out.txt";
            Type baseType = typeof(AbstractFindReplace);
            List<Type> childTypes = Assembly.GetAssembly(baseType).GetTypes().Where(type => type.IsSubclassOf(baseType)).ToList();
            AbstractFindReplace[] findReplaces = new AbstractFindReplace[childTypes.Count()];
            Type[] childTypesArray = childTypes.ToArray();
            for (int i = 0; i < findReplaces.Length; i++)
            {
                findReplaces[i] = (AbstractFindReplace)childTypesArray[i].GetConstructors()[0].Invoke(null);
            }
            if (File.Exists(filePathIn))
            {
                using (var streamReader = File.OpenText(filePathIn))
                {
                    using (TextWriter textWriter = new StreamWriter(File.Create(filePathOut)))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            textWriter.WriteLine(AbstractFindReplace.ReplaceIteration(findReplaces, findReplaces.Length - 1, streamReader.ReadLine()));
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File at path {0} is missing", filePathIn);
                Console.Read();
            }
        }
    }
}

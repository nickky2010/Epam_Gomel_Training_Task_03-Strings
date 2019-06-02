using System;
using System.IO;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\in.csv";
            if (File.Exists(filePath))
            {
                int i = 0;
                int countWrongIndecies = 0;
                double sum = 0;
                string plus = " + ";
                string minus = " - ";
                StringBuilder resultingString = new StringBuilder("result(");
                bool stringBeginning = true;
                using (StreamReader streamReader = new StreamReader(File.OpenRead(filePath)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        try
                        {
                            string input = streamReader.ReadLine();
                            string[] innerStrings = input.Split(';');
                            int index = int.Parse(innerStrings[0]);
                            try
                            {
                                double number = double.Parse(innerStrings[index]);
                                sum += number;
                                if (stringBeginning)
                                {
                                    resultingString.Append(number);
                                    stringBeginning = false;
                                }
                                else
                                {
                                    if (number < 0)
                                        resultingString.Append(minus).Append(-number);
                                    else
                                        resultingString.Append(plus).Append(number);
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("Index {0} is out of range for a string with {1} entries", index, innerStrings.Length);
                                countWrongIndecies++;
                            }
                        }
                        catch (FormatException)
                        {
                            countWrongIndecies++;
                        }
                        finally
                        {
                            i++;
                        }
                    }
                }
                resultingString.Append(") = ").Append(sum).Append("\nerror-lines = ").Append(countWrongIndecies);
                Console.WriteLine(resultingString);
            }
            else
                Console.WriteLine("File at path {0} is missing", filePath);
            Console.Read();
        }
    }
}
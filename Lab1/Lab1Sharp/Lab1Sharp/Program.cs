using System;
using System.IO;

namespace Lab1Sharp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            TextManager textManager = new TextManager();
            const string firstFileName = "first_file";
            const string secondFileName = "second_file";

            string str = "You are not special. " +
                         "You're not a beautiful and unique snowflake. " +
                         "You're the same decaying organic matter as everything else. " +
                         "We're all part of the same compost heap. " +
                         "We're all singing, all dancing crap of the world."
                ;
            string[] text = new string[] {str};
            fileManager.GenerateFile(firstFileName, text);
            string textFromFile1 = fileManager.ReadAllFromFile(firstFileName);

            fileManager.GenerateFile(secondFileName,
                textManager.DefineLongestInText(textManager.SplitTextToNewLines(textFromFile1)));
            fileManager.PrintFromFile(firstFileName);
            fileManager.PrintFromFile(secondFileName);
            Console.ReadKey();
        }
    }
}
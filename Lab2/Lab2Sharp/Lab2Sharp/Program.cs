using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab2Sharp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            GadgetManager gadgetManager = new GadgetManager();
            const string pathToFile1 = @"D:\BasicsOfProgramming(OOP)\Lab2\Lab2Sharp\Lab2Sharp\lab_files\gadgets";
            const string pathToFile2 =
                @"D:\BasicsOfProgramming(OOP)\Lab2\Lab2Sharp\Lab2Sharp\lab_files\not_warranty_gadgets";

            fileManager.FillFileFromConsole(pathToFile1);

            var gadgets = gadgetManager.GetGadgetsFromFile(pathToFile1);
            var warrantyGadgets = gadgetManager.GetNotWarrantyGadgets(gadgets);

            fileManager.CreateFile(pathToFile2, GadgetManager.ConvertGadgetsToText(warrantyGadgets));

            fileManager.PrintAllFile(pathToFile1);
            fileManager.PrintAllFile(pathToFile2);
            Console.ReadLine();
        }
    }
}
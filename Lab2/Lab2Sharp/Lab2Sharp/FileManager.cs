using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab2Sharp
{
    internal class FileManager
    {
        public void CreateFile(string pathToFile) //створення файлу
        {
            FileStream fileStream = new FileStream(pathToFile, FileMode.Create);
            fileStream.Close();
        }

        public void CreateFile(string pathToFile, string text) //створення файлу
        {
            FileStream fileStream = new FileStream(pathToFile, FileMode.Create);
            byte[] array = Encoding.Default.GetBytes(text);
            fileStream.Write(array, 0, array.Length);
            fileStream.Close();
        }

        public void AppendToFile(string pathToFile, string text) //доповнення файлу
        {
            FileStream fileStream = new FileStream(pathToFile, FileMode.Append);
            byte[] array = Encoding.Default.GetBytes(text + "\n");
            fileStream.Write(array, 0, array.Length);
            fileStream.Close();
        }

        public static string ReadAllFromFile(string pathToFile) //зчитування з файлу
        {
            FileStream fileStream = new FileStream(pathToFile, FileMode.Open);
            byte[] array = new byte[fileStream.Length];
            fileStream.Read(array, 0, array.Length);
            string textFromFile = Encoding.Default.GetString(array);
            fileStream.Close();
            return textFromFile;
        }

        public void PrintAllFile(string pathToFile) //вивід з файлу
        {
            Console.WriteLine($"\nFile name is: {pathToFile.Substring(pathToFile.LastIndexOf('\\') + 1)}");
            string[] text = ReadAllFromFile(pathToFile).Split('\n', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < text.Length; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine("Gadget");
                    Console.WriteLine($"Name: {text[i - 2]}");
                    Console.WriteLine($"Purchase date: {text[i - 1]}");
                    Console.WriteLine($"Warranty time: {text[i]}");
                    Console.WriteLine();
                }
            }
        }

        public void FillFileFromConsole(string pathToFile) //заповнення файлу з консолі
        {
            Console.Write("Enter number of gadgets: ");
            int gadgetCount = Convert.ToInt32(Console.ReadLine());
            var gadgets = new List<Gadget>();
            Gadget gadget = new Gadget();

            for (int i = 0; i < gadgetCount; i++)
            {
                Console.Write("Enter the name of gadget: ");
                string? inputName = Console.ReadLine();
                Console.Write("Enter gadget's date of purchase (dd.mm.yyyy): ");
                bool correctDate = DateTime.TryParse(Console.ReadLine(), out gadget.PurchaseDate);
                Console.Write("Enter gadget's warranty time (days): ");
                bool correctWarranty = uint.TryParse(Console.ReadLine(), out gadget.WarrantyTime);

                if (inputName != null && correctDate && correctWarranty)
                {
                    gadget.Name = inputName;
                    gadgets.Add(gadget);
                }

                Console.WriteLine();
            }

            CreateFile(pathToFile, GadgetManager.ConvertGadgetsToText(gadgets.ToArray()));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab2Sharp
{
    internal class GadgetManager
    {
        public Gadget[] GetGadgetsFromFile(string pathToFile) //зчитування інформації про гаджети з файлу
        {
            string[] textFromFile =
                FileManager.ReadAllFromFile(pathToFile).Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var gadgets = new List<Gadget>();
            Gadget gadget = new Gadget();

            for (int i = 0; i < textFromFile.Length; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    gadget.Name = textFromFile[i - 2];
                    gadget.PurchaseDate = DateTime.Parse(textFromFile[i - 1]);
                    gadget.WarrantyTime = uint.Parse(textFromFile[i]);
                    gadgets.Add(gadget);
                }
            }

            return gadgets.ToArray();
        }

        public Gadget[] GetNotWarrantyGadgets(Gadget[] gadgets) //отримати гаджети не на гарантії
        {
            DateTime currentTime = DateTime.Today;
            return gadgets.Where(gadget => gadget.PurchaseDate.AddDays(gadget.WarrantyTime) < currentTime).ToArray();
        }

        public static string ConvertGadgetsToText(Gadget[] gadgets) //перетворити інформацію про гаджети в текст
        {
            string text = string.Empty;
            foreach (Gadget gadget in gadgets)
            {
                text += $"{gadget.Name}\n{gadget.PurchaseDate.ToShortDateString()}\n{gadget.WarrantyTime}\n";
            }

            return text;
        }
    }
}
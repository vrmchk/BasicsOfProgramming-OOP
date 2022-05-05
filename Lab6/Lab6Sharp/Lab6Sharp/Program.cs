using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Lab6Sharp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            int[] nums = GetConsoleInput();
            FormulaTree tree = new FormulaTree('/');
            object[] values = {nums[3], '*', nums[0], '+', nums[2], nums[1]};

            foreach (object value in values)
            {
                tree.Insert(value);
            }

            Console.WriteLine($"\nLevel Traverse\n{tree.LevelTraverse()}");
            Console.WriteLine($"Preorder Traverse\n{tree.PreorderTraverse()}");
            Console.WriteLine($"Inorder Traverse\n{tree.InorderTraverse()}");
            Console.WriteLine($"Postorder Traverse\n{tree.PostorderTraverse()}");

            Console.ReadLine();
        }

        static int[] GetConsoleInput()
        {
            Console.WriteLine("Enter 4 numbers in formula (a*(b+c))/d:");
            int[] nums = new int[4];
            for (int i = 0; i < nums.Length; i++)
            {
                string? input = Console.ReadLine();
                while (!int.TryParse(input, out _))
                {
                    Console.WriteLine("Wrong input format");
                    input = Console.ReadLine();
                }

                nums[i] = int.Parse(input);
            }

            return nums;
        }
    }
}
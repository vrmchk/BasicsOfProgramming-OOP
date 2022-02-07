namespace Lab1Sharp;

internal class InputManager
{
    public void PrintInfoToUser() //вивести інформацію для вводу користувачу
    {
        Console.WriteLine("Press \"Shift + E\" to end entering text");
        Console.WriteLine("Enter your text:");
    }

    public string[] GetTextFromUser() //отримати текст від користувача
    {
        var text = new List<string>();
        string str = string.Empty;
        bool continueEntering = true;

        void AddStringToText()
        {
            if (str != string.Empty)
            {
                text.Add(str);
                str = string.Empty;
            }
        }

        while (continueEntering)
        {
            ConsoleKeyInfo keyInput = Console.ReadKey();

            switch (keyInput.Key)
            {
                case ConsoleKey.E when keyInput.Modifiers == ConsoleModifiers.Shift:
                    AddStringToText();
                    Console.CursorLeft--;
                    Console.Write(' ');
                    continueEntering = false;
                    break;
                case ConsoleKey.Enter:
                    AddStringToText();
                    Console.CursorTop++;
                    break;
                case ConsoleKey.Backspace:
                    str = str.Substring(0, str.Length - 1);
                    Console.Write(' ');
                    Console.CursorLeft--;
                    break;
                default:
                    str += keyInput.KeyChar;
                    break;
            }
        }

        return text.ToArray();
    }
}
namespace Lab1Sharp;

public class TextManager
{
    public string[] SplitTextToNewLines(string str) //розбивання речення по рядочкам
    {
        return str.Replace(". ", ".\n").Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }

    public string DefineLongestInString(string str) //знайти найдовше слово, поставити на початок його і довжину
    {
        string[] words = str.Split(new char[] {' ', ',', '.'}, StringSplitOptions.RemoveEmptyEntries);
        string maxWord = "";
        int lenOfMaxWord = 0;

        foreach (string word in words)
        {
            if (word.Length > lenOfMaxWord)
            {
                maxWord = word;
                lenOfMaxWord = word.Length;
            }
        }

        return $"[{lenOfMaxWord} {maxWord}] " + str;
    }

    public string[] DefineLongestInText(string[] text) //виконати завдання для всіх рядків
    {
        string[] resultText = new string[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            resultText[i] = DefineLongestInString(text[i]);
        }

        return resultText;
    }
}
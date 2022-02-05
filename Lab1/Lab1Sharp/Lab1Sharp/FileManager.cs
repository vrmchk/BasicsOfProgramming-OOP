namespace Lab1Sharp;

internal class FileManager
{
    public void GenerateFile(string fileName, string[] text) //створення і заповнення файлу
    {
        StreamWriter streamWriter = new StreamWriter(fileName, append: false);
        foreach (string line in text)
        {
            streamWriter.WriteLine(line);
        }

        streamWriter.Close();
    }

    public string ReadAllFromFile(string fileName) // зчитування тексту з першого файлу
    {
        StreamReader streamReader = new StreamReader(fileName);
        string text = streamReader.ReadToEnd();
        streamReader.Close();
        return text;
    }

    public void PrintFromFile(string fileName) // виведення тексту з файлу
    {
        StreamReader streamReader = new StreamReader(fileName);
        Console.WriteLine($"File name is {fileName}");
        Console.WriteLine(streamReader.ReadToEnd());
        streamReader.Close();
    }
}
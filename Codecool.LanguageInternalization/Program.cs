namespace Codecool.LanguageInternalization;

class Program
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;
    private static readonly char[] SpecialCharacters = { 'ö', 'ü', 'ä', 'ß' };

    public static void Main(string[] args)
    {
        var file = $"{WorkDir}\\Resources\\german-example.txt";

        // PrintSpecialCharacterStatistics(file);
        // WriteLinesWithSpecialCharacters(file);
        // WriteInternationalizedText(file);
        CountWordsWithSpecialCharacters(file);
    }

    private static void PrintSpecialCharacterStatistics(string file)
    {

        var reader = new StreamReader(file);
        try
        {
            string fileText = reader.ReadToEnd();
            Console.WriteLine(fileText);

            int countSpecialCharacters = 0;
            int allCharactersWithoutSpaces = 0;

            foreach (var character in fileText)
            {
                if (SpecialCharacters.Contains(character))
                {
                    countSpecialCharacters += 1;
                }
                if (!Char.IsWhiteSpace(character))
                {
                    allCharactersWithoutSpaces += 1;
                }
            }
            Console.WriteLine(countSpecialCharacters + " Special Characters");
            Console.WriteLine(((double)countSpecialCharacters / allCharactersWithoutSpaces) * 100 + " %");
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        finally
        {
            reader.Close();
        }
    }


    private static void WriteLinesWithSpecialCharacters(string file)
    {

        var reader = new StreamReader(file);
        var writer = new StreamWriter("Resources\\lines-with-special-characters.txt");
        try
        {
            string? readerLine = reader.ReadLine();
            while (readerLine != null)
            {
                if (readerLine.IndexOfAny(SpecialCharacters) >= 0)
                {
                    writer.WriteLine(readerLine);
                }
                readerLine = reader.ReadLine();
            }
            Console.WriteLine("The file writing operation was performed successfully!");

        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            reader.Close();
            writer.Close();
        }
    }

    private static void WriteInternationalizedText(string file)
    {
        var reader = new StreamReader(file);
        try
        {
            string fileText = reader.ReadToEnd();
            fileText = fileText.Replace("ö", "oe");
            fileText = fileText.Replace("ü", "ue");
            fileText = fileText.Replace("ä", "ae");
            fileText = fileText.Replace("ß", "ss");

            File.WriteAllText("Resources\\internationalized.txt", fileText);
            Console.WriteLine("The replacement operation is finished. The file writing operation was performed!");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            reader.Close();
        }
    }
    private static void CountWordsWithSpecialCharacters(string file)
    {
        Dictionary<string, int> wordsFrequency = new Dictionary<string, int>();
        var reader = new StreamReader(file);
        var writer = new StreamWriter("Resources\\count-by-words-with-special.txt");
        try
        {
            string fileText = reader.ReadToEnd();
            string[] words = fileText.Split(' ', ',', '.', '-', ':', '!', '\n', '"');
            foreach (var word in words)
            {
                if (word.IndexOfAny(SpecialCharacters) >= 0)
                {
                    if (!wordsFrequency.ContainsKey(word)) 
                    {
                        wordsFrequency.Add(word, 0);
                    }
                    wordsFrequency[word]++;
                }
            }
            foreach (var kvp in wordsFrequency)
            {
                writer.WriteLine(kvp.Key + " " + kvp.Value);
            }
            Console.WriteLine("The Words Frequency was written to file successfully!");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            reader.Close();
            writer.Close();
        }
    }
}

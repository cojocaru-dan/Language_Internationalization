namespace Codecool.LanguageInternalization;

class Program
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;
    private static readonly char[] SpecialCharacters = { 'ö', 'ü', 'ä', 'ß' };

    public static void Main(string[] args)
    {
        var file = $"{WorkDir}\\Resources\\german-example.txt";

        PrintSpecialCharacterStatistics(file);
        WriteLinesWithSpecialCharacters(file);
        WriteInternationalizedText(file);
    }

    private static void PrintSpecialCharacterStatistics(string file)
    {
    }


    private static void WriteLinesWithSpecialCharacters(string file)
    {
    }

    private static void WriteInternationalizedText(string file)
    {
    }
}

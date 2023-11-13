using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Reading Text File...");
        var phrase = File.ReadAllText(@"C:\Users\chris\Documents\Portfolio\WordCount\WordCount\WordCount\TextFile.txt");
        phrase = Regex.Replace(phrase, @"[^\w\d\s]", "");
        var wordCount = phrase.Split(' ').Length;
        Console.WriteLine(wordCount);
    }
}
public class Program
{
    public static List<char> Vowels = new List<char>() {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
    public static List<char> Punctuation = new List<char> { ',', ' ', ';', '.' };
    public static string vowelEnding = "yay";
    public static string standardEnding = "ay";
    public static void Main(string[] args)
    {
        Console.Write("Enter a Phrase: ");
        string phrase = Console.ReadLine();
        var splitPhrase = phrase.Split(new[] { ',', ' ', ';', '.' }).ToList();
        var splitPhraseWithPunctuation = phrase.ToList();
        var punctList = new List<char>();
        string newPhrase = String.Empty;
        for(int i = 0; i < splitPhrase.Count; i++)
        {
            if (!splitPhrase[i].Equals(""))
            {
                phrase = phrase.Replace(splitPhrase[i], ConvertWord(splitPhrase[i]));
            }       
        }

        Console.WriteLine(phrase);

    }

    public static string ConvertWord(string word)
    {
        var splitWord = word.ToList();
        if (splitWord.Any() && Vowels.Contains(splitWord[0]))
        {
            return word + vowelEnding;
        }

        string beginning = "";
        for(int i = 0; i < splitWord.Count; i++)
        {
            if (!Vowels.Contains(splitWord[i]))
            {
                beginning += splitWord[i];
                splitWord[i] = '\0';
            }
            else
            {
                break;
            }

        }

        string newWord = "";
        for(int i = 0; i < splitWord.Count; i++)
        {
            newWord += splitWord[i];
        }

        return newWord + beginning + standardEnding;

    }
}
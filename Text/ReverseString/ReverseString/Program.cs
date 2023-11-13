public class Program
{
    public static void Main(String[] args)
    {
        Console.Write("Enter a String: ");
        string phrase = Console.ReadLine();
        var phraseList = phrase.ToList();
        int end = phraseList.Count - 1;
        string newPhrase = "";
        for(int i = end; i >= 0; i--)
        {
            newPhrase += phraseList[i];
        }
        Console.WriteLine(newPhrase);
    }
}

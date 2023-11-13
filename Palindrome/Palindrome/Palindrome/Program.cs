public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a word or phrase: ");
        var phrase = Console.ReadLine().ToLower();
        var reversed = "";
        var phraseList = phrase.ToList();
        for(int i = phraseList.Count - 1; i >= 0; i--)
        {
            reversed += phraseList[i];
        }

        if (reversed.Equals(phrase))
        {
            Console.WriteLine("Your phrase is a palindrome");
        }
        else
        {
            Console.WriteLine("Your phrase is not a palindrome");
        }
    }
}
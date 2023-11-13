public class Program
{
    public static void Main(string[] args)
    {
        List<char> Vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u'};
        int a = 0, e = 0, i = 0, o = 0, u = 0;
        int vowelCount = 0;

        Console.Write("Enter a word or phrase: ");
        string phrase = Console.ReadLine().ToLower();
        
        foreach (char c in phrase)
        {
            if(Vowels.Contains(c))
            {
                vowelCount++;
                switch (c)
                {
                    case 'a':
                        a++;
                        break;
                    case 'e':
                        e++; 
                        break;
                    case 'i':
                        i++;
                        break;
                    case 'o':
                        o++;
                        break;
                    case 'u':
                        u++;
                        break;
                    default:
                        continue;
                }
            }
        }

        Console.WriteLine("Number of vowels: " +  vowelCount);
        Console.WriteLine("Number of A's: " + a);
        Console.WriteLine("Number of E's: " + e);
        Console.WriteLine("Number of I's: " + i);
        Console.WriteLine("Number of O's: " + o);
        Console.WriteLine("Number of U's: " + u);





    }
}

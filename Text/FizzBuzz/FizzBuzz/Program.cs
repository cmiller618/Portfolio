using System;

public class Program
{
    static public void Main(String[] args)
    {
        const int MAX_NUMBER = 100;
        List<string> Messages = new() { "Fizz", "Buzz" };
        List<int> Numbers = new() { 3, 5 };
        for (int i = 1; i <= MAX_NUMBER; i++)
        {
            if (i % Numbers[0] == 0 && i % Numbers[1] == 0)
                Console.WriteLine(Messages[0] + Messages[1]);
            else if (i % Numbers[0] == 0)
            {
                Console.WriteLine(Messages[0]);
            }
            else if (i % Numbers[1] == 0)
            {
                Console.WriteLine(Messages[1]);
            }
            else
            {
                Console.WriteLine(i);
            }

        }
    }

}

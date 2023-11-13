public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a Number: ");
        var number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter a different Number: ");
        var secondNumber = Convert.ToInt32(Console.ReadLine());

        while(number > 1000 || secondNumber > 1000)
        {
            Console.WriteLine("Numbers must be less than 1000");
            Console.WriteLine("Enter a Number: ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a different Number: ");
            secondNumber = Convert.ToInt32(Console.ReadLine());
        }
        
        int largerNumber = 0;
        int smallerNumber = 0;
        List<int> PrimeNumbers = new List<int>();
        if(number >= secondNumber)
        {
            largerNumber = number;
            smallerNumber = secondNumber;
            if (secondNumber <= 2)
            {
                PrimeNumbers.Add(2);
                PrimeNumbers.Add(3);
            }
            else if (secondNumber == 3) 
            {
                PrimeNumbers.Add(3);
            }
        }
        else
        {
            largerNumber = secondNumber;
            smallerNumber = number;
            if (number <= 2)
            {
                PrimeNumbers.Add(2);
                PrimeNumbers.Add(3);
            }
            else if (number == 3)
            {
                PrimeNumbers.Add(3);
            }
        }

        int primeNumber = smallerNumber;

        for(int i = smallerNumber; i <= largerNumber; i++)
        {
            bool isPrime = true;
            for(int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                }
            }
            if (isPrime)
            {
                PrimeNumbers.Add(i);
            }
        }

        for(int i = 0; i < PrimeNumbers.Count; i++)
        {
            Console.WriteLine(PrimeNumbers[i]);
        }
    }
}
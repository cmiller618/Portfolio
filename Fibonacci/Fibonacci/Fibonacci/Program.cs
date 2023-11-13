public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a Number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int firstnumber = 0; int secondnumber = 1; int temp = 0;
        Console.WriteLine(firstnumber);
        Console.WriteLine(secondnumber);
        while (temp <= number)
        {
            temp = firstnumber + secondnumber;
            if (temp > number) 
            {
                break;
            }
            Console.WriteLine(temp);
            firstnumber = secondnumber; 
            secondnumber = temp;
        } 
    }
}
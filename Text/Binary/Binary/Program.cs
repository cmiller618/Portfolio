using System.Xml.Schema;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Binary or Decimal: ");
        var choice = Console.ReadLine().ToLower();
        while(!choice.Equals("binary") && !choice.Equals("decimal"))
        {
            Console.Write("Please Enter a Valid Selection(binary or decimal): ");
            choice = Console.ReadLine().ToLower();
        }
        string number = "";
        if (choice.Equals("binary"))
        {
            Console.Write("Enter a binary number: ");
            number = Console.ReadLine().Trim();
            var numberList = number.ToList();
            
            while (ValidBinary(numberList))
            {
                Console.Write("Please Enter a Valid binary number: ");
                number = Console.ReadLine().Trim();
                numberList = number.ToList();
            }
            int total = 0;
            int digit = 1;
            
            for(int i = numberList.Count - 1; i >= 0; i--)
            {
                if (numberList[i].Equals('1'))
                {
                    total += digit;
                }
                digit *= 2;
            }
            Console.WriteLine("Your binary number in decimal is: " + total);
        }
        else
        {
            Console.Write("Enter a decimal number: ");
            number = Console.ReadLine().Trim();
            var numberList = number.ToList();
            while (!ValidDecimal(numberList))
            {
                Console.Write("Please Enter a Valid decimal number: ");
                number = Console.ReadLine().Trim();
                numberList = number.ToList();
            }
            int decimalNumber = Convert.ToInt32(number);
            int digit = 1;
            string binaryNumber = "";
            while(digit <= decimalNumber && decimalNumber >= digit * 2)
            {
                digit *= 2;
            }
            int total = decimalNumber;
            while(total > 0)
            {
                if(total >= digit && total < digit * 2)
                {
                    binaryNumber += "1";
                    total -= digit;
                }
                else
                {
                    binaryNumber += "0";
                }
                digit /= 2;
            }
            
            while(digit > 1)
            {
                binaryNumber += "0";
                digit /= 2;
                if(digit == 1)
                {
                    binaryNumber += "0";
                }
            }

            Console.WriteLine(binaryNumber);
        }
        
    }

    public static bool ValidBinary(List<char> numbers)
    {
        foreach (char num in numbers)
        {
            if (num > '1')
            {
                return false;
            }
        }
        return true;
    }

    public static bool ValidDecimal(List<char> numbers) 
    {
        foreach (char num in numbers)
        {
            if (!char.IsDigit(num))
            {
                return false;
            }
        }
        return true;
    }
}
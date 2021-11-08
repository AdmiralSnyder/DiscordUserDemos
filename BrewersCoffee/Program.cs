#nullable disable
class BrewersCoffee
{
    /*
 Assignment 11 Brewers Coffee
- Have the user enter 4 monthly coffee pounds sales to put into an array. See below for input/output. 
- Do not need a class. 
- Declare the array as a class level variable (can be used in all methods). 
- Create a method with a for loop to enter pounds into the array. 
- Code TryParse to accept only valid numbers.  
- Create other methods to 
  1: List pounds with average using a foreach loop; 
  2: List pounds with average using a for loop; 
3; Determine the highest pounds using a for loop; and 
4: have the user enter a month to determine number of months that pounds falls below month entered. 

- Call all methods from the main. Use C# Coding Standards. 

 */

    static double[] CoffeeSales = new double[4];

    public static void Main(string[] args)
    {
        Introduction();
        GetUserInput();
        Console.WriteLine($"Enter {CoffeeSales.Length} months of coffee pound sales");
        Console.WriteLine("***********************************");
        DisplayValuesFor();
        Console.WriteLine("***********************************");
        DisplayValuesForEach();
        Console.WriteLine("***********************************");
        Console.WriteLine($"Highest Pounds is { GetHighestValue() }");
        Console.WriteLine("***********************************");
        HandleLowMonths();
        Console.WriteLine("***********************************");
        Console.ReadLine();
    }

    private static void HandleLowMonths()
    {
        double threshold = GetDouble("Find Months lower than:");
        Console.Write("Find Months lower than: ");
        int count = 0;
        for (int i = 0; i < CoffeeSales.Length; i++)
        {
            if (CoffeeSales[i] < threshold)
            {
                count++;
            }
        }
        Console.WriteLine($"There are {count} months lower than {threshold}");
    }

    private static void GetUserInput()
    {
        for (int i = 0; i < CoffeeSales.Length; i++)
        {
            var sale = GetDouble($"Enter pounds month {i + 1}: ");
            CoffeeSales[i] = sale;
        }
    }

    private static void Introduction() => Console.WriteLine($@"
    Monthly Pounds Report
    Your Name
    {DateTime.Today.ToShortDateString()}");

    private static double GetDouble(string message)
    {
        Console.Write(message);
        while (true)
        {
            string line = Console.ReadLine();
            if (double.TryParse(line, out var value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("incorrect value");
            }
        }
    }

    private static void DisplayValuesForEach()
    {
        double avg = 0;

        Console.WriteLine("Display Pounds For Each Loop");
        foreach (var value in CoffeeSales)
        {
            Console.WriteLine($"\t\t{value}");
            avg += value;
        }
        avg /= CoffeeSales.Length;
        Console.WriteLine($"Average Pounds is {avg}.");
    }

    private static void DisplayValuesFor()
    {
        double avg = 0;

        Console.WriteLine("Display Pounds For Loop");
        for (int i = 0; i < CoffeeSales.Length; i++)
        {
            var value = CoffeeSales[i];

            Console.WriteLine($"\t\t{value}");
            avg += value;
        }
        avg /= CoffeeSales.Length;
        Console.WriteLine($"Average Pounds is {avg}.");
    }

    private static double GetHighestValue()
    {
        double maximum = double.MinValue;
        for (int i = 0; i < CoffeeSales.Length; i++)
        {
            if (CoffeeSales[i] > maximum)
            {
                maximum = CoffeeSales[i];
            }
        }

        return maximum;
    }
}

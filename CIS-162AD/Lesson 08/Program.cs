namespace Lesson_08
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Fraction Calculator!");

            do
            {
                int mode = getMenuSelection();
                if (mode == 5)
                {
                    Console.WriteLine("Goodbye.");
                    return;
                }
                else
                {
                    calculateResult(mode);
                }
            }while(true);
        }

        static int getIntInput()
        {
            do
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }while(true);
        }

        static Fraction getFracInput()
        {
            do
            {
                try
                {
                    return Fraction.Parse(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid fraction with a denominator that is not 0. Format: #/#.");
                }
            }while(true);
        }

        static int getMenuSelection()
        {
            Console.WriteLine("\nSelect an operation:");
            Console.WriteLine("  1.  Add");
            Console.WriteLine("  2.  Subtract");
            Console.WriteLine("  3.  Multiply");
            Console.WriteLine("  4.  Divide");
            Console.WriteLine("  5.  Exit");
            Console.Write("Input: ");
            return getIntInput();
        }

        static void calculateResult(int mode)
        {
            Fraction frac1, frac2, result;
            
            Console.WriteLine("Enter the first fraction: (format: #/#)");
            frac1 = getFracInput();
            Console.WriteLine("Enter the second fraction: (format: #/#)");
            frac2 = getFracInput();
            
            switch (mode)
            {
                case 1:
                    // Add
                    result = frac1 + frac2;
                    Console.WriteLine($"Addition: {result}");
                    break;

                case 2:
                    // Subtract
                    result = frac1 - frac2;
                    Console.WriteLine($"Subtraction: {result}");
                    break;

                case 3:
                    // Multiply
                    result = frac1 * frac2;
                    Console.WriteLine($"Multiplication: {result}");
                    break;

                case 4:
                    // Divide
                    result = frac1 / frac2;
                    Console.WriteLine($"Division: {result}");
                    break;

                default:
                    // Invalid
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }            
    }
}
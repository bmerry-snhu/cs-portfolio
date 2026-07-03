namespace Lesson_06
{
    public class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction();
            Fraction f2 = new Fraction();
            bool shouldExit = false;

            Console.WriteLine("For the first fraction...");
            f1.Enter();
            Console.WriteLine("For the second fraction...");
            f2.Enter();
            do
            {
                calculateResult(getMenuSelection(), f1, f2, ref shouldExit);
            } while (!shouldExit);
        }

        static int getIntInput()
        {
            while (true)
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }
        }

        static int getMenuSelection()
        {
            Console.WriteLine("Select an operation:");
            Console.WriteLine("  1.  Add");
            Console.WriteLine("  2.  Subtract");
            Console.WriteLine("  3.  Multiply");
            Console.WriteLine("  4.  Divide");
            Console.WriteLine("  5.  Exit");
            Console.Write("Input: ");
            return getIntInput();
        }

        static void calculateResult(int mode, Fraction frac1, Fraction frac2, ref bool shouldExit)
        {
            Fraction result = new Fraction();

            switch (mode)
            {
                case 1:
                    // Add
                    result = result.Add(frac1, frac2);
                    Console.WriteLine($"Addition: {result}");
                    shouldExit= true;
                    break;

                case 2:
                    // Subtract
                    result = result.Subtract(frac1, frac2);
                    Console.WriteLine($"Subtraction: {result}");
                    shouldExit = true;
                    break;

                case 3:
                    // Multiply
                    result = result.Multiply(frac1, frac2);
                    Console.WriteLine($"Multiplication: {result}");
                    shouldExit = true;
                    break;

                case 4:
                    // Divide
                    result = result.Divide(frac1, frac2);
                    Console.WriteLine($"Division: {result}");
                    shouldExit = true;
                    break;

                case 5:
                    // Exit
                    Console.WriteLine("Goodbye.");
                    shouldExit = true;
                    break;

                default:
                    // Invalid
                    Console.WriteLine("Invalid input. Please start over again.");
                    break;
            }
        }            
    }
}
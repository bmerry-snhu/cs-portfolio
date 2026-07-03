int i1;
int i2;
int result;
int userSel;
bool exitCode = false;

while (exitCode == false)
{
    Console.Write("Enter the first integer: ");
    i1 = int.Parse(Console.ReadLine());
    Console.Write("Enter the second integer: ");
    i2 = int.Parse(Console.ReadLine());
    Console.WriteLine("Select an operation:");
    Console.WriteLine("  1.  Add");
    Console.WriteLine("  2.  Subtract");
    Console.WriteLine("  3.  Multiply");
    Console.WriteLine("  4.  Divide");
    Console.WriteLine("  5.  Exit");
    Console.Write("Input: ");
    userSel = int.Parse(Console.ReadLine());

    switch (userSel)
    {
        case 1:
            // Add
            result = i1 + i2;
            Console.WriteLine($"Addition: {i1} + {i2} = {result}");
            break;

        case 2:
            // Subtract
            result = i1 - i2;
            Console.WriteLine($"Subtraction: {i2} - {i2} = {result}");
            break;

        case 3:
            // Multiply
            result = i1 * i2;
            Console.WriteLine($"Multiplication: {i1} x {i2} = {result}");
            break;

        case 4:
            // Divide
            if (i2 != 0)
            {
                result = i1 / i2;
                Console.WriteLine($"Division: {i1} / {i2} = {result}");
            }
            else
            {
                Console.WriteLine("Division Error: Cannot divide by 0.");
            }
            break;

        case 5:
            // Exit
            Console.WriteLine("Goodbye.");
            exitCode = true;
            break;

        default:
            // Invalid
            Console.WriteLine("Invalid input. Please start over again.");
            break;
    }
}
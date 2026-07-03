int i1;
int i2;
bool shouldExit = false;

while (!shouldExit)
{
    Console.Write("Enter the first integer: ");
    i1 = getIntInput();
    Console.Write("Enter the second integer: ");
    i2 = getIntInput();
    calculateResult(getMenuSelection(), i1, i2, ref shouldExit);
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

static void calculateResult(int mode, int val1, int val2, ref bool shouldExit)
{
    int result;

    switch (mode)
    {
        case 1:
            // Add
            result = val1 + val2;
            Console.WriteLine($"Addition: {val1} + {val2} = {result}");
            break;

        case 2:
            // Subtract
            result = val1 - val2;
            Console.WriteLine($"Subtraction: {val1} - {val2} = {result}");
            break;

        case 3:
            // Multiply
            result = val1 * val2;
            Console.WriteLine($"Multiplication: {val1} x {val2} = {result}");
            break;

        case 4:
            // Divide
            if (val2 != 0)
            {
                result = val1 / val2;
                Console.WriteLine($"Division: {val1} / {val2} = {result}");
            }
            else
            {
                Console.WriteLine("Division Error: Cannot divide by 0.");
            }
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
namespace Lesson_09
{
    public class Program
    {
        const int MaxLines = 100;
        static Fraction[] fractions = new Fraction[MaxLines];
        static int currentFrac = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fraction Sorter!");
            do
            {
                int mode = getMenuSelection();
                switch (mode)
                {
                    case 1:
                        // Save new list of Fractions
                        Console.Write("Please enter the path of the file to write: ");
                        writeFile(Console.ReadLine());
                        break;

                    case 2:
                        // Retrieve previous list of Fractions
                        Console.Write("Please enter the path of the file to read: ");
                        readFile(Console.ReadLine());
                        break;

                    case 3:
                        // Exit
                        Console.WriteLine("Goodbye.");
                        return;

                    default:
                        // Invalid
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
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
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR: {e.Message}");
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
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR: {e.Message}");
                }
            }while(true);
        }

        static int getMenuSelection()
        {
            Console.WriteLine("\nSelect an operation:");
            Console.WriteLine("  1.  Save new list of Fractions");
            Console.WriteLine("  2.  Retrieve previous list of Fractions");
            Console.WriteLine("  3.  Exit");
            Console.Write("Input: ");
            return getIntInput();
        }

        static void writeFile(string filePath)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(filePath);

                int numFracs = 0;
                do
                {
                    Console.Write("How many Fractions would you like to enter (Max: 100)? ");
                    numFracs = getIntInput();
                    if (numFracs > MaxLines)
                        Console.WriteLine("ERROR: The number of fractions must be below 100.");
                }while(numFracs > MaxLines);

                for (int i = 0; i < numFracs; i++)
                {
                    Console.Write($"Enter Fraction #{i+1} (format: #/#): ");
                    fractions[currentFrac++] = getFracInput();
                }

                Array.Sort(fractions);

                foreach (Fraction f in fractions)
                    writer.WriteLine(f);

                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }

        static void readFile(string filePath)
        {
            try
            {
                FileStream fileStream = File.Open(filePath, FileMode.Open);
                StreamReader reader = new StreamReader(fileStream);

                do
                {
                    string fileString = reader.ReadLine();
                    Console.WriteLine(fileString);
                }while(reader.Peek() != -1);

                reader.Close();
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }
    }
}
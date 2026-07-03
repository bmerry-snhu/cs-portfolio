namespace Lesson_10
{
    public class Program
    {
        static List<Fraction> fractions = new List<Fraction>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fraction Sorter!");
            do
            {
                int mode = getMenuSelection();
                switch (mode)
                {
                    case 1:
                        // Add a Fraction
                        addFraction();
                        break;

                    case 2:
                        // Display the Fractions
                        displayFractions();
                        break;

                    case 3:
                        // Sort the Fractions
                        sortFractions();
                        break;

                    case 4:
                        // Save the Fractions
                        Console.Write("Please enter the path of the file to save: ");
                        writeFile(Console.ReadLine());
                        break;

                    case 5:
                        // Load Fractions
                        Console.Write("Please enter the path of the file to load: ");
                        readFile(Console.ReadLine());
                        break;

                    case 6:
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
            Console.WriteLine("  1. Add a Fraction");
            Console.WriteLine("  2. Display the Fractions");
            Console.WriteLine("  3. Sort the Fractions");
            Console.WriteLine("  4. Save the Fractions");
            Console.WriteLine("  5. Load Fractions");
            Console.WriteLine("  6. Exit");
            Console.Write("Input: ");
            return getIntInput();
        }

        static void addFraction()
        {
            Console.Write($"Enter the new Fraction (format: #/#): ");
            fractions.Add(getFracInput());
            Console.WriteLine("Added the new Fraction!");
        }

        static void displayFractions()
        {
            foreach (Fraction f in fractions)
                Console.WriteLine(f);
        }

        static void sortFractions()
        {
            fractions.Sort();
            Console.WriteLine("Fractions sorted!");
        }

        static void writeFile(string filePath)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(filePath);

                foreach (Fraction f in fractions)
                    writer.WriteLine(f);

                writer.Close();
                Console.WriteLine("File saved!");
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

                fractions.Clear();

                do
                {
                    string fileString = reader.ReadLine();
                    fractions.Add(Fraction.Parse(fileString));
                }while(reader.Peek() != -1);

                reader.Close();
                fileStream.Close();
                Console.WriteLine("File loaded!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }
    }
}
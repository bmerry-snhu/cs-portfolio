public class Fraction
{
    // Apologies, I went a little out of scope of the lesson here.
    // I applied some concepts I've learned in other OOP courses to accomplish what I wanted more easily.

    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("The denominator cannot be zero.");
        }
        Numerator = numerator;
        Denominator = denominator;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of fractions you want to average: ");
        int numFracs = getIntInput();

        Fraction[] fracs = new Fraction[numFracs];

        for (int i = 0; i < numFracs; i++)
        {
            Console.WriteLine($"Enter the numerator for fraction {i + 1}: ");
            int getNumerator = getIntInput();
            Console.WriteLine($"Enter the denominator for fraction {i + 1}: ");
            int getDenominator = getIntInput();
            fracs[i] = new Fraction(getNumerator, getDenominator);
        }

        Fraction sum = new Fraction(0, 1);

        foreach (Fraction frac in fracs)
        {
            sum = addFractions(sum, frac);
        }

        Fraction average = divideFractions(sum, new Fraction(numFracs, 1));

        Console.WriteLine($"The average of the fractions is: {average}");
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

    static Fraction addFractions(Fraction firstFrac, Fraction secondFrac)
    {
        int newNumerator = (firstFrac.Numerator * secondFrac.Denominator) + (secondFrac.Numerator * firstFrac.Denominator);
        int newDenominator = firstFrac.Denominator * secondFrac.Denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    static Fraction divideFractions(Fraction firstFrac, Fraction secondFrac)
    {
        int newNumerator = firstFrac.Numerator * secondFrac.Denominator;
        int newDenominator = firstFrac.Denominator * secondFrac.Numerator;
        return new Fraction(newNumerator, newDenominator);
    }
}

namespace Lesson_06
{
    public class Fraction
    {
        private int Numerator;
        private int Denominator;

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("The denominator cannot be zero.");
            }
            Numerator = numerator;
            Denominator = denominator;
        }

        private int getIntInput()
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

        private bool denominatorIsValid()
        {
            return Denominator != 0;
        }

        public void Display()
        {
            Console.Write($"{Numerator}/{Denominator}");
        }

        public void Enter()
        {
            Console.Write("Enter numerator: ");
            Numerator = getIntInput();
            do
            {
                Console.Write("Enter denominator: ");
                Denominator = getIntInput();

                if (Denominator == 0)
                {
                    Console.WriteLine("The denominator cannot be zero.");
                }
            } while (!denominatorIsValid());
        }

        public Fraction Add(Fraction firstFrac, Fraction secondFrac)
        {
            int newNumerator = (firstFrac.getNumerator() * secondFrac.getDenominator()) + (secondFrac.getNumerator() * firstFrac.getDenominator());
            int newDenominator = firstFrac.getDenominator() * secondFrac.getDenominator();
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Subtract(Fraction firstFrac, Fraction secondFrac)
        {
            int newNumerator = (firstFrac.getNumerator() * secondFrac.getDenominator()) - (secondFrac.getNumerator() * firstFrac.getDenominator());
            int newDenominator = firstFrac.getDenominator() * secondFrac.getDenominator();
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Multiply(Fraction firstFrac, Fraction secondFrac)
        {
            int newNumerator = firstFrac.getNumerator() * secondFrac.getNumerator();
            int newDenominator = firstFrac.getDenominator() * secondFrac.getDenominator();
            return new Fraction(newNumerator, newDenominator);
        }

        public Fraction Divide(Fraction firstFrac, Fraction secondFrac)
        {
            int newNumerator = firstFrac.getNumerator() * secondFrac.getDenominator();
            int newDenominator = firstFrac.getDenominator() * secondFrac.getNumerator();
            return new Fraction(newNumerator, newDenominator);
        }

        public int getNumerator()
        {
            return Numerator;
        }

        public void setNumerator(int newNum)
        {
            Numerator = newNum;
        }

        public int getDenominator()
        {
            return Denominator;
        }

        public void setDenominator(int newDen)
        {
            if (newDen == 0)
            {
                throw new ArgumentException("The denominator cannot be zero.");
            }
            Denominator = newDen;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

    }
}
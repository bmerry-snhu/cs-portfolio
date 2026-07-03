namespace Lesson_08
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

        public Fraction Add(Fraction firstFrac, Fraction secondFrac)
        {
            int newNumerator = (firstFrac.getNumerator() * secondFrac.getDenominator()) + (secondFrac.getNumerator() * firstFrac.getDenominator());
            int newDenominator = firstFrac.getDenominator() * secondFrac.getDenominator();
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator +(Fraction firstFrac, Fraction secondFrac)
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

        public static Fraction operator -(Fraction firstFrac, Fraction secondFrac)
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

        public static Fraction operator *(Fraction firstFrac, Fraction secondFrac)
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

        public static Fraction operator /(Fraction firstFrac, Fraction secondFrac)
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

        public static Fraction Parse(string str)
        {
            Fraction newFrac = new Fraction();

            int indexSlash = str.IndexOf("/");
            int newNum = int.Parse(str.Substring(0, indexSlash));
            int newDen = int.Parse(str.Substring(indexSlash + 1));
            
            newFrac.Numerator = newNum;

            if (newDen != 0)
            {
                newFrac.Denominator = newDen;
            }
            else
            {
                throw new ArgumentException("The denominator cannot be zero.");
            }

            return newFrac;
        }
    }
}
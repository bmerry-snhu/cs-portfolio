namespace Lesson_12
{
    public class Fraction : IComparable
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
            int gcd = greatestCommon(numerator, denominator);
            Numerator = numerator / gcd;
            Denominator = verifyDen(denominator / gcd);
        }

        private static int greatestCommon(int first, int second)
        {
            if (second == 0)
            {
                return first;
            }
            else
            {
                return greatestCommon(second, first % second);
            }
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
            Denominator = verifyDen(newDen);
        }

        private static int verifyDen(int checkDen)
        {
            if (checkDen == 0)
            {
                throw new ArgumentException("The denominator cannot be zero.");
            }

            return checkDen;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static Fraction Parse(string str)
        {
            Fraction newFrac = new Fraction();

            int indexSlash = str.IndexOf("/");

            if (indexSlash == -1)
            {
                newFrac.Numerator = int.Parse(str);
                newFrac.Denominator = 1;
            }
            else
            {
                if (str.Substring(0, indexSlash) == "")
                {
                    newFrac.Numerator = 0;
                }
                else
                {
                    newFrac.Numerator = int.Parse(str.Substring(0, indexSlash));
                }

                if (str.Substring(indexSlash + 1) == "")
                {
                    newFrac.Denominator = 1;
                }
                else
                {
                    newFrac.Denominator = verifyDen(int.Parse(str.Substring(indexSlash + 1)));
                }
            }

            return newFrac;
        }

        public int CompareTo(object other)
        {
            Fraction otherFrac = (Fraction)other;

            double f1 = (double)(this.Numerator) / (double)(this.Denominator);
            double f2 = (double)(otherFrac.Numerator) / (double)(otherFrac.Denominator);

            int retVal = 0;
            if (f1 < f2)
                retVal = -1;
            else if (f1 == f2)
                retVal = 0;
            else
                retVal = 1;

            return retVal;
        }
    }
}
using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // TODO: fill this class\
        public double Real { get; }
        public double Imaginary { get; }
        public double Modulus => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        public double Phase => Math.Atan2(Imaginary, Real);
        public Complex Complement() => new Complex(Real, -Imaginary);
        public Complex Plus(Complex other) => new Complex(Real + other.Real, Imaginary + other.Imaginary);
        public Complex Minus(Complex other) => new Complex(Real - other.Real, Imaginary - other.Imaginary);

        public override string ToString()
        {
            if(Imaginary == 0)
            {
                return Real.ToString();
            }
            char sign = Imaginary > 0 ? '+' : '-';
            string re = Real == 0 ? "" : $"{ Real} ";
            string im = (Imaginary == 1) || (Imaginary == -1) ? "" : Math.Abs(Imaginary).ToString();
            return $"{re}{sign} i{im}";
        }

        public override bool Equals(object obj)
        {
            return obj is Complex complex &&
                   Real == complex.Real &&
                   Imaginary == complex.Imaginary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
    }
}
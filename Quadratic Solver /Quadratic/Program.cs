using System;
 
namespace Quadratic
{
    public class Program
    {


        Complex getComplex()
        {
            return new Complex();
        }


        static public void Main(string[] args)
        {

            // Getting the three numbers from user and initialzing the two roots r1 and r2.
            double? a = GetDouble();
            double? b = GetDouble();
            double? c = GetDouble();
            Double? r1;
            Double? r2;


         // If the user input bad input, anything that is nut a numebr, they should get a message saying Bad input
            if (a == null || a ==0 || b == null || c == null)
            {
                Console.WriteLine("Bad Input");
                return;
            }


            // Getting the number of roots
            int TheRoots = getRealRoots(a.Value, b.Value, c.Value, out r1, out r2);


            // printing the equation.
            string Eq = GetQuadraticString(a.Value, b.Value, c.Value);



            // Depnding on the number of roots that we stored in TheRoots, we print an anwer
            if (TheRoots == 1)
            {

                Console.WriteLine("The equation {0} has one real root: {1}", Eq, r1.Value);
            }



            else if (TheRoots == 2)

            {
                Console.WriteLine("The equation {0} has two real root: {1}, {2}", Eq, r1.Value, r2.Value);

            }



            else if (TheRoots == 0)
                // Here is most of the work to get the imaginary roots

            {
                // Getting two complex numbers
                Complex x1, x2; 
                getImaginaryRoots(a.Value, b.Value, c.Value, out x1, out x2);

                Console.WriteLine("The equation {0} has two imaginary roots: {1}, {2}",Eq,x1,x2);

            }

        }





        // Getting the numbers, Doubles.
        static public double? GetDouble()
        {
            string a = Console.ReadLine();
            bool AisDouble = Double.TryParse(a, out Double DoubleA);

            if (AisDouble == true)
            {
                return DoubleA;
            }
            else
            {
                return null;
            }
        }





        // Writing the quadratic equation as a string.
        static public string GetQuadraticString(double A, double B, double C)
        {
            string As, Bs, Cs;

            if (A == 1)
            {
                As = "X^2";
            }
            else if (A == -1)
            {
                A = Math.Abs(A);
                As = "-X^2";
            }
            else if (A < -1)
            {
                A = Math.Abs(A);
                As = A.ToString("-#.##X^2");
            }
            else if (A > 1)
                As = A.ToString("#.##X^2");
            else  As = "";


            if (B == 1)
            {
                Bs = " + X ";
            }
            else if (B == -1)
            {
                B = Math.Abs(B);
                Bs = " - X ";
            }
            else if (B < -1)
            {
                B = Math.Abs(B);
                Bs = B.ToString(" - #.##X");
            }
            else if (B > 1)
                Bs = B.ToString(" + #.##X");
            else Bs = "";


            if (C == 0)
            {
                Cs = "";
            }
          
            else if (C <0)
            {
                C = Math.Abs(C);
                Cs = C.ToString(" - #.##");
            }
            else  
                Cs = C.ToString(" + #.##");




            return string.Format(As + Bs + Cs);
        }






        // Getting the number of real roots
        static public int getRealRoots(double A,double B, double C, out double? r1, out double? r2)
        {

            Double Deter = B * B - 4 * A * C;

            if (Deter < 0)
            {

                r1 = r2 = null;
                return 0;

            }

            else if (Deter > 0)

            {

                r1 = ((-B + Math.Sqrt(Deter)) / (2 * A));
                r2 = ((-B - Math.Sqrt(Deter)) / (2 * A));
                return 2;
            }

            else
            // AKA if the Determinant is equaal to 0
            {

                r1 = (-B / (2 * A));
                r2 = null;
                return 1;
            }

        }


        static public void getImaginaryRoots(double A, double B, double C, out Complex r1, out Complex r2)

        {

            Double Deter = Math.Abs(B * B - 4 * A * C); // Because it is always negitive anyway
            Double real = -B / (2 * A);
            Double imag= Math.Sqrt(Deter) / (2 * A);

            r1 = new Complex(real, imag); // New Complex
            r2 = new Complex(real, -imag); // Because the second root will have only the opposite sign



        }



    }
}

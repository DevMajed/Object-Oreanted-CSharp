using System;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;


namespace Quadratic.Tests 
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;
        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Fact]
        public void AGift()
        {
            // yes, you get 5 points just for turning this in.
            output.WriteLine("Score: +5");
        }

        [Theory]
        [InlineData(1, 32, 175,"X^2 + 32X + 175" )]
        [InlineData(1.1, 32.1, 175.1, "1.1X^2 + 32.1X + 175.1")]
        [InlineData(1.13, 32.13, 175.13, "1.13X^2 + 32.13X + 175.13")]
        public void simpleQuadraticString(double a, double b, double c, string expected)
        {
            // basic double processing will display these correctly
            string result;
            result = Program.GetQuadraticString(a, b, c);
            Assert.Equal(expected, result);
            output.WriteLine("Score: +10");
        }


        // need help? look here:
        //https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
        [Theory]
        [InlineData(Math.PI, 32.12345, 175.4567, "3.14X^2 + 32.12X + 175.46")]
        [InlineData(1.234, 2.345, 3.456, "1.23X^2 + 2.35X + 3.46")]
        public void complexQuadraticString(double a, double b, double c, string expected)
        {
            // these will require a custom format string to pass 
            // but that custom format string should also work for the simple tests
            string result;
            result = Program.GetQuadraticString(a, b, c);
            Assert.Equal(expected, result);
            output.WriteLine("Score: +5");
        }

        [Theory]
        [InlineData(2, 20, 40, "2X^2 + 20X + 40")]
        [InlineData(-2, 20, 40, "-2X^2 + 20X + 40")]
        [InlineData(2, -20, 40, "2X^2 - 20X + 40")]
        [InlineData(2, 20, -40, "2X^2 + 20X - 40")]
        [InlineData(2, -20, -40, "2X^2 - 20X - 40")]
        [InlineData(-2, 20, -40, "-2X^2 + 20X - 40")]
        [InlineData(-2, -20, 40, "-2X^2 - 20X + 40")]
        [InlineData(-2, -20, -40, "-2X^2 - 20X - 40")]
        public void SignedQuadraticString(double a, double b, double c, string expected)
        {
            // these will require a custom format string to pass 
            // but that custom format string should also work for the simple tests
            string result;
            result = Program.GetQuadraticString(a, b, c);
            Assert.Equal(expected, result);
            output.WriteLine("Score: +5");
        }

        [Theory]
        [InlineData(1, 20, 40, "X^2 + 20X + 40")]
        [InlineData(-1, 20, 40, "-X^2 + 20X + 40")]
        [InlineData(1, 0, 40, "X^2 + 40")]
        [InlineData(-1, 0, 40, "-X^2 + 40")]
        [InlineData(1, 0, -40, "X^2 - 40")]
        [InlineData(-1, 0, -40, "-X^2 - 40")]
        [InlineData(1, 20, 0, "X^2 + 20X")]
        [InlineData(1, -20, 0, "X^2 - 20X")]
        [InlineData(1, 0, 0, "X^2")]

        public void MissingQuadraticString(double a, double b, double c, string expected)
        {
            // these will require a custom format string to pass 
            // but that custom format string should also work for the simple tests
            string result;
            result = Program.GetQuadraticString(a, b, c);
            Assert.Equal(expected, result);
            output.WriteLine("Score: +5");
        }



        [Theory]
        [InlineData(1, 32, 175, 2)]
        [InlineData(1, 14, 49, 1)]
        [InlineData(1, 10, 100,0)]
        public void checkNumberOfRoots(double a, double b, double c, int numRoots)
        {
            double? r1, r2;
            int result;
            result = Program.getRealRoots(a, b, c, out r1, out r2);
            Assert.Equal(numRoots,result);
            output.WriteLine("Score: +5");
        }

        [Theory]
        [InlineData(1, 32, 175, -7, -25)]
        [InlineData(2, -95, -4125, 75,-27.5)]
        [InlineData(1, 0.423311, -8.53973, Math.E, -1* Math.PI)]

        public void twoRealRoots(double a,double b, double c, double root1,double root2)
        {
            //these quadratic equations have two real roots
            double? r1, r2;
            int numRoots;
            numRoots = Program.getRealRoots(a, b, c, out r1, out r2);
            Assert.Equal(2, numRoots);
            Assert.NotNull(r1);
            output.WriteLine("Score: +10");
            Assert.Equal(root1, r1.Value, 2);
            output.WriteLine("Score: +5");
            Assert.NotNull(r2);
            Assert.Equal(root2, r2.Value, 2);
            output.WriteLine("Score: +5");
        }

        // double disc = B*B - 4 * A * C;

        [Theory]
        [InlineData(1, 14, 49, -7)]
        [InlineData(1, -14, 49, 7)]
        [InlineData(1, 0, 0, 0)]
        public void oneRealRoots(double a, double b, double c, double root1 )
        {
            double? r1, r2;
            int numRoots;
            numRoots = Program.getRealRoots(a, b, c, out r1, out r2);
            Assert.Equal(1, numRoots);
            output.WriteLine("Score: +10");
            Assert.NotNull(r1);
            Assert.Equal(root1, r1.Value, 2);
            output.WriteLine("Score: +5");
            Assert.Null(r2);
            output.WriteLine("Score: +5");
        }

        [Theory]
        [InlineData(1, 10, 100)]
        [InlineData(0.5, 5, 50)]
        public void noRealRoots(double a, double b, double c)
        {
            double? r1, r2;
            int numRoots;
            numRoots = Program.getRealRoots(a, b, c, out r1, out r2);
            Assert.Equal(0, numRoots);
            output.WriteLine("Score: +10");
            Assert.Null(r1);
            output.WriteLine("Score: +5");
            Assert.Null(r2);
            output.WriteLine("Score: +5");
        }


        [Theory]
        [InlineData("bob", 1, 2, "Bad Input")]
        [InlineData(1, "bob", 2, "Bad Input")]
        [InlineData(1, 2, "bob", "Bad Input")]
        [InlineData("bob", "bob", 2, "Bad Input")]
        [InlineData("bob", 2, "bob", "Bad Input")]
        [InlineData(1, "bob", "bob", "Bad Input")]
        [InlineData("bob", "bob", "bob", "Bad Input")]
        [InlineData("0", "5", "7", "Bad Input")]

        public void badData(object a,object b, object c,string expected)
        {
            var content = new StringBuilder();
            var writer = new StringWriter(content);
            Console.SetOut(writer);

            var reader = new StringReader(String.Format("{0}\n{1}\n{2}\n", a, b, c));
            Console.SetIn(reader);


            Quadratic.Program.Main(null);
            Assert.Equal(String.Format("{0}", expected), content.ToString().TrimEnd());
            output.WriteLine("Score: +5");
        }

        [Theory]
        [InlineData(1, -2, -35, "The equation X^2 - 2X - 35 has two real root: 7, -5")]
        [InlineData(1, 14, 49, "The equation X^2 + 14X + 49 has one real root: -7")]
        [InlineData(1, 0, 0, "The equation X^2 has one real root: 0")]
        [InlineData(1, 7, 0, "The equation X^2 + 7X has two real root: 0, -7")]
        
        public void goodData(object a, object b, object c, string expected)
        {
            var content = new StringBuilder();
            var writer = new StringWriter(content);
            Console.SetOut(writer);

            var reader = new StringReader(String.Format("{0}\n{1}\n{2}\n", a, b, c));
            Console.SetIn(reader);


            Quadratic.Program.Main(null);
            Assert.Equal(String.Format("{0}", expected), content.ToString().TrimEnd());
            output.WriteLine("Score: +5");
        }

        [Theory]
        [InlineData(1, 0, 16, "The equation X^2 + 16 has two imaginary roots: 4i, -4i")]
        [InlineData(4, 0, 64, "The equation 4X^2 + 64 has two imaginary roots: 4i, -4i")]
        [InlineData(1, 10, 100, "The equation X^2 + 10X + 100 has two imaginary roots: -5+8.66i, -5-8.66i")]
        public void unrealData(object a, object b, object c, string expected)
        {
            var content = new StringBuilder();
            var writer = new StringWriter(content);
            Console.SetOut(writer);

            var reader = new StringReader(String.Format("{0}\n{1}\n{2}\n", a, b, c));
            Console.SetIn(reader);


            Quadratic.Program.Main(null);
            Assert.Equal(String.Format("{0}", expected), content.ToString().TrimEnd());
            output.WriteLine("Score: +5");
        }

        [Theory]
        [InlineData(10, 10, "10+10i")]
        [InlineData(-10, 10, "-10+10i")]
        [InlineData(10, -10, "10-10i")]
        [InlineData(-10, -10, "-10-10i")]
        [InlineData(1, -10, "1-10i")]
        [InlineData(-1, -10, "-1-10i")]
        [InlineData(10, 1, "10+i")]
        [InlineData(10, -1, "10-i")]
        [InlineData(0, 2, "2i")]
        [InlineData(0, -2, "-2i")]
        [InlineData(0, 1, "i")]
        [InlineData(0, -1, "-i")]
        [InlineData(2, 0, "2")]
        [InlineData(-2, 0, "-2")]


        public void ComplexStrings(double Real,double Imag,string expected)
        {
            Complex t = new Complex(Real, Imag);
            Assert.Equal(expected, t.ToString());
            output.WriteLine("Score: +5");
        }

    }
}

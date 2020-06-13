using System;

namespace FirstProgram
{
    public class BasicCode
    {
        public static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Please Enter The First Number");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter The Second Number");
            b = int.Parse(Console.ReadLine());



            bool isEven = Even(a);
            bool isDivisible = Divisible(a);
            bool thirdDigitIsSeven = thirdDigitSeven(a);
            bool inCircle = insideCircle(a, b);
            Console.WriteLine("The number {0} is", a);
            Console.WriteLine("Even? - {0}", isEven);
            Console.WriteLine("divisible by 5&7? - {0}", isDivisible);
            Console.WriteLine("digit 3 is 7? - {0}", thirdDigitIsSeven);
            Console.WriteLine("The point {0},{1} is in the circle? - {2}", a, b, inCircle);


        }

        public static bool Even(int x)
        {


            if (x % 2 == 0)
            {
                return true;
            }



            return false;
        }

        public static bool Divisible(int x)
        {


            if (x % 7 == 0 && x % 5 == 0)
            {
                return true;
            }

            return false;
        }

        public static bool thirdDigitSeven(int x)
        {


            int x100 = x / 100;
            int theirddigit = x100 % 10;


            if (theirddigit == 7)
            {
                return true;
            }


            return false;





        }

        public static bool insideCircle(int x, int y)
        {




            int h = (x * x) + (y * y);

            if (h <= 25)
            {
                return true;
            }



            return false;
        }

    }
}

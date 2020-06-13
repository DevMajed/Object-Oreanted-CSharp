using System;
using System.Collections.Generic;
using System.Text;

namespace Quadratic
{
    public class Complex
    {



        // Creating Real Proberity 
        public Double Real
        {
            get;
            set;
        }
        // Creating Imaginary Proberity 
        public Double Imag
        {
            get;
            set;
        }


        // Creating default constructor, Gonna reffrence the complex constructur
        // becayse if "this"
        public Complex(): this(0,0)
        {

        }

        // Creating Parameterize constructor
        public Complex(Double r, Double i) //constructors

        {
            // Initializing
            Real = r;
            Imag = i;


        }



        // Creating  
        public override string ToString()
        {


            if (Imag == 1 || Imag == -1)


            {

                if (Real == 0)
                {
                    if (Imag == 1) return String.Format("i", Imag);

                    else return String.Format("-i", Imag);
                }
                else
                {
                    if (Imag == 1) return String.Format("{0:.##}+i", Real);
                    else return String.Format("{0:.##}-i", Real, Imag);
                }

            }





            else if (Imag > 1)
            {
                if (Real == 0)
                {
                    if (Imag == 1) return String.Format("i", Imag);

                    else return String.Format("{0:.##}i", Imag);
                }
                else
                {
                    if (Imag == 1) return String.Format("{0:.##}+i", Real);
                    else return String.Format("{0:.##}+{1:.##}i", Real, Imag);
                }
            }
            else if (Imag < -1)
            {
                Imag = -Imag;
                if (Real == 0)
                {
                    if (Imag == 1) return String.Format("-i", Imag);
                    else return String.Format("-{0}i", Imag);
                }



                else
                {
                    if (Imag == 1) return String.Format("{0}-i", Imag);
                    else return String.Format("{0}-{1:.##}i", Real, Imag);
                }
            }

            else
            {
                if (Real == 0)


                    return String.Format("");
                else return String.Format("{0}", Real);
            }

        }

      
    }
}

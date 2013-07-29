using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;

namespace PE64
{
    class Program
    {
        static void Main(string[] args)
        {

            int countOfOdd = 0;

            for (int ii = 2; ii <= 10000; ii++)
            {
                int[] conFrac = GetContinuedFractionOfSquareRoot(ii);
                int period = conFrac.Length - 1;

                if (PELib.Util.IsOdd(period))
                {
                    countOfOdd++;
                }

            }



            Util.ShowResult(countOfOdd);
        }

        static int[] GetContinuedFractionOfSquareRoot(int n)
        {
            var frac = new List<int>();


            // Step 1 find whole number that starts continued fraction
            // sqrt(n) = m + 1/x
            int m= (int)Math.Sqrt(n);

            frac.Add(m);

            int b = 1;
            int a = 0;  //( sqrt(n) + a) / b 

            do
            {

                // Step 2. Rearrange the equation in step 1 into the form of x equals an expression involving the square root of which
                //  will appear as the denominator of the fraction: x = 1/(sqrt(n) - m)

                // new m

                // convert to
                // x1 = (c1 /(sqrt(n) - d1)
                int a1 = -(a - m * b);
                int b1 = ( n - (a - m * b) * (a - m * b)) / b;

                a = a1;
                b = b1;

                if (b == 0) 
                {
                    // Done -- simple square.
                    break;
                }

                m = ((int)Math.Sqrt(n) + a) / b;


                frac.Add(m);

                // Done
                if (b == 1)
                {
                    break;
                }

            } while( true);

            return frac.ToArray<int>();
        }       






        }
    }


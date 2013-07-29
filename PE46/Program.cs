using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;

namespace PE46
{
    /*
     * It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.

        9 = 7 + 2x1^2
        15 = 7 + 2x2^2
        21 = 3 + 2x3^2
        25 = 7 + 2x3^2
        27 = 19 + 2x2^2
        33 = 31 + 2x1^2

        It turns out that the conjecture was false.

        What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
     */
    class Program
    {
        static void Main(string[] args)
        {

            foreach( long composite in Util.CompositeGenerator(9))
            {
                if (Util.IsOdd(composite))
                {
                    bool bFound = false;
                    foreach (long prime in Util.PrimeGenerator(2))
                    {
                        if (prime >= composite)
                        {
                            break;
                        }

                        double nn = 1;
                        long calc;
                        do
                        {
                            calc = prime + 2 * (long)Math.Pow(nn, 2);
                            if (calc == composite)
                            {
                                bFound = true;
                                Console.WriteLine("" + composite + " = " + prime + "+2*" + nn + "^2");
                                break;
                            }
                            nn++;
                        } while (calc <= composite);

                        if (bFound)
                        {
                            break;
                        }
                    }
                    if (!bFound)
                    {
                        // This is it!
                        Util.ShowResult(composite);
                    }
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE33
{
    /*
     * The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.

We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.

If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
     */
    class Program
    {
        static void Main(string[] args)
        {
            float productDenominator = 1;

            for( int numFirstDigit=1; numFirstDigit< 10; numFirstDigit++)
            {
                for( int numSecondDigit=1; numSecondDigit<10; numSecondDigit++) // 0 skipped as second digit
                {
                    for( int denomFirstDigit = 1; denomFirstDigit<10; denomFirstDigit++)
                    {
                        for( int denomSecondDigit = 1; denomSecondDigit<10; denomSecondDigit++)
                        {
                            if( (numFirstDigit == denomFirstDigit) && (numSecondDigit == denomSecondDigit))
                            {
                                // Same num/denom SKIP
                            }
                            else
                            {
                                float fraction = (float)(numFirstDigit*10 + numSecondDigit)/(float)(denomFirstDigit*10 + denomSecondDigit);
                                if (fraction < 1)
                                {
                                    if (numFirstDigit == denomFirstDigit)
                                    {
                                        if (AlmostEqual((float)numSecondDigit / denomSecondDigit, fraction))
                                        {
                                            Console.WriteLine( "" + numFirstDigit + "" + numSecondDigit + "/" + denomFirstDigit +"" + denomSecondDigit);
                                            productDenominator *= fraction;
                                            Console.WriteLine(fraction);
                                        }
                                    }
                                    if (numFirstDigit == denomSecondDigit)
                                    {
                                        if (AlmostEqual((float)numSecondDigit / denomFirstDigit, fraction))
                                        {
                                            Console.WriteLine("" + numFirstDigit + "" + numSecondDigit + "/" + denomFirstDigit + "" + denomSecondDigit);
                                            productDenominator *= fraction;
                                            Console.WriteLine(fraction);
                                        }
                                    }
                                    if (numSecondDigit == denomFirstDigit)
                                    {
                                        if (AlmostEqual((float)numFirstDigit / denomSecondDigit, fraction))
                                        {
                                            Console.WriteLine("" + numFirstDigit + "" + numSecondDigit + "/" + denomFirstDigit + "" + denomSecondDigit);
                                            productDenominator *= fraction;
                                            Console.WriteLine(fraction);
                                        }
                                    }
                                    if (numSecondDigit == denomSecondDigit)
                                    {
                                        if (AlmostEqual((float)numFirstDigit / denomFirstDigit, fraction))
                                        {
                                            Console.WriteLine("" + numFirstDigit + "" + numSecondDigit + "/" + denomFirstDigit + "" + denomSecondDigit);
                                            productDenominator *= fraction;
                                            Console.WriteLine(fraction);
                                        }
                                    }
                                }


                                
                            }
                        }
                    }
                }

            }


            Console.WriteLine( productDenominator); // This prints 0.01, so 1/100, so denominator is 100.
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        static bool AlmostEqual(float value, float check)
        {
            if (Math.Abs(value - check) < .0001)
            {
                return true;
            }
            return false;
        }
    }
}

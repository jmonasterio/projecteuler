using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;

namespace PE51
{
    class Program
    {
        static int GetDigit(long num, int nDigit)
        {
            int nCount = (int)Math.Log10(num) - nDigit+1;
            while (nCount > 0)
            {
                num = num / 10;
                nCount--;
            }
            return (int)num % 10;
        }

        static long ReplaceOnes( long old, int nDigitReplace)
        {
            int nDigits = (int)Math.Log10(old)+1;
            long output= 0;
            for (int ii = 1; ii<=nDigits ; ii++)
            {
                int dig = GetDigit(old, ii);
                if (dig == 1)
                {
                    dig = nDigitReplace;
                }
                output *= 10;
                output += dig;
            }
            return output;

        }


        static void Main(string[] args)
        {
            int LOOKING_FOR = 6;
            long startPrime = 56113; // After this one.

            for (int digits = 5; digits < 10; digits++)
            {
                long stopAt = (long)(Math.Pow(10, digits) - 1);

                // Make list of primes with specified # of digits.
                List<long> primes = new List<long>();

                foreach (long prime in Util.PrimeGenerator(startPrime))
                {
                    if (prime > stopAt)
                    {
                        break;
                    }

                    primes.Add(prime);
                }



                // now look thru for matches
                for (int ii = 0; ii < primes.Count; ii++)
                {
                    long firstPrime = primes[ii];

                    List<int> fdig = new List<int>();
                    int CountOnes = 1;
                    for( int dd = 0; dd< digits; dd++)
                    {
                        int dig = GetDigit(firstPrime, dd + 1);
                        if (dig == 1) { CountOnes++; };
                        fdig.Add( dig);
                    }

                    if (CountOnes > 1)
                    {

                            int primeCount = 1; // firstPrime counts.

                            for (int digit = 0; digit <= 9; digit++)
                            {
                                if( digit != 1)
                                {
                                    // replace the 1's in first prime with digit.
                                    long newPrimeCandidate = ReplaceOnes( firstPrime, digit);

                                    if( primes.Contains( newPrimeCandidate))
                                    {
                                        primeCount++;
                                    }
                                }
                            }


                            if (primeCount >= LOOKING_FOR)
                            {
                                // Found it!

                                Console.WriteLine("" + firstPrime + ": " + primeCount);

                                if (primeCount >= 9)
                                {
                                    Util.ShowResult(firstPrime);
                                }

                                //return;
                            }

                        }

                    }
                startPrime = (long)Math.Pow(10, digits);
                }

            }

        }
    }



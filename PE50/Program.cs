using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;

namespace PE50
{
    class Program
    {
        /* The prime 41, can be written as the sum of six consecutive primes:

41 = 2 + 3 + 5 + 7 + 11 + 13
This is the longest sum of consecutive primes that adds to a prime below one-hundred.

The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

Which prime, below one-million, can be written as the sum of the most consecutive primes?
         */

        static List<long> allPrimes = new List<long>();

        static void Main(string[] args)
        {
            // All primes
            foreach (long prime in Util.PrimeGenerator(2)) 
            {
                if (prime >= 1000000)
                {
                    break;
                }
                allPrimes.Add(prime);
            }

            // Calculate all possible consecutive runs, and look for the longest.
            int maxRun = 0;
            long maxPrime = 0;
            for( int ii=0; ii< allPrimes.Count; ii++)
            {


                long sum = 0;
                int runLength = 0;
                for( int jj=ii; jj<allPrimes.Count; jj++)
                {
                    sum += allPrimes[ jj];

                    if (sum > 1000000)
                    {
                        break;
                    }
                    if (Util.IsPrime(sum))
                    {
                        runLength = jj - ii + 1;
                        if (runLength > maxRun)
                        {
                            maxRun = runLength;
                            maxPrime = sum;
                            Console.WriteLine("" + maxPrime + "->" + maxRun);
                        }
                    }
                }
            }
            Util.ShowResult(maxPrime);

        }

        static int GetRunOfPrimes(long prime)
        {
            List<long> runs = new List<long>();
            //long partialSum = 0;
            foreach( long startPrime in allPrimes)
            {
                if (runs.Count > Math.Sqrt(prime))
                {
                    break;
                }
                for( int ii=0; ii<runs.Count; ii++)
                {
                    runs[ii] += startPrime;
                    if( runs[ii] == prime)
                    {
                        Console.WriteLine("" + prime + "->" + (runs.Count - ii + 1));
                        return runs.Count - ii + 1;
                    }

                }
                runs.Add(startPrime);

            }
            return 0;
        }
    }
}

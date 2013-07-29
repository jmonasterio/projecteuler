using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;

namespace PE60
{
    /*
     * The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes and concatenating them in any order the result will always be prime. For example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.

Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.
     */
    class Program
    {

        static SortedList<int, long> primeList = new SortedList<int, long>();

        const long MAX_PRIME_LIST =25000000;

        static long MaxPrime = 0;

        static bool IsPrimePair(long n1, long n2)
        {
            long c1 = long.Parse("" + n1 + n2);
            long c2 = long.Parse("" + n2 + n1);

            if (c1 > MaxPrime || c2 > MaxPrime)
            {
                return Util.IsPrime(c1) && Util.IsPrime(c2);
            }
            else

             if (primeList.ContainsValue(c2) && primeList.ContainsValue(c1))
             {
                 return true;
             }
            return false;
        }

        const long MAX_PRIME_IDX = 5000;

        static void Main(string[] args)
        {
            int idx = 0;
            foreach (long p in Util.PrimeGenerator(3, MAX_PRIME_LIST))
            {
                primeList.Add(idx++,p);
            }
            MaxPrime = primeList[(int) MAX_PRIME_IDX];

            long[] primes = new long[5];

            for (int i0 = 0; i0<MAX_PRIME_IDX; i0++)
            {
                long prime = primeList[i0];
                primes[0] = prime;

                for (int i1 = i0 + 1; i1 < MAX_PRIME_IDX; i1++)
                {
                    long prime2 = primeList[i1];
                    primes[1] = prime2;
                    if ( IsPrimePair( prime, prime2))
                    {
                        for (int i2 = i1 + 1; i2 < MAX_PRIME_IDX; i2++)
                        {
                            long prime3 = primeList[i2];
                            primes[2] = prime3;
                            if (  IsPrimePair( prime, prime3) && IsPrimePair( prime2, prime3) )
                            {
                                for (int i3 = i2 + 1; i3 < MAX_PRIME_IDX; i3++)
                                {
                                    long prime4 = primeList[i3];
                                    primes[3] = prime4;
                                    if (  IsPrimePair( prime, prime4) && IsPrimePair( prime2, prime4) && IsPrimePair( prime3, prime4) )
                                    {

                                        for (int i4 = i3 + 1; i4 < MAX_PRIME_IDX; i4++)
                                        {
                                            long prime5 = primeList[i4];
                                            primes[4] = prime5;
                                            if ( IsPrimePair( prime, prime5) && IsPrimePair( prime2, prime5) && IsPrimePair( prime3, prime5) && IsPrimePair( prime4, prime5 ))
                                            {
                                                Console.WriteLine(prime + prime2 + prime3 + prime4 + prime5);

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            Util.ShowResult("");
        }
    }
}
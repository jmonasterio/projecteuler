using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;

namespace PE49
{
    class Program
    {
        /* The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: 
         * 
         * (i) each of the three terms are prime, and, 
         * (ii) each of the 4-digit numbers are permutations of one another.

            There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.

            What 12-digit number do you form by concatenating the three terms in this sequence?
         */
        static void Main(string[] args)
        {
            string answer = "";
            foreach (long prime in Util.PrimeGenerator(1000)) // Start with 4 digit primes
            {
                if (prime > 9999)
                {
                    break;
                }
                List<long> primes = new List<long>();
                primes.Add( prime);
                foreach (long perm in Util.LexographicPermutationGenerator(Util.LongToArrayOfDigits(prime)))
                {
                    if (Util.IsPrime(perm))
                    {
                        primes.Add(perm);
                    }
                }
                if (primes.Count >= 3)
                {
                    string s = ConcatenateSequenceOf3(primes);
                    if (s.Length > 0)
                    {
                        if (prime != 1487)
                        {
                            answer = s;
                            break;
                        }
                    }
                }

            }

            Util.ShowResult(answer);
        }

        // Really dumb, only checks for 3.
        static string ConcatenateSequenceOf3(List<long> nums)
        {
            for (int ii = 0; ii < nums.Count - 1; ii++)
            {
                for (int jj = ii+1; jj < nums.Count; jj++)
                {
                    long diff1 = nums[jj] - nums[ii];
                    if (nums.Contains(nums[jj] + diff1))
                    {
                        return "" + nums[ii] + "" + nums[jj] + "" + (nums[jj]+diff1);
                    }
                }
            }
            return "";
        }
        
    }
}

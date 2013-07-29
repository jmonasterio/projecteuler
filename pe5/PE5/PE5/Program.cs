using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE5
{

    /* 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

        What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
     */
    class Program
    {
        // Every number can be factored into a primes: like 20=5*2^2
        // We are looking for primes with HIGHEST power, which we keep track of.
        //
        // NOTE: This function sucks. Some bugs were fixed when adapted from PE3 -- not sure why that program worked.
        static void find_prime_factors(int num, List<int> max_prime_powers)
        {
            int prime = 2;

            int orig_num = num;

            int power = 0;

            while (true)
            {
                if (num % prime == 0)
                {
                    // Is factor.
                    num = num / prime;
                    power++;
                    if (is_prime(num))
                    {
                        // The other factor is prime.
                        if (num == prime)
                        {
                            power++;
                        }
                        if (max_prime_powers[(int)prime] < power)
                        {
                            max_prime_powers[(int)prime] = power;
                        }
                        prime = next_prime(prime, orig_num / 2);
                        if (0 == prime)
                        {
                            // Reached max!
                            return;
                        }
                        power = 0;
                    }
                }
                else
                {
                    if (is_prime(num))
                    {
                        // The other factor is prime.
                        power++;
                        if (max_prime_powers[(int)num] < power)
                        {
                            max_prime_powers[(int)num] = power;
                        }
                    }
                    prime = next_prime(prime, orig_num / 2);
                    if (0 == prime)
                    {
                        // Reached max!
                        return;
                    }
                    power = 0;

                }
            }
        }

        static bool is_prime(long num)
        {
            if (num == 2 || num == 3) { return true; }
            for (int ii = 2; ii <= num / 2; ii++)
            {
                if (num % ii == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static int next_prime(int prevPrime, int max)
        {
            int next = prevPrime;
            while (true)
            {
                next += 1;
                if (next > max)
                {
                    return 0;
                }
                if (is_prime(next))
                {
                    return next;
                }
            }

        }

        // The technique is find the prime factorization of each number (1..20), and then
        //  keep track of the HIGHEST power for each prime. Multiply all these primes together (raised to power), to get solution

        static void Main(string[] args)
        {
            int x=20;

            // Keep an array of exponents for all numbers (some prime) up to x.
            List<int> max_prime_powers = new List<int>();
            for (int kk = 0; kk <= x; kk++)
            {
                max_prime_powers.Add(0) ;
            }

            // Find the prime factorization of each number, and track of largest exponents for primes.
            for (int ii = 2; ii <= x; ii++)
            {
                find_prime_factors(ii, max_prime_powers);
            }

            // Calculate the product of all the primes.
            int smallest_common_factor = 1;
            for (int jj = 2; jj < max_prime_powers.Count; jj++)
            {
                smallest_common_factor *= (int)  Math.Pow(jj, max_prime_powers[jj]);
            }


            Console.WriteLine(smallest_common_factor);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143 ?
namespace PE3
{
    class Program
    {
        static long greatest_prime_factor(long num)
        {
            long gpf = 0;

            long prime = 2;
            while( true)
            {
                if( num % prime == 0)
                {
                    // Is factor.
                    num = num / prime;
                    if (is_prime(num))
                    {
                        // The other factor is prime.
                        return Math.Max(num, prime);
                    }
                    gpf = prime;
                    prime = 2;
                }
                else
                {
                    prime = next_prime( prime, num/2);
                    if( 0 == prime)
                    {
                        // Reached max!
                        return gpf;
                    }

                }
            }
        }

        static bool is_prime( long num)
        {
            if( num == 2 || num == 3) { return true;} 
            for( int ii=2; ii<num/2; ii++)
            {
                if( num % ii == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static long next_prime( long prevPrime, long max)
        {
            long next = prevPrime;
            while (true)
            {
                next += 1;
                if( next > max)
                {
                    return 0;
                }
                if( is_prime(next))
                {
                    return next;
                }
            }
                
        }


        static void Main(string[] args)
        {
            long num = 600851475143;

            long gcf = greatest_prime_factor(num);

            Console.WriteLine(gcf);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();

        }
    }
}

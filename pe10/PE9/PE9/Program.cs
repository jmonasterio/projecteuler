using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        // Brute force.
        static int FindProduct()
        {
            int product = 0;

            for (int a = 1; a <= 998; a++) // Probably not valid to go to 1000
            {
                for (int b = a+1; b <= 999; b++)
                {
                    int c = 1000 - (a + b);

                    if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                    {
                        product = a * b * c;
                        return product;
                    }
                }
            }

            return -1;

        }
        
        /*
         * 
         * A Pythagorean triplet is a set of three natural numbers, a  b  c, for which,

            a2 + b2 = c2
            For example, 32 + 42 = 9 + 16 = 25 = 52.

            There exists exactly one Pythagorean triplet for which a + b + c = 1000.
            Find the product abc.
         */
        static void Main(string[] args)
        {
            // Brute force.
            int product = FindProduct();

            Console.WriteLine(product);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}

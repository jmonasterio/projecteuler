using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE4
{

    /* A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91  99.

        Find the largest palindrome made from the product of two 3-digit numbers.
     */
    class Program
    {
        static bool is_palindrom(int num)
        {
            List<int> digits = new List<int>();

            //Console.WriteLine(num);

            while (num > 0)
            {
                digits.Add(num % 10);
                num = num / 10;
            }

            int count = digits.Count;
            for (int ii = 0; ii < count / 2; ii++ )
            {
                if (digits[ii] != digits[count - ii-1])
                {
                    return false;
                }
            }
            return true;
        }


        /* Patter for combinations (from largest to smallest)
        10 * 10
        10 * 9
        9 * 9
        10 * 8
        9 * 8
        10 * 7
        8 * 8
        9 * 7
        
        8 * 7
        7 * 7
        7 * 6
        */



        static void Main(string[] args)
        {
            int result = 0;
            int min = 800; // Speed things up... don't test all the numbers.
            int max = 999;
            List<int> products = new List<int>(max * max);
            for (int ii = max; ii >= min; ii--) // Only 3 digit numbers
            {
                for (int jj = ii; jj > min; jj--)
                {
                    int product = ii * jj;
                    if (!products.Contains(product))
                    {
                        products.Add(product);
                    }
                }
            }

            products.Sort();
            products.Reverse();

            foreach( int product in products)
            {
                if (is_palindrom(product))
                {
                    result = product;
                    break;
                }
            }

            Console.WriteLine(result);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE20
{
    /*
     * n! means n x (n -1) x ... x 3 x 2 x 1

        For example, 10! = 10 x 9  ...  3 x 2 x 1 = 3628800,
        and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

        Find the sum of the digits in the number 100!
     * 
     *  33
     * x34
     * ===
     */
    class Program
    {
        static string AddLongString(string op1, string op2)
        {
            string sum = "";

            // I know the first op1 is always longer (or as long as op2);
            System.Diagnostics.Debug.Assert(op1.Length >= op2.Length);

            int carry = 0;

            int len1 = op1.Length;
            int len2 = op2.Length;

            for (int ii = 0; ii < len1; ii++)
            {
                int dig1 = int.Parse(op1.Substring(len1 - ii - 1, 1));
                int dig2;

                if (ii < len2)
                {
                    dig2 = int.Parse(op2.Substring(len2 - ii - 1, 1));
                }
                else
                {
                    dig2 = 0;
                }

                int digSum = dig1 + dig2 + carry;
                if (digSum <= 9)
                {
                    sum = "" + digSum + sum;
                    carry = 0;
                }
                else
                {
                    sum = "" + (digSum % 10) + sum;
                    carry = 1;
                }
            }
            if (carry != 0)
            {
                sum = "1" + sum;
            }
            return sum;
        }

        // Silly multiplication by multiple additions. Fast enough?
        static string BigMult(string f1, string f2)
        {
            string prod = f1;
            for (int ii = 1; ii < int.Parse(f2); ii++)
            {
                prod = AddLongString(prod, f1);
            }
            return prod;
        }

        static void Main(string[] args)
        {
            const int START = 100;
            string f = START.ToString();
            for (int nn = START-1; nn > 1; nn--)
            {
                f = BigMult(f, nn.ToString());
            }

            // Now, sum the digits
            int sum = 0;
            for (int ii = 0; ii < f.Length; ii++)
            {
                sum += int.Parse("" + f[ii]);
            }

            Console.WriteLine(f); // For debug
            Console.WriteLine(sum);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}

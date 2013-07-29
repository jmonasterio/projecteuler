using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE25
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

        static string Fib(ref string fn_minus1, ref string fn_minus2)
        {
            string fib = AddLongString(fn_minus1, fn_minus2);
            fn_minus2 = fn_minus1;
            fn_minus1 = fib;
            return fib;
        }

        static void Main(string[] args)
        {
            string fn_minus1 = "1";
            string fn_minus2 = "1";
            string n = 3.ToString();
            int term = 2;
            do
            {
                term++;
                n = Fib(ref fn_minus1, ref fn_minus2);
               // Console.WriteLine( "F" + term + " = " + n);

            } while (n.Length < 1000);

            Console.WriteLine(term); 
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}

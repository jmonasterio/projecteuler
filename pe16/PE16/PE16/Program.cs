using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE16
{
    /*
     * 215 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

            What is the sum of the digits of the number 21000?
     */

    // I note that for powers of 2, addition is same as squaring. I made a big adder a in PE13.

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
                int dig1 = int.Parse(op1.Substring(len1-ii-1, 1));
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

        static void Main(string[] args)
        {
            // Power of 2
            const int POWEROF2 = 1000;

            string sum = "2";

            for (int ii = 1; ii < POWEROF2; ii++)
            {
                sum = AddLongString(sum, sum);
            }

            int sumofdigits = 0;
            for( int jj = 0; jj<sum.Length; jj++)
            {
                sumofdigits += int.Parse( "" + sum[jj]);
            }


            Console.WriteLine(sumofdigits);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE40
{
    /*
     * 
     * An irrational decimal fraction is created by concatenating the positive integers:

        0.123456789101112131415161718192021...

        It can be seen that the 12th digit of the fractional part is 1.

        If dn represents the nth digit of the fractional part, find the value of the following expression.

        d1  d10  d100  d1000  d10000  d100000  d1000000
     */
    class Program
    {
        static void Main(string[] args)
        {
            int product;

            StringBuilder irrBuf = new StringBuilder();
            int num = 1;
            do
            {
                irrBuf.Append( "" + num);
                num++;
            } while (irrBuf.Length <= 1000000);
            string irr = irrBuf.ToString();

            int d1 = int.Parse( irr.Substring(1-1, 1));
            int d10 = int.Parse( irr.Substring(10-1, 1));
            int d100 = int.Parse( irr.Substring(100-1, 1));
            int d1000 = int.Parse( irr.Substring(1000-1, 1));
            int d10000 = int.Parse( irr.Substring(10000-1, 1));
            int d100000 = int.Parse( irr.Substring(100000-1, 1));
            int d1000000 = int.Parse( irr.Substring(1000000-1, 1));

            product = d1 * d10 * d100 * d1000 * d10000 * d100000 * d1000000;

            Console.WriteLine(product );
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        static string LongDiv(int numerator, int denominator)
        {
            List<int> quotientDigits = new List<int>();
            List<int> partialResults = new List<int>();
            int repeatingDigits = 0;

            do
            {
                int partialResult = numerator / denominator;

                if (partialResult == 0)
                {
                    quotientDigits.Add(0);
                }
                else
                {
                    numerator -= partialResult * denominator;
                    if (numerator == 0)
                    {
                        // Done!  No repeate
                        quotientDigits.Add(partialResult);
                        break;
                    }

                    // Check for repeat

                    quotientDigits.Add(partialResult);
                }
                numerator *= 10;
                if (partialResults.Contains(numerator))
                {
                    // Found a repeat.
                    repeatingDigits = partialResults.Count - partialResults.IndexOf(numerator);
                    break;
                }
                partialResults.Add(numerator);

                // Figure out how to check for repeat.

            } while (true);

            string answer = "";

            for (int ii = 0; ii < quotientDigits.Count; ii++)
            {
                if (ii == quotientDigits.Count - repeatingDigits)
                {
                    answer += "(";
                }
                if (ii == 0)
                {
                    if (quotientDigits[0] == 0)
                    {
                        answer = "0.";
                    }
                }
                else
                {
                    answer += "" + quotientDigits[ii];
                }
            }
            if (repeatingDigits != 0)
            {
                answer += ")";
            }

            return (answer);
        }
    }
}

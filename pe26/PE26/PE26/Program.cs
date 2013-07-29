using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE26
{
    class Program
    {
        /*
         * A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

        1/2	= 	0.5
        1/3	= 	0.(3)
        1/4	= 	0.25
        1/5	= 	0.2
        1/6	= 	0.1(6)
        1/7	= 	0.(142857)
        1/8	= 	0.125
        1/9	= 	0.(1)
        1/10	= 	0.1
        Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

        Find the value of d  1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
         */
        static void Main(string[] args)
        {
            int d = 0;
            int maxRepeatingDigits = 0;

            for (int ii = 2; ii <= 1000; ii++)
            {
                string quotient = LongDiv(1, ii);
                Console.WriteLine("" + ii + " : " + quotient);
                if (quotient.Contains("("))
                {
                    int start = quotient.IndexOf( "(");
                    int end = quotient.IndexOf( ")");
                    int repeatingDigits = end - start-1;
                    if (repeatingDigits > maxRepeatingDigits)
                    {
                        maxRepeatingDigits = repeatingDigits;
                        d = ii;
                    }

                }
            }

            Console.WriteLine(maxRepeatingDigits);
            Console.WriteLine(d);
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
                    if( numerator == 0)
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

            } while( true);

            string answer = "";

            for( int ii=0; ii<quotientDigits.Count; ii++)
            {
                if( ii == quotientDigits.Count - repeatingDigits)
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

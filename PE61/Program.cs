﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;

/*
 * Triangle, square, pentagonal, hexagonal, heptagonal, and octagonal numbers are all figurate (polygonal) numbers and are generated by the following formulae:

Triangle	 	P3,n=n(n+1)/2	 	1, 3, 6, 10, 15, ...
Square	 	P4,n=n2	 	1, 4, 9, 16, 25, ...
Pentagonal	 	P5,n=n(3n1)/2	 	1, 5, 12, 22, 35, ...
Hexagonal	 	P6,n=n(2n1)	 	1, 6, 15, 28, 45, ...
Heptagonal	 	P7,n=n(5n3)/2	 	1, 7, 18, 34, 55, ...
Octagonal	 	P8,n=n(3n2)	 	1, 8, 21, 40, 65, ...
The ordered set of three 4-digit numbers: 8128, 2882, 8281, has three interesting properties.

The set is cyclic, in that the last two digits of each number is the first two digits of the next number (including the last number with the first).
Each polygonal type: triangle (P3,127=8128), square (P4,91=8281), and pentagonal (P5,44=2882), is represented by a different number in the set.
This is the only set of 4-digit numbers with this property.
Find the sum of the only ordered set of six cyclic 4-digit numbers for which each polygonal type: triangle, square, pentagonal, hexagonal, heptagonal, and octagonal, is represented by a different number in the set.
 */
namespace PE61
{
    class Program
    {
        static void Main(string[] args)
        {
                var figs = new List<long>[6];
                for (int ii = 0; ii < 6; ii++)
                {
                    figs[ii] = new List<long>();
                    System.Collections.IEnumerable enumerator = null;
                    switch (ii)
                    {
                        case 0: enumerator = Util.TriangleGenerator(1); break;
                        case 1: enumerator = Util.SquareGenerator(1); break;
                        case 2: enumerator = Util.PentagonalGenerator(1); break;
                        case 3: enumerator = Util.HexagonalGenerator(1); break;
                        case 4: enumerator = Util.HeptagonalGenerator(1); break;
                        case 5: enumerator = Util.OctagonalGenerator(1); break;
                        default: System.Diagnostics.Debug.Assert(false); break;
                    }
                    foreach (long n in enumerator)
                    {
                        if (n >= 1000)
                        {
                            if (n <= 9999)
                            {
                               // Console.WriteLine("" + ii + ":" + n);
                                figs[ii].Add(n);
                            }
                            else
                            {
                               break;
                            }
                        }
                    }
                }

                foreach (long perm in Util.LexographicPermutationGenerator(new int[] { 1, 2, 3, 4, 5, 6 }))
                {
                    int[] permArray = Util.LongToArrayOfDigits(perm);

                    foreach (long tn in figs[permArray[0]-1])
                    {
                        long sum = 0;
                        long last2 = Last2(tn);
                        long first2 = First2(tn);

                        sum = SearchRecur(figs, permArray, 1, last2, first2);
                        if (sum != -1)
                        {
                            Console.WriteLine("" + (permArray[0]-1) + " " + tn);
                            sum += tn;
                            Console.WriteLine(sum);
                            //Util.ShowResult(sum);
                        }
                    }
                }
            
        }

        public static long SearchRecur(List<long>[] figs, int[] permArray, int depth, long last2, long veryFirst)
        {
            // Stop recursion
            if (depth > 5)
            {
                if (last2 == veryFirst)
                {
                    // Found and answer!
                    Console.WriteLine("Found answer!");
                    return 0;
                }
                else
                {
                    //Console.WriteLine( "" + last2 + "!=" + veryFirst);
                    return -1; // Not an answer
                }
            }

            foreach (long tn in figs[permArray[depth]-1])
            {
                long first2 = First2(tn);
                if (first2 == last2)
                {
                    long sum = SearchRecur(figs, permArray, depth+1, Last2(tn), veryFirst);
                    if (sum != -1)
                    {
                        Console.WriteLine( "" + (permArray[depth]-1) + " " + tn);
                        sum += tn;
                        return sum;
                    }
                }
                if (first2 > last2)
                {
                    break;
                }
            }
            return -1; // Didn't find anything
        }

        public static long First2(long n)
        {
            return n / (long) 100;
        }

        public static long Last2(long n)
        {
            return n % (long) 100;
        }
    }
}

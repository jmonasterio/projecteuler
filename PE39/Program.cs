using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE39
{
    class Program
    {
        /*
         * 
         * If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

            {20,48,52}, {24,45,51}, {30,40,50}

            For which value of p  1000, is the number of solutions maximised?
                     * 
         */
        static void Main(string[] args)
        {
            // Init array of counts
            int[] p = new int[10000];
            for( int ii=0; ii<p.Length; ii++)
            {
                p[ii] = 0;
            }

            for (int aa = 1; aa <= 1000; aa++)
            {
                for (int bb = 1; bb <= 1000; bb++)
                {
                    double root = Math.Sqrt(Math.Pow(aa, 2) + Math.Pow(bb, 2));
                    if (Math.Abs(root - (int)root)<.00001)
                    {
                        int perim = ( (int) Math.Round(root) + aa + bb);
                        if (perim <= 1000)
                        {
                            p[perim]++;
                            Console.WriteLine(perim);
                        }
                    }
                }
            }

            int index = 0;
            int max = 0;
            for( int ii=0; ii<p.Length; ii++)
            {
                if( p[ii] > max)
                {
                    index =ii;
                    max = p[ii];
                }
            }

            Console.WriteLine("Max: " + index);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}

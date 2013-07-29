using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE58
{
    class Program
    {
        static void Main(string[] args)
        {
            int layer = 2; // Start on second layer.
            int lengthOfSide = 3;
            int primeCount = 0;
            int totalDiagonals = 5;
            int firstNum = 2;
            int lastNum = 9;

            do
            {
                if( PELib.Util.IsPrime( firstNum+(lengthOfSide-2)))
                {
                    primeCount++;
                }
                if( PELib.Util.IsPrime( firstNum+(lengthOfSide-2) + lengthOfSide-1))
                {
                    primeCount++;
                }
                if( PELib.Util.IsPrime( firstNum+(lengthOfSide-2) + (lengthOfSide-1)*2))
                {
                    primeCount++;
                }
                if( PELib.Util.IsPrime( firstNum+(lengthOfSide-2) + (lengthOfSide-2)*3))
                {
                    primeCount++;
                }

                double ratio = (double) primeCount / (double) totalDiagonals;

                Console.WriteLine("FIRST: " + firstNum + " LAST: " + lastNum + " PRIMECOUNT: " + primeCount + "TOTALDIAGS: " + totalDiagonals + " SIDE: " + lengthOfSide + " RATIO: " + ratio);

                // Did we find solution?
                if (ratio < 0.1)
                {
                    break;
                }

                layer++;
                lengthOfSide = (layer * 2 - 1);
                totalDiagonals = (layer - 1) * 4 + 1;
                firstNum = (int) Math.Pow((layer-1)*2-1, 2)+1;
                lastNum = (int) Math.Pow(layer*2 -1, 2);



            } while( true);

            PELib.Util.ShowResult(lengthOfSide);


        }
    }
}

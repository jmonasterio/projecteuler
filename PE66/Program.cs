using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PELib;
using System.Numerics;

namespace PE66
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger maxXX = new BigInteger(0);
            long foundD = 0;

            var ListOfSquares = new List<BigInteger>();
            var idx = new BigInteger(2);
            do
            {
                var p2 = BigInteger.Pow(idx, 2);
                ListOfSquares.Add(p2);

                idx++;
            } while (idx < 10000);

            foreach (long D in Util.NonSquareGenerator(2))
            {

                // From here: http://en.wikipedia.org/wiki/Pell's_equation
                // One of the numerator/denominators from continued fraction sequence will solve this type of equation for sqrt(D)
                foreach (BigInteger[] frac in Util.ContinuedFractionSquareRootGenerator(D))
                {
                    BigInteger x = frac[0];
                    BigInteger y = frac[1];

                    if (BigInteger.Subtract(BigInteger.Pow(x, 2), BigInteger.Multiply(BigInteger.Pow(y, 2), D)) == new BigInteger(1))
                    {
                        // Solution.
                        Console.WriteLine("D: " + D + " x=" + x);

                        if (BigInteger.Compare(x, maxXX) > 0)
                        {
                            maxXX = x;
                            foundD = D;
                        }
                        break;
                    }
                }

                if (D >= 1000)
                {
                    break;
                }
            }
            Util.ShowResult(foundD);


            /* Old

            foreach (long D in Util.NonSquareGenerator( 2 ))
            {
                long yy = 1;
                bool bFound = false;

                while( true)
                {
                    var dySquared = BigInteger.Add(1, BigInteger.Multiply(D, BigInteger.Pow(new BigInteger(yy), 2)));

                    // Fast way
                    if( ListOfSquares.Contains( dySquared))
                    {
                            if ( BigInteger.Compare(dySquared, maxXX) > 0)
                            {
                                maxXX = dySquared;
                                foundD = D;
                            }
                            Console.WriteLine("D: " + D + " x^2=" + dySquared);
                            bFound = true;
                            break;
                    }
                    // Slow way
                    else if (dySquared > ListOfSquares[ListOfSquares.Count - 1])
                    {
                        if (Util.IsPerfectSquare(dySquared))
                        {
                            if (BigInteger.Compare(dySquared, maxXX) == 0)
                            {
                                    maxXX = dySquared;
                                    foundD = D;
                            }
                            Console.WriteLine("D: " + D + " x^2=" + dySquared);
                            bFound = true;
                            break;
                            
                        }
                    }
                    if (bFound)
                    {
                        break;
                    }

                    yy++;
                }


                if (D >= 1000)
                {
                    break;
                }
            }
             * 
             */

            Util.ShowResult(foundD);
        }
    }
}

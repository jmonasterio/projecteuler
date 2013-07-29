using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using PELib;

namespace PE63
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * The 5-digit number, 16807=7^5, is also a fifth power. Similarly, the 9-digit number, 134217728=89, is a ninth power.

                How many n-digit positive integers exist which are also an nth power?
             */
            int count = 1; // Start a 1^1 = 1 digit.
            int ii =2;

            int found;
            do
            {
                found = 0;
                int p = 1;
                do
                {

                    BigInteger pow = BigInteger.Pow(new BigInteger(ii) , p);
                    int digits = (int) BigInteger.Log10(pow) + 1;
                    if ( digits == p)
                    {
                        count++;
                        found++;
                    }
                    else if( digits > p)
                    {
                        break;
                    }
                    else if (p > 1000)
                    {
                        break;
                    }

                    p++;
                } while(true);


                ii++;
            } while( found > 0);

            PELib.Util.ShowResult(count);
        }
    }
}

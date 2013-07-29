using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using PELib;

namespace PE48
{
    class Program
    {
        static void Main(string[] args)
        {
            // Switched to .NET 4.0, so no I can use the BigInteger class.
            BigInteger sum = 0;
            for (int ii = 1; ii <= 1000; ii++)
            {
                sum += BigInteger.Pow(ii, ii); ;
            }

            string s = sum.ToString();
            Console.WriteLine(s);
            Util.ShowResult( s.Substring( s.Length-10, 10));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE53
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(PELib.Util.C(5, 3));
            System.Console.WriteLine(PELib.Util.C(23, 10));

            int count = 0;

            for (int n = 1; n <= 100; n++)
            {
                for( int r=1; r<=100; r++)
                {
                    if( PELib.Util.C( n,r)>1000000)
                    {
                        count++;
                    }
                }
            }

            PELib.Util.ShowResult(count);
        }
    }
}

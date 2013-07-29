using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PELib;
using System.Collections;

namespace PE45
{
    class Program
    {

       

        static void Main(string[] args)
        {
            long x = 0;

            foreach (long hexagonal in Util.HexagonalGenerator(1))
            {
                // NOTE: All triangle are hexagonal:
                if (Util.IsPentagonal(hexagonal))
                {
                    x = hexagonal;
                    if (x > 40755)
                    {
                        break;
                    }
                }
            }


            Util.ShowResult(x);
        }
    }
}

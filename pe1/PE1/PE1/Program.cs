using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int last = 1000;
            for (int ii = 1; ii < last; ii++)
            {
                if ((ii % 3 == 0) || (ii % 5 == 0))
                {
                    sum+= ii;
                }
            }

            Console.Write(sum);
            Console.ReadLine();
        }
    }
}

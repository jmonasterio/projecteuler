using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE6
{
    class Program
    {
        static long SumOfSquares(int x)
        {
            long sum = 0;
            for( int ii=1; ii<=x; ii++)
            {
                sum += (long) Math.Pow(ii,2);
            }
            return sum;

        }

        static long SquareOfSums(int x)
        {
            long square = 0;
            long sum = 0;
            for( int ii=1; ii<=x; ii++)
            {
                sum += ii;
            }
            square = (long) Math.Pow(sum,2);
            return square;
        }


        static void Main(string[] args)
        {
            int x = 100;
            long diff = 0;

            long sum_of_squares = SumOfSquares(x);
            long square_of_sums = SquareOfSums(x);
            diff = square_of_sums - sum_of_squares;


            Console.WriteLine(diff);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();

        }
    }
}

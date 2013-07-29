using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE31
{
    class Program
    {
        /*
         * In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

            1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
            It is possible to make £2 in the following way:

            1x£1 + 1x50p + 2x20p + 1x5p + 1x2p + 3x1p
            How many different ways can £2 be made using any number of coins?
         */
        static void Main(string[] args)
        {

            int count = 1; // For 2 pound note.

            // brute force. Lost of room for optimization, but only 275M combos.

            for (int p100 = 0; p100 <= 2; p100++)
            {
                for (int p50 = 0; p50 <= 4; p50++)
                {
                    for (int p20 = 0; p20 <= 10; p20++)
                    {
                        for (int p10 = 0; p10 <= 20; p10++)
                        {
                            for (int p5 = 0; p5 <= 40; p5++)
                            {
                                for (int p2 = 0; p2 <= 100; p2++)
                                {
                                    for (int p1 = 0; p1 <= 200; p1++)
                                    {
                                        if( p1 + 2*p2 + 5*p5 + 10*p10 + 20 *p20 + 50*p50 + 100 *p100 == 200)
                                        {
                                            count++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count);
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Enter number of tests: ");
                int tests;
                if (!int.TryParse(Console.ReadLine(), out tests))
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine("Performing tests...");

                ulong justinMethodAvgTries = testMethod(LotteryMethod.Justin, tests);
                ulong reinaMethodAvgTries = testMethod(LotteryMethod.Reina, tests);

                Console.WriteLine();
                Console.WriteLine("Justin method takes an average of " + justinMethodAvgTries.ToString() + " tries to win the lottery.");
                Console.WriteLine("Reina method takes an average of " + reinaMethodAvgTries.ToString() + " tries to win the lottery.");

                Console.WriteLine();
                if (justinMethodAvgTries < reinaMethodAvgTries)
                {
                    Console.WriteLine("Justin method wins faster by " + (reinaMethodAvgTries - justinMethodAvgTries).ToString() + " tries.");
                }
                else if (justinMethodAvgTries > reinaMethodAvgTries)
                {
                    Console.WriteLine("Reina method wins faster by " + (justinMethodAvgTries - reinaMethodAvgTries).ToString() + " tries.");
                }
                else
                {
                    Console.WriteLine("Reina method and Justin method tie");
                }
                Console.ReadKey();
            }
        }

        static ulong testMethod(LotteryMethod method, int tests)
        {
            ulong trySum = 0;
            for (int i = 0; i < tests; i++)
            {
                trySum += calculateMethodTries(method);
            }
            ulong avgTries = trySum / (ulong)tests;
            return avgTries;
        }

        static ulong calculateMethodTries(LotteryMethod method)
        {
            Random rand = new Random();
            ulong tries = 0;
            int currentTry = rand.Next(0, 1000);
            while (currentTry != rand.Next(0, 1000))
            {
                tries++;
                if (method == LotteryMethod.Justin)
                {
                    currentTry = rand.Next(0, 1000);
                }
            }
            return tries;
        }

        enum LotteryMethod : byte
        {
            Justin = 0,
            Reina = 1
        }
    }
}

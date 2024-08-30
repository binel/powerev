using System;

namespace Powerev
{
    public class Play
    {
        public int WinningBalls {get; set;}

        public bool WonPowerball {get; set;}

        public int PowerPlayMultiplier {get; set;} = 1;

        public double BasePrize {get; set;}

        public override string ToString()
        {
            if (!WonPowerball)
            {
                return $"Match {WinningBalls} (no powerball). Prize {BasePrize}. Odds 1 in {1 / Odds()}. EV {ExpectedValue()}";
            }
            else 
            {
                return $"Match {WinningBalls} + powerball. Prize {BasePrize}. Odds 1 in {1 / Odds()}. EV {ExpectedValue()}";
            }
        }

        public double ExpectedValue()
        {
            return BasePrize / (1 / Odds());
        }

        public double Odds() {
            var totalPossibleTickets = Choose(69, 5) * Choose(26, 1);
            var waysToPickLosers = Choose(64, 5 - WinningBalls); 
            var waysToPickWinners = Choose(5, WinningBalls); 
            long totalWays = waysToPickLosers * waysToPickWinners; 
            if (!WonPowerball) 
            {
                totalWays *= Choose(25, 1);
            }
            return (double) totalWays / (double) totalPossibleTickets;
        }
        
        private static long Choose(int total, int choice) 
        {
            if (choice == 0)
            {
                return 1;
            }

            long num = 1; 
            int num_total = total;
            for (int i = 0; i < choice; i++) 
            {
                num *= num_total; 
                num_total -= 1; 
            }

            return num / Fact(choice);
        }

        private static long Fact(int n) 
        {
            long result = 1; 
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}

using System;

namespace Powerev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Playing powerball consists of selecting 5 numbers between 1 and 69 and 1 number between 
            // 1 and 26 (the powerball). If powerplay is selected a non-jackpot prize can be multiplied 
            // by 2, 3, 4, 5, or 10 times. 
            //
            // Prizes are as follows: 
            // Matching 5 balls and the powerball results in the grand prize, which has a variable payout 
            // Matching 5 balls alone results in a $1M. Power play can multiply this to $2M 
            // Matching 4 balls + powerball is a $50K, Power play can multiply this to 500K
            // Matching 4 balls alone is $100, Power play can multiply this to $1,000
            // Matching 3 balls + powerball is $100, Power play can multiply this to $1,000
            // Matching 3 balls alone is $7, Power play can multiply this to $70 
            // Matching 2 balls + powerball is $7, Power play can multiply this to $70 
            // Matching 1 ball + powerball is $4, Power play can multiply this to $40
            // Matching just the powerball is $4, Power play can multiply this to $40 
            //
            // Prizes are exclusive - a single ticket can only yeild a single prize 
           
            var jackpot = 44_000_000.0;

            bool is10PowerPlayAvailable = jackpot < 150_000_000.0;

            Console.WriteLine($"Provided jackpot: ${jackpot}");

            List<Play> possiblePlays = new List<Play> {
                new Play {
                    WinningBalls = 0,
                    WonPowerball = true,
                    BasePrize = 4.0, 
                },
                new Play {
                    WinningBalls = 1,
                    WonPowerball = true,
                    BasePrize = 4.0, 
                },
                new Play {
                    WinningBalls = 2,
                    WonPowerball = true,
                    BasePrize = 7.0, 
                },
                new Play {
                    WinningBalls = 3,
                    WonPowerball = false,
                    BasePrize = 7.0, 
                },
                new Play {
                    WinningBalls = 3,
                    WonPowerball = true,
                    BasePrize = 100.0, 
                },
                new Play {
                    WinningBalls = 4,
                    WonPowerball = true,
                    BasePrize = 100.0, 
                },
                new Play {
                    WinningBalls = 4,
                    WonPowerball = true,
                    BasePrize = 50_000.0, 
                },
                new Play {
                    WinningBalls = 5,
                    WonPowerball = false,
                    BasePrize = 1_000_000.0, 
                },
                new Play {
                    WinningBalls = 5,
                    WonPowerball = true,
                    BasePrize = jackpot, 
                }
            };

            foreach (var play in possiblePlays)
            {
                Console.WriteLine(play);
            }
            var ev = possiblePlays.Sum(p => p.ExpectedValue());
            Console.WriteLine($"(Non power play) Total ev: {ev}. Expected win: {ev - 2.0}"); 
        }

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
}

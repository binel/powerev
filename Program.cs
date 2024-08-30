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
            
            PlayBuilder.Jackpot = JackpotDownloader.GetJackpot().Result;

            Console.WriteLine($"Provided jackpot: ${PlayBuilder.Jackpot}");


            foreach (var play in PlayBuilder.BasePlays)
            {
                Console.WriteLine(play);
            }
            var ev = PlayBuilder.BasePlays.Sum(p => p.ExpectedValue());
            Console.WriteLine($"(Non power play) Total ev: {ev}. Expected win: {ev - 2.0}"); 
        }

        public static void Sim(Random rand)
        {
            // Choose the winning numbers 
            List<int> winningNums = Enumerable.Range(1, 69)
                .OrderBy(x => rand.Next())
                .Take(5)
                .ToList();

            int powerBall = Enumerable.Range(1, 26)
                .OrderBy(x => rand.Next())
                .Take(1)
                .First();

            // Choose the played numbers 
            List<int> playedNums = Enumerable.Range(1, 69)
                .OrderBy(x => rand.Next())
                .Take(5)
                .ToList();

            int playedPowerBall = Enumerable.Range(1, 26)
                .OrderBy(x => rand.Next())
                .Take(1)
                .First();

            // Count the number of matching numbers
            int matchingNumbers = playedNums.Intersect(winningNums).Count();

            // Check if the PowerBall matches
            bool isPowerBallMatch = playedPowerBall == powerBall;

            // Output the results
            Console.WriteLine("Winning Numbers: " + string.Join(", ", winningNums) + " PowerBall: " + powerBall);
            Console.WriteLine("Played Numbers: " + string.Join(", ", playedNums) + " PowerBall: " + playedPowerBall);
            Console.WriteLine("Matching Numbers: " + matchingNumbers);
            Console.WriteLine("PowerBall Match: " + isPowerBallMatch);     

        }



    }
}

using System;

namespace Powerev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayBuilder.Jackpot = 93_000_000.0;

            double runningTotal = 0.0; // how much money we've gained / lost 
            int tickets = 0; // total number of tickets we've bought 
        
            Simulator sim = new Simulator();
            sim.NewNumbers();
            
            double averageWinnings = 0.0;
            for (int simRuns = 0; simRuns < 1_000; simRuns++) {
                runningTotal = 0;
                tickets = 0; 
                while (runningTotal <= 0) {
                    tickets++;
                    runningTotal -= 2.0;
                    runningTotal += sim.Sim1Ticket();    
                    if (tickets > 1_000_000) {
                        // if we still aren't positive after a million tickets, give up. 
                        break;
                    }
                }
                if (runningTotal > 0) {
                    Console.WriteLine($"{simRuns}: Positive Run: {runningTotal} with {tickets} tickets");
                }
                else {
                    Console.WriteLine($"{simRuns}: Negative Run: {runningTotal} with {tickets} tickets");
                }
                averageWinnings += runningTotal;
            }

            averageWinnings = averageWinnings / 1_000;

            Console.WriteLine($"Average winnings over 1,000 sims: {averageWinnings}");

        }
    }
}

using System;

namespace Powerev
{
    internal class Program {
        static void Main(string[] args) {
            var maxSimRuns = int.Parse(args[0]);
            var requiredProfit = int.Parse(args[1]);
            var maxTickets = int.Parse(args[2]);
            
            Console.WriteLine($"Running with {maxSimRuns} sim runs, required profit {requiredProfit}, max tickets {maxTickets}");

            for (double jackpot = 1_000_000.0;  jackpot < 1_000_000_000; jackpot += 1_000_000) {
                PlayBuilder.Jackpot = jackpot;
                var ev = PlayBuilder.GetTotalEv() - 2.0;

                Console.WriteLine($"{jackpot} - ev: {ev}");

                if (ev > 0) {
                    Console.WriteLine($"Positive ev found at jackpot {jackpot}. Running sims...");
                    SimAtValue(maxSimRuns, requiredProfit, maxTickets);
                }
            }
        }

        static void SimAtValue(int maxSimRuns, int requiredProfit, int maxTickets) {
            double runningTotal = 0.0; // how much money we've gained / lost 
            int tickets = 0; // total number of tickets we've bought 
        
            Simulator sim = new Simulator();
            sim.NewNumbers();
            
            double averageWinnings = 0.0;
            double averageTickets = 0.0;
            for (int simRuns = 0; simRuns < maxSimRuns; simRuns++) {
                runningTotal = 0;
                tickets = 0; 
                while (runningTotal < requiredProfit) {
                    tickets++;
                    runningTotal -= 2.0;
                    runningTotal += sim.Sim1Ticket();

                    if (maxTickets != 0 && tickets >= maxTickets) {
                        break;
                    }
                }
                if (runningTotal > 0) {
                    Console.WriteLine($"\t{simRuns}: Positive Run: {runningTotal} with {tickets} tickets");
                }
                else {
                    Console.WriteLine($"\t{simRuns}: Negative Run: {runningTotal} with {tickets} tickets");
                }

                averageWinnings += runningTotal;
                averageTickets += (double)tickets;
            }

            averageWinnings = averageWinnings / maxSimRuns;
            averageTickets = averageTickets / maxSimRuns;
            Console.WriteLine($"Average winnings over {maxSimRuns} sims: {averageWinnings}. Average tickets: {averageTickets}");
        }
    }
}

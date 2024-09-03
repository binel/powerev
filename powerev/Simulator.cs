using System;
namespace Powerev;

public class Simulator {
   
    public List<int> WinningNumbers {get; set;}
    public int Powerball {get; set;}
    
    private Random _rand;

    public Simulator()
    {
        _rand = new Random();
    }

    // Causes the winning numbers to be reset 
    public void NewNumbers() {
        // Choose the winning numbers 
        WinningNumbers = Enumerable.Range(1, 69)
            .OrderBy(x => _rand.Next())
            .Take(5)
            .ToList();

        Powerball = Enumerable.Range(1, 26)
            .OrderBy(x => _rand.Next())
            .Take(1)
            .First();
    }

    // Returns the prize from simulation of 
    // buying 1 ticket 
    public double Sim1Ticket() {
        // Choose the played numbers 
        List<int> playedNums = Enumerable.Range(1, 69)
            .OrderBy(x => _rand.Next())
            .Take(5)
            .ToList();

        int playedPowerBall = Enumerable.Range(1, 26)
            .OrderBy(x => _rand.Next())
            .Take(1)
            .First();

        // Count the number of matching numbers
        int matchingNumbers = playedNums.Intersect(WinningNumbers).Count();

        // Check if the PowerBall matches
        bool isPowerBallMatch = playedPowerBall == Powerball;

        // Get the prize value 
        return PlayBuilder.GetPrize(matchingNumbers, isPowerBallMatch);
    }

}

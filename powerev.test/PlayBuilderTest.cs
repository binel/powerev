using System;

using Powerev;

namespace Powerev.Test;

public class PlayBuilderTest {
    

    [TestCase(0, false, 0.0)]
    [TestCase(0, true, 4.0)]
    [TestCase(1, false, 0.0)]
    [TestCase(1, true, 4.0)]
    [TestCase(2, false, 0.0)]
    [TestCase(2, true, 7.0)]
    [TestCase(3, false, 7.0)]
    [TestCase(3, true, 100.0)]
    [TestCase(4, false, 100.0)]
    [TestCase(4, true, 50_000.0)]
    [TestCase(5, false, 1_000_000.0)]
    [TestCase(5, true, 10_000_000.0)]
    public void WinningPlays(int matchingBalls, bool powerballMatch, double expectedPrize) {
        PlayBuilder.Jackpot = 10_000_000.0;

        var prize = PlayBuilder.GetPrize(matchingBalls, powerballMatch);

        Assert.That(prize, Is.EqualTo(expectedPrize));
    }
}


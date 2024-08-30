using System;
namespace Powerev {
    public class PlayBuilder {
        
        public static double Jackpot {get; set;}
        
        public static List<Play> BasePlays {get;} =  new List<Play> {
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
                    BasePrize = Jackpot, 
                }
            };
    }
}

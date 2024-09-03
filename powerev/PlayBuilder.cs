using System;
using System.Linq;

namespace Powerev {
    public class PlayBuilder {
        
        private static double _jackpot;

        public static double Jackpot {
            get {
                return _jackpot;
            }
            set {
                _jackpot = value;
                BasePlays.Where(p => p.WinningBalls == 5 && p.WonPowerball).First().BasePrize = value;
            }
        }
        
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
                    WonPowerball = false,
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

        public static double GetTotalEv() {
            return BasePlays.Sum(p => p.ExpectedValue()); 
        }

        public static double GetPrize(int MatchingBalls, bool WonPowerball) {
            var play  = BasePlays.Where(p => p.WinningBalls == MatchingBalls && p.WonPowerball == WonPowerball).FirstOrDefault();

            if (play == null) {
                return 0.0;
            } else {
                return play.BasePrize;
            }
        }
    }
}

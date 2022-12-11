using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            double chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
            if (racerOne.RacingBehavior == "strict")
            {
                chanceOfWinningRacerOne *= 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                chanceOfWinningRacerOne *= 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                chanceOfWinningRacerTwo *= 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                chanceOfWinningRacerTwo *= 1.1;
            }

            IRacer winner;

            if (chanceOfWinningRacerOne > chanceOfWinningRacerTwo)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }
            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }
    }
}

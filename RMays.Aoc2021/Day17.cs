using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 17
    /*
--- Day 0: Template ---

    */
    #endregion

    // It's been so long since I looked at this, that I'm going to start over.
    public class Day17 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var tokens = input.Split(' ');
            var targetX = (int.Parse(tokens[2].Split('=')[1].Split('.')[0]), int.Parse(tokens[2].Split('=')[1].Split('.')[2].Split(',')[0]));
            var targetY = (int.Parse(tokens[3].Split('=')[1].Split('.')[0]), int.Parse(tokens[3].Split('=')[1].Split('.')[2]));

            //var result = HowFarOff((0, 0), targetX, targetY);
            var result = HowFarOff((7, 2), targetX, targetY);

            return result;
        }

        private int HowFarOff((int, int) velocity, (int, int) targetX, (int, int) targetY)
        {
            var currX = 0;
            var currY = 0;
            var minDistAway = int.MaxValue;
            var diffX = Math.Abs(targetX.Item1 - targetX.Item2);
            var diffY = Math.Abs(targetY.Item1 - targetY.Item2);
            while (currX <= targetX.Item2 || currY <= targetY.Item2)
            {
                currX += velocity.Item1;
                currY += velocity.Item2;
                var deltaVelocityX = 0;
                if (velocity.Item1 > 0) deltaVelocityX = -1;
                else if (velocity.Item1 < 0) deltaVelocityX = 1;
                velocity = (velocity.Item1 + deltaVelocityX, velocity.Item2 - 1);

                var diffLeft = Math.Abs(currX - targetX.Item1);
                var diffRight = Math.Abs(currX - targetX.Item2);
                var diffDown = Math.Abs(currY - targetY.Item1);
                var diffUp = Math.Abs(currY - targetY.Item2);

                var distAway = ((diffLeft + diffRight - diffX) / 2) + ((diffUp + diffDown - diffX) / 2);
                if (distAway == 0)
                {
                    // Hit the target!
                    return 0;
                }

                minDistAway = Math.Min(minDistAway, distAway);

                /*
                minDiffNorth = Math.Min(diffNorth, minDiffNorth);
                minDiffSouth = Math.Min(diffSouth, minDiffSouth);
                minDiffEast = Math.Min(diffEast, minDiffEast);
                minDiffWest = Math.Min(diffWest, minDiffWest);
                */
            }

            //return minDiffNorth + minDiffSouth + minDiffEast + minDiffWest;
            return -1;
        }
    }
}

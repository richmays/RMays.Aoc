using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day17b : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var tokens = input.Split(' ');
            var targetX = (int.Parse(tokens[2].Split('=')[1].Split('.')[0]), int.Parse(tokens[2].Split('=')[1].Split('.')[2].Split(',')[0]));
            var targetY = (int.Parse(tokens[3].Split('=')[1].Split('.')[0]), int.Parse(tokens[3].Split('=')[1].Split('.')[2]));

            // DoItA: this is a Hit!
            //var result1 = WillHitTarget((15, 10), targetX, targetY);

            // Solution for PartATests.
            //var result1 = WillHitTarget((6, 9), targetX, targetY);

            // Best for Part A.
            //var result1 = WillHitTarget((14, 48), targetX, targetY);
            //return -1;

            // Let's build a grid of successes / failures.
            // NOTE: I only found these values after running Part A, and seeing where the hits were.
            // Actual range:   X: 14..157, Y: -146..145

            int minX = 1;
            int maxX = 200;
            int minY = -200;
            int maxY = 200;
            var hits = new bool[maxX - minX + 1, maxY - minY + 1];
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if (WillHitTarget((x, y), targetX, targetY))
                    {
                        hits[x - minX, y - minY] = true;
                    }
                }
            }

            int lowestX = int.MaxValue;
            int highestX = int.MinValue;
            int lowestY = int.MaxValue;
            int highestY = int.MinValue;

            long hitCount = 0;
            for(int y = maxY; y >= minY; y--)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    if (hits[x - minX, y - minY])
                    {
                        if (!IsPartB)
                        {
                            Console.WriteLine($"HIT with initial velocity: ({x},{y})");

                            // Assuming it didn't hit the target before it reached the top of the arc,
                            // the height is the triangle number of the initial Y velocity.
                            return y * (y + 1) / 2;
                        }
                        else
                        {
                            if (x < lowestX) lowestX = x;
                            if (x > highestX) highestX = x;
                            if (y < lowestY) lowestY = y;
                            if (y > highestY) highestY = y;

                            hitCount++;
                        }
                    }
                }
            }

            // part B only
            Console.WriteLine($"X: {lowestX}..{highestX}, Y: {lowestY}..{highestY}");
            return hitCount;
        }

        private bool WillHitTarget((int, int) initialVelocity, (int, int) targetX, (int, int) targetY)
        {
            int currX = 0;
            int currY = 0;
            int velX = initialVelocity.Item1;
            int velY = initialVelocity.Item2;

            //Console.WriteLine($"TargetX: {targetX.Item1}..{targetX.Item2}, TargetY: {targetY.Item1}..{targetY.Item2}");
            //Console.WriteLine($"Trying velocity: ({initialVelocity.Item1},{initialVelocity.Item2})...");

            // Try up to 1000 steps.
            for (int x = 0; x < 1000; x++)
            {
                currX += velX;
                currY += velY;
                velX += (velX > 0 ? -1 : velX < 0 ? 1 : 0);
                velY--;

                //Console.WriteLine($"Step {x}: ({currX}, {currY})");
                if (currX >= targetX.Item1 && currX <= targetX.Item2 && currY >= targetY.Item1 && currY <= targetY.Item2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

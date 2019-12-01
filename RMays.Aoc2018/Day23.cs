using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day23
    {
        public class Star : IEquatable<Star>
        {
            public long X { get; set; }
            public long Y { get; set; }
            public long Z { get; set; }
            public long Range { get; set; }

            public Star()
            {
            }

            public Star(long x, long y, long z, long range)
            {
                X = x;
                Y = y;
                Z = z;
                Range = range;
            }

            public bool IsWithinRange(Star star)
            {
                var dist = Math.Abs(X - star.X) + Math.Abs(Y - star.Y) + Math.Abs(Z - star.Z);
                return dist <= Range;
            }

            public long ManhattanFromZero()
            {
                return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
            }

            public override string ToString()
            {
                return $"({X},{Y},{Z}) r={Range}";
            }

            public bool Equals(Star other)
            {
                return (this.X == other.X && this.Y == other.Y && this.Z == other.Z && this.Range == other.Range);
            }
        }

        public List<Star> GetStars(string input)
        {
            // pos=<29104291,6406472,65924134>, r=65916701
            // pos=<-2507185,84321079,68857085>, r=62423035

            var lines = Parser.TokenizeLines(input);
            var Stars = new List<Star>();
            foreach (var line in lines)
            {
                var x = long.Parse(line.Split('<')[1].Split(',')[0]);
                var y = long.Parse(line.Split(',')[1]);
                var z = long.Parse(line.Split(',')[2].Split('>')[0]);
                var range = long.Parse(line.Split('=')[2]);
                Stars.Add(new Star(x, y, z, range));
            }

            return Stars;
        }

        public long SolveA(string input)
        {
            var Stars = GetStars(input);

            var bestStar = Stars.OrderByDescending(x => x.Range).First();
            int inRange = 0;

            foreach(var star in Stars)
            {
                if (bestStar.IsWithinRange(star)) inRange++;
            }

            return inRange;
        }

        public long SolveB(string input)
        {
            var Stars = GetStars(input);

            // bool: false for floor, true for ceiling
            var StarTuples = new List<Tuple<long, bool>>();

            foreach(var star in Stars)
            {
                var floor = star.ManhattanFromZero() - star.Range;
                var ceiling = star.ManhattanFromZero() + star.Range;
                StarTuples.Add(new Tuple<long, bool>(floor, false));
                StarTuples.Add(new Tuple<long, bool>(ceiling, true));
            }

            StarTuples = StarTuples.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();

            var bestCount = 0;
            var currCount = 0;
            var bestResult = (long)-1;
            foreach(var tuple in StarTuples)
            {
                currCount += (tuple.Item2 ? -1 : 1);
                if (currCount > bestCount)
                {
                    bestCount = currCount;
                    bestResult = tuple.Item1;
                }
            }

            return bestResult;
        }

        public long SolveB_oldway(string input)
        {
            var Stars = GetStars(input);

            var bestScore = 0;
            var bestStars = new List<Star>();

            foreach(Star currStar in Stars)
            {
                var tmpStar = new Star(currStar.X + currStar.Range, currStar.Y, currStar.Z, 0);
                var count = GetStarCountWithinRange(Stars, tmpStar);
                if (count >= bestScore)
                {
                    if (count > bestScore)
                    {
                        bestScore = count;
                        bestStars.Clear();
                    }
                    bestStars.Add(tmpStar);
                }

                tmpStar = new Star(currStar.X - currStar.Range, currStar.Y, currStar.Z, 0);
                count = GetStarCountWithinRange(Stars, tmpStar);
                if (count >= bestScore)
                {
                    if (count > bestScore)
                    {
                        bestScore = count;
                        bestStars.Clear();
                    }
                    bestStars.Add(tmpStar);
                }

                tmpStar = new Star(currStar.X, currStar.Y + currStar.Range, currStar.Z, 0);
                count = GetStarCountWithinRange(Stars, tmpStar);
                if (count >= bestScore)
                {
                    if (count > bestScore)
                    {
                        bestScore = count;
                        bestStars.Clear();
                    }
                    bestStars.Add(tmpStar);
                }

                tmpStar = new Star(currStar.X, currStar.Y - currStar.Range, currStar.Z, 0);
                count = GetStarCountWithinRange(Stars, tmpStar);
                if (count >= bestScore)
                {
                    if (count > bestScore)
                    {
                        bestScore = count;
                        bestStars.Clear();
                    }
                    bestStars.Add(tmpStar);
                }

                tmpStar = new Star(currStar.X, currStar.Y, currStar.Z + currStar.Range, 0);
                count = GetStarCountWithinRange(Stars, tmpStar);
                if (count >= bestScore)
                {
                    if (count > bestScore)
                    {
                        bestScore = count;
                        bestStars.Clear();
                    }
                    bestStars.Add(tmpStar);
                }

                tmpStar = new Star(currStar.X, currStar.Y, currStar.Z - currStar.Range, 0);
                count = GetStarCountWithinRange(Stars, tmpStar);
                if (count >= bestScore)
                {
                    if (count > bestScore)
                    {
                        bestScore = count;
                        bestStars.Clear();
                    }
                    bestStars.Add(tmpStar);
                }
            }


            // Simple, but doesn't work.
            // Example below.  The two inner 'X's are found by the algorithm, but the best point is actually the asterisks (6 less).
            // Therefore, we need to test ALL borders of ALL stars.  Shouldn't be too tough... I hope.  It gets tricky with 3 dimensions.
            /*          0
             *                X Y
             *               xx*yy
             *              xx*xxyy
             *             xx*xxxxyy
             *            Xx*xxxxxXyy
             *             *xxxxxxyyyy
             *            YyxxxxxyyyyyY
             *             yyxxxyyyyyy
             *              yyXyyyyyy
             *               yyyyyyy
             *                yyyyy
             *                 yyy
             *                  Y
             * */


            var closestPoint = bestStars.OrderBy(s => s.ManhattanFromZero()).First();

            // The actual best point should be close to this!
            // Let's walk around, collecting a list of points that have the same score.
            // If we find a point with a higher score, then clear the list and use that new score.
            var bestCoords = GetAllPointsWithSameScoreNearby(Stars, closestPoint);
            return bestCoords.OrderBy(s => s.ManhattanFromZero()).First().ManhattanFromZero();


            //return closestPoint.ManhattanFromZero();
        }

        public List<Star> GetAllPointsWithSameScoreNearby(List<Star> Stars, Star closestPoint)
        {
            var testScore = GetStarCountWithinRange(Stars, closestPoint);
            var bestStars = new List<Star>();
            var starsToCheck = new List<Star>();
            var starsChecked = new List<Star>();
            var MasterStars = new Dictionary<Star, int>();
            bestStars.Add(closestPoint);
            starsToCheck.Add(closestPoint);

            while (starsToCheck.Any())
            {
                var currStar = starsToCheck.First();
                starsToCheck.Remove(currStar);
                if (starsChecked.Contains(currStar)) continue;
                starsChecked.Add(currStar);

                var count = GetStarCountWithinRange(Stars, currStar);
                if (count < testScore) continue;

                MasterStars.Add(currStar, count);

                if (!bestStars.Contains(currStar)) bestStars.Add(currStar);
                if (!starsToCheck.Contains(currStar)) starsToCheck.Add(currStar);

                starsToCheck.Add(new Star(currStar.X - 1, currStar.Y, currStar.Z, 0));
                starsToCheck.Add(new Star(currStar.X, currStar.Y - 1, currStar.Z, 0));
                starsToCheck.Add(new Star(currStar.X, currStar.Y, currStar.Z - 1, 0));
                starsToCheck.Add(new Star(currStar.X + 1, currStar.Y, currStar.Z, 0));
                starsToCheck.Add(new Star(currStar.X, currStar.Y + 1, currStar.Z, 0));
                starsToCheck.Add(new Star(currStar.X, currStar.Y, currStar.Z + 1, 0));
            }

            // Only return the stars with the highest 'count', whatever that is.

            // What's the max?
            var max = MasterStars.Values.Max();

            return MasterStars.Where(x => x.Value == max).Select(x => x.Key).ToList();
        }

        public long SolveB_new_slow(string input)
        {
            var Stars = GetStars(input);

            var bestScore = 0;
            var bestStars = new List<Star>();

            int iStarId = 0;
            foreach (Star currStar in Stars)
            {
                iStarId++;
                if (iStarId >= 2) return -1;
                for (long diffPlus = 0; diffPlus <= currStar.Range; diffPlus++)
                {
                    var diffMinus = currStar.Range - diffPlus;

                    var tmpStar = new Star(currStar.X + diffPlus, currStar.Y + diffMinus, currStar.Z, 0);
                    var count = GetStarCountWithinRange(Stars, tmpStar);
                    if (count >= bestScore)
                    {
                        if (count > bestScore)
                        {
                            bestScore = count;
                            bestStars.Clear();
                        }
                        bestStars.Add(tmpStar);
                    }

                    tmpStar = new Star(currStar.X + diffPlus, currStar.Y, currStar.Z + diffMinus, 0);
                    count = GetStarCountWithinRange(Stars, tmpStar);
                    if (count >= bestScore)
                    {
                        if (count > bestScore)
                        {
                            bestScore = count;
                            bestStars.Clear();
                        }
                        bestStars.Add(tmpStar);
                    }

                    tmpStar = new Star(currStar.X + diffMinus, currStar.Y + diffPlus, currStar.Z, 0);
                    count = GetStarCountWithinRange(Stars, tmpStar);
                    if (count >= bestScore)
                    {
                        if (count > bestScore)
                        {
                            bestScore = count;
                            bestStars.Clear();
                        }
                        bestStars.Add(tmpStar);
                    }

                    tmpStar = new Star(currStar.X + diffMinus, currStar.Y, currStar.Z + diffPlus, 0);
                    count = GetStarCountWithinRange(Stars, tmpStar);
                    if (count >= bestScore)
                    {
                        if (count > bestScore)
                        {
                            bestScore = count;
                            bestStars.Clear();
                        }
                        bestStars.Add(tmpStar);
                    }

                    tmpStar = new Star(currStar.X, currStar.Y + diffPlus, currStar.Z + diffMinus, 0);
                    count = GetStarCountWithinRange(Stars, tmpStar);
                    if (count >= bestScore)
                    {
                        if (count > bestScore)
                        {
                            bestScore = count;
                            bestStars.Clear();
                        }
                        bestStars.Add(tmpStar);
                    }

                    tmpStar = new Star(currStar.X, currStar.Y + diffMinus, currStar.Z + diffPlus, 0);
                    count = GetStarCountWithinRange(Stars, tmpStar);
                    if (count >= bestScore)
                    {
                        if (count > bestScore)
                        {
                            bestScore = count;
                            bestStars.Clear();
                        }
                        bestStars.Add(tmpStar);
                    }
                }
            }

            // Simple, but doesn't work.
            // Example below.  The two inner 'X's are found by the algorithm, but the best point is actually the asterisks (6 less).
            // Therefore, we need to test ALL borders of ALL stars.  Shouldn't be too tough... I hope.  It gets tricky with 3 dimensions.
            /*          0
             *                X Y
             *               xx*yy
             *              xx*xxyy
             *             xx*xxxxyy
             *            Xx*xxxxxXyy
             *             *xxxxxxyyyy
             *            YyxxxxxyyyyyY
             *             yyxxxyyyyyy
             *              yyXyyyyyy
             *               yyyyyyy
             *                yyyyy
             *                 yyy
             *                  Y
             * */


            var closestPoint = bestStars.OrderBy(s => s.ManhattanFromZero()).First();
            return closestPoint.ManhattanFromZero();
        }



        public int GetStarCountWithinRange(List<Star> stars, Star tmpStar)
        {
            return stars.Where(x => x.IsWithinRange(tmpStar)).Count();
        }

    }
}

using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day25
    {
        public class Point
        {
            public List<short> Parts { get; set; }
            public Point()
            {
                Parts = new List<short> { 0, 0, 0, 0 };
            }
            public Point(short x, short y, short z, short t)
            {
                Parts = new List<short> { x, y, z, t };
            }

            public override string ToString()
            {
                return $"{Parts[0]}, {Parts[1]}, {Parts[2]}, {Parts[3]}";
            }
        }

        public long SolveA(string input)
        {
            // Sample line:  9, 0, 0, 0
            var lines = Parser.TokenizeLines(input);
            var stars = new Dictionary<int, Point>(); // Lookup; star ID (int), to its location (Point).
            var starBuddies = new Dictionary<int, List<int>>(); // star ID (int), and a list of its buddies.
            int starId = 0;
            foreach (var line in lines)
            {
                var splitLine = line.Split(',').Select(x => short.Parse(x.Trim())).ToList();
                stars.Add(starId, new Point(splitLine[0], splitLine[1], splitLine[2], splitLine[3]));
                starBuddies.Add(starId, new List<int>());
                starId++;
            }

            for (var star1 = 0; star1 < lines.Count - 1; star1++)
            {
                for (var star2 = star1 + 1; star2 < lines.Count; star2++)
                {
                    int dist = 0;
                    for (var part = 0; part < 4; part++)
                    {
                        dist += Math.Abs(stars[star1].Parts[part] - stars[star2].Parts[part]);
                    }
                    if (dist <= 3)
                    {
                        starBuddies[star1].Add(star2);
                        starBuddies[star2].Add(star1);
                    }
                }
            }

            #region old
            /*
            // Now let's add to constellations.
            var constellations = new Dictionary<int, List<int>>();

            for (starId = 0; starId < lines.Count; starId++)
            {
                bool foundConstellation = false;
                int foundConstellationId = -1;
                for (int conId = 0; conId < constellations.Count; conId++)
                {
                    foreach(var innerStarId in constellations[conId])
                    {
                        if (starId == innerStarId)
                        {
                            foundConstellation = true;
                            foundConstellationId = conId;
                        }
                    }
                    if (foundConstellation) break;
                }
                if (foundConstellation)
                {
                    constellations[foundConstellationId].Add(starId);
                }
                else
                {
                    constellations.Add(constellations.Count, new List<int> { starId });
                }
            }

            return constellations.Count;
            */
            #endregion
            // Even better plan.
            // Put each star into its own constellation,
            // then loop through each pair and see if they are close enough.

            // star ID, constellation ID
            var constellation = new Dictionary<int, int>();
            for (int i = 0; i < stars.Count; i++)
            {
                constellation.Add(i, i);
            }

            bool checkAgain = true;
            while (checkAgain)
            {
                checkAgain = false;
                for (var star1 = 0; star1 < lines.Count - 1; star1++)
                {
                    for (var star2 = star1 + 1; star2 < lines.Count; star2++)
                    {
                        if (starBuddies[star1].Contains(star2) || starBuddies[star2].Contains(star1))
                        {
                            if (constellation[star1] != constellation[star2])
                            {
                                checkAgain = true;
                                var lowId = Math.Min(constellation[star1], constellation[star2]);
                                constellation[star1] = lowId;
                                constellation[star2] = lowId;
                            }
                        }
                    }
                }
            }

            return constellation.Select(x => x.Value).Distinct().Count();
        }

        public long SolveB(string input)
        {
            var myList = Parser.Tokenize(input);
      

            return 0;
        }
    }
}

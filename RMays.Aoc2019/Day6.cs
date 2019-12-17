using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day6 : DayBase<long>
    {
        public long SolveA(string input)
        {
            return Solve(input, false);
        }

        public long Solve(string input, bool isPartB)
        {
            var myList = Parser.TokenizeLines(input);
            var Planets = new Dictionary<string, string>();
            foreach (var line in myList)
            {
                var tokens = Parser.Tokenize(line, ')');
                Planets.Add(tokens[1], tokens[0]);
            }

            var count = 0;
            if (!isPartB)
            {
                foreach (var planet in Planets.Keys)
                {
                    // Get direct and indirect orbits.
                    count += GetOrbitsCount(Planets, planet);
                }

                return count;
            }

            // Part B
            // Make 2 lists.

            var list1 = GetListFromPlanet(Planets, "SAN");
            var list2 = GetListFromPlanet(Planets, "YOU");

            var commonAncestor = "";
            foreach(var item in list1)
            {
                if (!list2.Contains(item)) continue;

                // Found it!
                commonAncestor = item;
                break;
            }

            count = 0;
            foreach(var item in list1)
            {
                if (item == commonAncestor) break;
                count++;
            }

            foreach (var item in list2)
            {
                if (item == commonAncestor) break;
                count++;
            }

            return count - 2;
        }

        private int GetOrbitsCount(Dictionary<string, string> Planets, string planet)
        {
            var count = 0;
            string currPlanet = planet;
            while (currPlanet != "COM")
            {
                count++;
                currPlanet = Planets[currPlanet];
            }
            return count;
        }

        private List<string> GetListFromPlanet(Dictionary<string, string> Planets, string planet)
        {
            List<string> ToReturn = new List<string>();
            string currPlanet = planet;
            while (currPlanet != "COM")
            {
                ToReturn.Add(currPlanet);
                currPlanet = Planets[currPlanet];
            }
            return ToReturn;
        }

        public long SolveB(string input)
        {
            return Solve(input, true);
        }
    }
}

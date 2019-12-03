using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day3 : IDay<long>
    {
        public long SolveA(string input)
        {
            return SolveA(input, false);
        }

        public long SolveA(string input, bool isPartB = false)
        {
            var interCoords = new List<string>();
            var wire1Dist = new Dictionary<string, int>();
            var wire2Dist = new Dictionary<string, int>();

            var myList = Parser.TokenizeLines(input);
            var wire1Tokens = myList[0];
            var wire2Tokens = myList[1];

            var wire1Info = new WireInfo(wire1Tokens);
            var wire2Info = new WireInfo(wire2Tokens);
            var maxX = Math.Max(wire1Info.MaxX, wire2Info.MaxX);
            var maxY = Math.Max(wire1Info.MaxY, wire2Info.MaxY);
            var minX = Math.Min(wire1Info.MinX, wire2Info.MinX);
            var minY = Math.Min(wire1Info.MinY, wire2Info.MinY);
            var xOffset = minX * -1;
            var yOffset = minY * -1; 
            var grid = new bool[maxX - minX + 1, maxY - minY + 1];

            var tokens = Parser.Tokenize(myList[0]);
            var currX = 0;
            var currY = 0;
            var deltaX = 0;
            var deltaY = 0;
            foreach(var token in tokens)
            {
                var dir = token[0];
                var mag = int.Parse(token.Substring(1));
                deltaX = 0;
                deltaY = 0;
                switch(dir)
                {
                    case 'L':
                        deltaX = -1;
                        break;
                    case 'R':
                        deltaX = 1;
                        break;
                    case 'U':
                        deltaY = 1;
                        break;
                    case 'D':
                        deltaY = -1;
                        break;
                }
                for(int i = 0; i < mag; i++)
                {
                    currX += deltaX;
                    currY += deltaY;
                    //if (i + 1 == mag && tokens.Last() != token) continue;

                    var newX = currX + xOffset;
                    var newY = currY + yOffset;
                    try
                    {
                        grid[newX, newY] = true;
                    }
                    catch
                    {
                        int dummy2 = 999;
                        throw new InvalidOperationException();
                    }
                }
            }

            var bestTaxicab = wire1Info.TotalLength * wire2Info.TotalLength;


            var tokens2 = Parser.Tokenize(myList[1]);
            currX = 0;
            currY = 0;
            deltaX = 0;
            deltaY = 0;
            foreach (var token in tokens2)
            {
                var dir = token[0];
                var mag = int.Parse(token.Substring(1));
                deltaX = 0;
                deltaY = 0;
                switch (dir)
                {
                    case 'L':
                        deltaX = -1;
                        break;
                    case 'R':
                        deltaX = 1;
                        break;
                    case 'U':
                        deltaY = 1;
                        break;
                    case 'D':
                        deltaY = -1;
                        break;
                }
                for (int i = 0; i < mag; i++)
                {
                    currX += deltaX;
                    currY += deltaY;
                    //if (i + 1 == mag && tokens.Last() != token) continue;

                    var newX = currX + xOffset;
                    var newY = currY + yOffset;

                    try
                    {
                        if (grid[newX, newY])
                        {
                            if (Math.Abs(currX) + Math.Abs(currY) < bestTaxicab)
                            {
                                bestTaxicab = Math.Abs(currX) + Math.Abs(currY);
                            }
                            if (!interCoords.Contains($"{currX},{currY}"))
                            {
                                interCoords.Add($"{currX},{currY}");
                            }
                        }

                    }
                    catch
                    {
                        int dummy3 = 981;
                        throw new InvalidOperationException();
                    }
                }
            }

            if (!isPartB)
            {

                return bestTaxicab;
            }

            // We have a list.
            // Now walk both wires, keeping track of the steps.
            currX = 0;
            currY = 0;
            int steps = 0;
            foreach (var token in tokens)
            {
                var dir = token[0];
                var mag = int.Parse(token.Substring(1));
                deltaX = 0;
                deltaY = 0;
                switch (dir)
                {
                    case 'L':
                        deltaX = -1;
                        break;
                    case 'R':
                        deltaX = 1;
                        break;
                    case 'U':
                        deltaY = 1;
                        break;
                    case 'D':
                        deltaY = -1;
                        break;
                }
                for (int i = 0; i < mag; i++)
                {
                    currX += deltaX;
                    currY += deltaY;
                    steps++;
                    //if (i + 1 == mag) continue;

                    var key = $"{currX},{currY}";
                    if (interCoords.Contains(key))
                    {
                        if (!wire1Dist.ContainsKey(key))
                        {
                            wire1Dist.Add(key, steps);
                        }
                    }
                }
            }

            currX = 0;
            currY = 0;
            steps = 0;
            foreach (var token in tokens2)
            {
                var dir = token[0];
                var mag = int.Parse(token.Substring(1));
                deltaX = 0;
                deltaY = 0;
                switch (dir)
                {
                    case 'L':
                        deltaX = -1;
                        break;
                    case 'R':
                        deltaX = 1;
                        break;
                    case 'U':
                        deltaY = 1;
                        break;
                    case 'D':
                        deltaY = -1;
                        break;
                }
                for (int i = 0; i < mag; i++)
                {
                    currX += deltaX;
                    currY += deltaY;
                    steps++;
                    //if (i + 1 == mag) continue;

                    var key = $"{currX},{currY}";
                    if (interCoords.Contains(key))
                    {
                        if (!wire2Dist.ContainsKey(key))
                        {
                            wire2Dist.Add(key, steps);
                        }
                    }
                }
            }

            var fewestSteps = 99999999999;
            foreach(var key in interCoords)
            {
                var candidateSteps = wire1Dist[key] + wire2Dist[key];
                if (candidateSteps < fewestSteps)
                {
                    fewestSteps = candidateSteps;
                }
            }

            return fewestSteps;
        }

        public long SolveB(string input)
        {
            return SolveA(input, true);
        }

        internal class WireInfo
        {
            public int MinX { get; set; } = 0;
            public int MaxX { get; set; } = 0;
            public int MinY { get; set; } = 0;
            public int MaxY { get; set; } = 0;
            public int TotalLength { get; set; } = 0;

            public WireInfo(string tokens)
            {
                var tokensList = Parser.Tokenize(tokens);
                var currX = 0;
                var currY = 0;
                var deltaX = 0;
                var deltaY = 0;
                foreach (var token in tokensList)
                {
                    var dir = token[0];
                    var mag = int.Parse(token.Substring(1));
                    deltaX = 0;
                    deltaY = 0;
                    switch (dir)
                    {
                        case 'L':
                            deltaX = -1;
                            break;
                        case 'R':
                            deltaX = 1;
                            break;
                        case 'U':
                            deltaY = 1;
                            break;
                        case 'D':
                            deltaY = -1;
                            break;
                    }

                    for (int i = 0; i < mag; i++)
                    {
                        currX += deltaX;
                        currY += deltaY;
                        TotalLength++;

                        if (currX > MaxX) MaxX = currX;
                        if (currY > MaxY) MaxY = currY;
                        if (currX < MinX) MinX = currX;
                        if (currY < MinY) MinY = currY;
                    }
                }
            }

            public override string ToString()
            {
                return $"X:{MinX}..{MaxX} Y:{MinY}..{MaxY}";
            }
        }
    }
}

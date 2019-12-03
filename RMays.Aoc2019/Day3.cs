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
            var maxX = 20000;
            var maxY = 36000;
            var xOffset = maxX / 2;
            var yOffset = maxY / 2;
            var gridH = new bool[maxX, maxY];
            var gridV = new bool[maxX, maxY];

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
                    if (i + 1 == mag && tokens.Last() != token) continue;

                    var newX = currX + xOffset;
                    var newY = currY + yOffset;
                    try
                    {
                        if (deltaX != 0)
                        {
                            gridH[newX, newY] = true;
                        }
                        else
                        {
                            gridV[newX, newY] = true;
                        }
                    }
                    catch
                    {
                        int dummy2 = 999;
                        throw new InvalidOperationException();
                    }
                }
            }

            var bestTaxicab = maxX * maxY;


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
                    if (i + 1 == mag && tokens.Last() != token) continue;

                    var newX = currX + xOffset;
                    var newY = currY + yOffset;

                    try
                    {
                        if (deltaX != 0)
                        {
                            if (gridV[newX, newY])
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
                        else
                        {
                            if (gridH[newX, newY])
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
    }
}

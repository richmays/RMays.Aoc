using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day10
    {
        public class Day10_Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int VX { get; set; }
            public int VY { get; set; }
        }

        public string SolveA(string input)
        {
            // sample:
            //  position=<-31708, -21106> velocity=< 3,  2>
            var lines = Parser.TokenizeLines(input);

            var points = new List<Day10_Point>();
            foreach (var line in lines)
            {
                var commaSplit = line.Split(',');
                var newPoint = new Day10_Point
                {
                    X = int.Parse(commaSplit[0].Split('<')[1]),
                    Y = int.Parse(commaSplit[1].Split('>')[0]),
                    VX = int.Parse(commaSplit[1].Split('<')[1]),
                    VY = int.Parse(commaSplit[2].Split('>')[0])
                };
                points.Add(newPoint);
            }

            int currTime = 0;
            var area = CalculateArea(points);
            var prevArea = long.MaxValue;
            while (area < prevArea)
            {
                currTime++;
                prevArea = area;

                Forward(points);

                area = CalculateArea(points);
            }

            Backward(points);
            currTime--;

            var printableChart = PrettyPrint(points);

            Console.WriteLine(printableChart);

            //return currTime.ToString();
            return printableChart;
        }

        public long CalculateArea(List<Day10_Point> points)
        {
            long width = points.Select(p => p.X).Max() - points.Select(p => p.X).Min();
            long height = points.Select(p => p.Y).Max() - points.Select(p => p.Y).Min();
            var area = width * height;
            return area;
        }

        public void Forward(List<Day10_Point> points)
        {
            foreach (var point in points)
            {
                point.X += point.VX;
                point.Y += point.VY;
            }
        }

        public string PrettyPrint(List<Day10_Point> points)
        {
            int minX = points.Select(p => p.X).Min();
            int maxX = points.Select(p => p.X).Max();
            int minY = points.Select(p => p.Y).Min();
            int maxY = points.Select(p => p.Y).Max();

            StringBuilder result = new StringBuilder("");
            for (int y = minY; y <= maxY; y++)
            {
                var subsetPoints = points.Where(p => p.Y == y).Select(p => p.X).ToList();
                for (int x = minX; x <= maxX; x++)
                {
                    if (subsetPoints.Contains(x))
                    {
                        result.Append("#");
                    }
                    else
                    {
                        result.Append(".");
                    }
                }
                result.AppendLine();
            }
            return result.ToString().Trim();
        }

        public void Backward(List<Day10_Point> points)
        {
            foreach (var point in points)
            {
                point.X -= point.VX;
                point.Y -= point.VY;
            }
        }

        public long SolveB(string input)
        {
            var myList = Parser.Tokenize(input);
      

            return 0;
        }
    }
}

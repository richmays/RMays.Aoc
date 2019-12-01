using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day6
    {
        public long SolveA(string input)
        {
            /*
            int[,] myarray = new int[1, 200];
            */
            // 8, 3
            var myList = Parser.TokenizeLines(input);
            var coords = new List<Coords>();

            foreach (var row in myList)
            {
                var myRow = Parser.Tokenize(row);
                coords.Add(new Coords(int.Parse(myRow[0]), int.Parse(myRow[1])));
            }

            var minRow = int.MaxValue;
            var maxRow = int.MinValue;
            var minCol = int.MaxValue;
            var maxCol = int.MinValue;

            foreach (var coord in coords)
            {
                if (coord.Row < minRow) minRow = coord.Row;
                if (coord.Row > maxRow) maxRow = coord.Row;
                if (coord.Col < minCol) minCol = coord.Col;
                if (coord.Col > maxCol) maxCol = coord.Col;
            }

            // Instead of being clever, let's just grow rows and cols by the largest difference.
            var maxDiff = Math.Max(maxRow - minRow, maxCol - minCol);

            // What do we have to add to the actual row / col to get its array index?
            // Or ... just change the points by these offsets.  Then we won't need clever math.  Let's do that.
            var rowOffset = -1 * (minRow - maxDiff);
            var colOffset = -1 * (minCol - maxDiff);

            var rowRange = (maxRow - minRow) + (2 * maxDiff);
            var colRange = (maxCol - minCol) + (2 * maxDiff);

            int[,] cells = new int[rowRange, colRange];

            // key = coords ('1,2'), value = ID of the closest start.
            var newCoords = new Dictionary<Coords, int>();
            var coordId = 0;
            foreach (var coord in coords)
            {
                newCoords.Add(new Coords(coord.Row + rowOffset, coord.Col + colOffset), coordId);
                coordId++;
            }

            // Figure out the closest start to each 0-cell.
            for(var row = 0; row < rowRange; row++)
            {
                for(var col = 0; col < colRange; col++)
                {
                    var tiedForBest = false;
                    var bestDist = 999999;
                    var bestCoord = new Coords();
                    foreach(var coord in newCoords.Keys)
                    {
                        var dist = Math.Abs(coord.Row - row) + Math.Abs(coord.Col - col);
                        if (dist < bestDist)
                        {
                            bestDist = dist;
                            bestCoord = coord;
                            tiedForBest = false;
                        }
                        else if (dist == bestDist)
                        {
                            tiedForBest = true;
                        }
                    }

                    cells[row, col] = (tiedForBest ? -1 : newCoords[bestCoord]);
                }
            }

            // Now we figure out what's NOT on the outside.
            // Key: cell ID.  value: count.  (use '0' if it's on the outside.)
            var cellCounts = new Dictionary<int, int>();
            foreach(var x in newCoords.Values)
            {
                cellCounts.Add(x, 0);
            }

            for (var row = 0; row < rowRange; row++)
            {
                for (var col = 0; col < colRange; col++)
                {
                    if (cells[row, col] != -1)
                    {
                        cellCounts[cells[row, col]]++;
                    }
                }
            }

            // Now zero out the borders.
            for (var row = 0; row < rowRange; row++)
            {
                if (cells[row, 0] != -1)
                {
                    cellCounts[cells[row, 0]] = 0;
                }

                if (cells[row, colRange - 1] != -1)
                {
                    cellCounts[cells[row, colRange - 1]] = 0;
                }
            }

            for (var col = 0; col < colRange; col++)
            {
                if (cells[0, col] != -1)
                {
                    cellCounts[cells[0, col]] = 0;
                }

                if (cells[rowRange - 1, col] != -1)
                {
                    cellCounts[cells[rowRange - 1, col]] = 0;
                }
            }

            return cellCounts.Max(x => x.Value);
        }

        public long SolveB(string input, int range)
        {
            /*
            int[,] myarray = new int[1, 200];
            */
            // 8, 3
            var myList = Parser.TokenizeLines(input);
            var coords = new List<Coords>();

            foreach (var row in myList)
            {
                var myRow = Parser.Tokenize(row);
                coords.Add(new Coords(int.Parse(myRow[0]), int.Parse(myRow[1])));
            }

            var minRow = int.MaxValue;
            var maxRow = int.MinValue;
            var minCol = int.MaxValue;
            var maxCol = int.MinValue;

            foreach (var coord in coords)
            {
                if (coord.Row < minRow) minRow = coord.Row;
                if (coord.Row > maxRow) maxRow = coord.Row;
                if (coord.Col < minCol) minCol = coord.Col;
                if (coord.Col > maxCol) maxCol = coord.Col;
            }

            // Instead of being clever, let's just grow rows and cols by the largest difference.
            var maxDiff = Math.Max(maxRow - minRow, maxCol - minCol);

            // What do we have to add to the actual row / col to get its array index?
            // Or ... just change the points by these offsets.  Then we won't need clever math.  Let's do that.
            var rowOffset = -1 * (minRow - maxDiff);
            var colOffset = -1 * (minCol - maxDiff);

            var rowRange = (maxRow - minRow) + (2 * maxDiff);
            var colRange = (maxCol - minCol) + (2 * maxDiff);

            int[,] cells = new int[rowRange, colRange];

            // key = coords ('1,2'), value = ID of the closest start.
            var newCoords = new Dictionary<Coords, int>();
            var coordId = 0;
            foreach (var coord in coords)
            {
                newCoords.Add(new Coords(coord.Row + rowOffset, coord.Col + colOffset), coordId);
                coordId++;
            }

            // Figure out the total distance from EACH starting point.
            for (var row = 0; row < rowRange; row++)
            {
                for (var col = 0; col < colRange; col++)
                {
                    var totalDist = 0;
                    foreach (var coord in newCoords.Keys)
                    {
                        totalDist += Math.Abs(coord.Row - row) + Math.Abs(coord.Col - col);
                    }

                    cells[row, col] = totalDist;
                }
            }

            // Now get the count of all cells that are less than the 'range' (the integer that was passed in).
            var count = 0;
            for (var row = 0; row < rowRange; row++)
            {
                for (var col = 0; col < colRange; col++)
                {
                    if (cells[row, col] < range)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}

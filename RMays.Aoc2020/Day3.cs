using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 3
    /*
Advent of Code[About][Events][Shop][Settings][Log Out]sporkyfork2 4*
   sub y{2020}[Calendar][AoC++][Sponsors][Leaderboard][Stats]
Our sponsors help make Advent of Code possible:
American Express - We architect, code and ship software that makes us an essential part of our customers’ digital lives. Work with the latest tech and back the engineering community through open source. Find your place in tech on #TeamAmex.
--- Day 3: Toboggan Trajectory ---
With the toboggan login problems resolved, you set off toward the airport. While travel by toboggan might be easy, it's certainly not safe: there's very minimal steering and the area is covered in trees. You'll need to see which angles will take you near the fewest trees.

Due to the local geology, trees in this area only grow on exact integer coordinates in a grid. You make a map (your puzzle input) of the open squares (.) and trees (#) you can see. For example:

..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#
These aren't the only trees, though; due to something you read about once involving arboreal genetics and biome stability, the same pattern repeats to the right many times:

..##.........##.........##.........##.........##.........##.......  --->
#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
.#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
.#...##..#..#...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
..#.##.......#.##.......#.##.......#.##.......#.##.......#.##.....  --->
.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
.#........#.#........#.#........#.#........#.#........#.#........#
#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...
#...##....##...##....##...##....##...##....##...##....##...##....#
.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#  --->
You start on the open square (.) in the top-left corner and need to reach the bottom (below the bottom-most row on your map).

The toboggan can only follow a few specific slopes (you opted for a cheaper model that prefers rational numbers); start by counting all the trees you would encounter for the slope right 3, down 1:

From your starting position at the top-left, check the position that is right 3 and down 1. Then, check the position that is right 3 and down 1 from there, and so on until you go past the bottom of the map.

The locations you'd check in the above example are marked here with O where there was an open square and X where there was a tree:

..##.........##.........##.........##.........##.........##.......  --->
#..O#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
.#....X..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
..#.#...#O#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
.#...##..#..X...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
..#.##.......#.X#.......#.##.......#.##.......#.##.......#.##.....  --->
.#.#.#....#.#.#.#.O..#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
.#........#.#........X.#........#.#........#.#........#.#........#
#.##...#...#.##...#...#.X#...#...#.##...#...#.##...#...#.##...#...
#...##....##...##....##...#X....##...##....##...##....##...##....#
.#..#...#.#.#..#...#.#.#..#...X.#.#..#...#.#.#..#...#.#.#..#...#.#  --->
In this example, traversing the map using this slope would cause you to encounter 7 trees.

Starting at the top-left corner of your map and following a slope of right 3 and down 1, how many trees would you encounter?

To begin, get your puzzle input.

Answer: 
 

You can also [Share] this puzzle.

    */
    #endregion

    public class Day3 : IDay<long>
    {
        public long Solve(string input, bool IsPartB = false)
        {
            var grid = FixInput(input);
            if (!IsPartB)
            {
                return GetTreesCount(grid, 3, 1);
            }

            long runningProduct = 1;
            runningProduct *= GetTreesCount(grid, 1, 1);
            runningProduct *= GetTreesCount(grid, 3, 1);
            runningProduct *= GetTreesCount(grid, 5, 1);
            runningProduct *= GetTreesCount(grid, 7, 1);
            runningProduct *= GetTreesCount(grid, 1, 2);

            return runningProduct;
        }

        private char[,] FixInput(string input)
        {
            int maxRow = input.Split('\n').Length;
            int maxCol = input.Split('\n')[0].Length - 1;
            char[,] grid = new char[maxRow,maxCol];
            for(int r = 0; r < maxRow; r++)
            {
                for(int c = 0; c < maxCol; c++)
                {
                    grid[r,c] = input.Split('\n')[r][c];
                }
            }

            return grid;
        }

        private long GetTreesCount(char[,] grid, int slopeRight, int slopeDown)
        {
            var row = 0;
            var col = 0;
            var totalRows = grid.GetLongLength(0);
            var treesFound = 0;
            while(row < totalRows)
            {
                if (SpotHasTree(grid, row, col))
                {
                    treesFound++;
                }
                row += slopeDown;
                col += slopeRight;
            }

            return treesFound;
        }

        private bool SpotHasTree(char[,] grid, int row, int col)
        {
            row = row % grid.GetLength(0);
            col = col % grid.GetLength(1);
            return grid[row, col] == '#';
        }
    }
}

using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 20
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day20 : IDay<long>
    {
        string puzzleWithoutGaps;

        public long Solve(string input, bool IsPartB = false)
        {
            var Tiles = ReadInput(input);

            // NOW, do the solve.
            return DoThePuzzle(Tiles);
        }

        public List<Tile> ReadInput(string input)
        { 
            // Let's try brute forcing it; it might be fast enough.
            // There's 8 valid combinations.

            var lines = Parser.TokenizeLines(input);
            int currTileId = -1;
            string currTileData = "";
            var Tiles = new List<Tile>();

            foreach (var line in lines)
            {
                if (line.StartsWith("Tile"))
                {
                    if (currTileData != "")
                    {
                        Tiles.Add(new Tile(currTileId, currTileData));
                        currTileData = "";
                    }
                    currTileId = int.Parse(line.Split(' ')[1].Split(':')[0]);
                }
                else
                {
                    currTileData += line.Trim() + "\n";
                }
            }

            if (currTileData != "")
            {
                Tiles.Add(new Tile(currTileId, currTileData));
            }

            return Tiles;
        }

        private long DoThePuzzle(List<Tile> Tiles)
        {
            // We're making a square.
            // We know how many tiles we have, so we know how big the square should be (the dimensions).
            int puzzleSide = (int)Math.Sqrt(Tiles.Count);
            Tile[,] Puzzle = new Tile[puzzleSide, puzzleSide];

            // Let's check if it's Possible to continue with the current configuration.
            // This means, for any current Puzzle, rotate each piece until we find a piece that fits in the next spot
            //   (fits with the piece Above and to the Left).
            // If we don't find a match, we exit that branch (we stop looking in taht branch).

            // We have to maintain the current puzzle state (2D array of Tiles) and the list of available tiles.

            // Again, all we want to know is if it's Possible to place a tile.
            // If we CAN place a tile, and there's no available tiles left, we return the magic number (the product of the 4 corners).

            var TilesAvailable = new List<Tile>();
            TilesAvailable.AddRange(Tiles);

            var FinalPuzzle = new Tile[puzzleSide, puzzleSide];
            long MagicNumber;

            // Ugly, but it should work.
            // Spin each tile, and place it in the top left corner of an empty board, THEN check if it's possible.
            foreach(var tile in Tiles)
            {
                for(int rot = 0; rot < 8; rot++)
                {
                    Puzzle[0, 0] = (Tile)tile.Clone();
                    TilesAvailable = Tiles.Where(x => x.TileId != tile.TileId).ToList();
                    var result = CanPlaceAPiece(Puzzle, TilesAvailable, puzzleSide, out MagicNumber, out FinalPuzzle);

                    if (result)
                    {
                        return MagicNumber;
                    }

                    tile.NextOrientation();
                }
            }
            
            throw new ApplicationException("The puzzle is impossible!");
        }

        public string RemoveGaps(string puzzleInput)
        {
            Solve(puzzleInput);
            return this.puzzleWithoutGaps;
        }

        public string GetFirstTile(string puzzleInput)
        {
            var tiles = this.ReadInput(puzzleInput);
            return tiles[0].PrintTile();
        }

        private bool CanPlaceAPiece(Tile[,] Puzzle, List<Tile> TilesAvailable, int puzzleSide, out long MagicNumber, out Tile[,] FinalPuzzle)
        {
            MagicNumber = -1;
            FinalPuzzle = null;

            // Go through every tile in TilesAvailable, and try putting one in the first available spot (first by Row, then by Col).
            // Skip tiles that can't be placed there.

            // First, find the target row / col.  This is where we're putting the next piece.
            int row = 0;
            int col = 0;
            while(Puzzle[row,col] != null)
            {
                row++;
                if (row >= puzzleSide)
                {
                    row = 0;
                    col++;
                }
            }

            foreach (var tileIterator in TilesAvailable)
            {
                var tile = (Tile)tileIterator.Clone();
                if (col > 0 && !tile.PossibleSides.Contains(Tile.GetInverse(Puzzle[row, col - 1].Sides[1]))) continue;
                if (row > 0 && !tile.PossibleSides.Contains(Tile.GetInverse(Puzzle[row - 1, col].Sides[2]))) continue;

                // Spin it around until it fits.  (IF it fits).
                // It might fit in multiple ways, so be sure to check for that.
                for(int spin = 0; spin < 8; spin++)
                {
                    tile.NextOrientation();

                    if (col > 0 && tile.Sides[3] != Tile.GetInverse(Puzzle[row, col - 1].Sides[1])) continue;
                    if (row > 0 && tile.Sides[0] != Tile.GetInverse(Puzzle[row - 1, col].Sides[2])) continue;

                    // Now, see if the remaining tiles can fit, too.
                    var newTilesAvailable = new List<Tile>();
                    newTilesAvailable.AddRange(TilesAvailable.Where(x => x.TileId != tile.TileId));

                    if (newTilesAvailable.Count == 0)
                    {
                        // We added all pieces!  Let's return the final solution.
                        Puzzle[row, col] = (Tile)tile.Clone();
                        MagicNumber = (long)Puzzle[0, 0].TileId
                            * (long)Puzzle[puzzleSide - 1, 0].TileId
                            * (long)Puzzle[puzzleSide - 1, puzzleSide - 1].TileId 
                            * (long)Puzzle[0, puzzleSide - 1].TileId;
                        FinalPuzzle = Puzzle;
                        return true;
                    }

                    var newPuzzle = new Tile[puzzleSide, puzzleSide];
                    for (int r = 0; r < puzzleSide; r++)
                    {
                        for (int c = 0; c < puzzleSide; c++)
                        {
                            if (Puzzle[r, c] != null)
                            {
                                newPuzzle[r, c] = (Tile)Puzzle[r, c].Clone();
                            }
                        }
                    }
                    newPuzzle[row, col] = (Tile)tile.Clone();
                    Tile[,] newFinalPuzzle;

                    var result = CanPlaceAPiece(newPuzzle, newTilesAvailable, puzzleSide, out long newMagicNumber, out newFinalPuzzle);
                    if (result)
                    {
                        MagicNumber = newMagicNumber;
                        FinalPuzzle = newFinalPuzzle;
                        this.puzzleWithoutGaps = "!";
                        return true;
                    }

                    // We didn't fit.
                }
            }

            // If we got this far, we didn't find any matches.  Jump out  :(
            MagicNumber = -1;
            return false;
        }

        private long DoThePuzzle_OLD(List<Tile> Tiles)
        {
            // ... Revisiting after a couple months.
            // I think we're going down the wrong path.  Shelving this implementation.

            // We're making a square.
            // We know how many tiles we have, so we know how big the square should be (the dimensions).
            int puzzleSide = (int)Math.Sqrt(Tiles.Count);
            Tile[,] Puzzle = new Tile[puzzleSide, puzzleSide];

            // Track which pieces have been placed in the puzzle so far.
            Dictionary<int, bool> PiecesUsed = new Dictionary<int, bool>();
            foreach(var tile in Tiles)
            {
                PiecesUsed.Add(tile.TileId, false);
            }

            // Let's code one pass.
            // Put the first piece at 0,0.
            Puzzle[0, 0] = Tiles[0];
            PiecesUsed[Tiles[0].TileId] = true;

            // What spot are we trying to place?
            // Put this in a loop.
            int row = 0;
            int col = 1;
            var foundMatch = false;
            foreach(var tile in Tiles)
            {
                // Check if the piece was already used.
                if (PiecesUsed[tile.TileId]) continue;

                // Check if this piece can't fit, no matter how it's oriented.
                if (col > 0 && !tile.PossibleSides.Contains(Tile.GetInverse(Puzzle[row, col - 1].Sides[1]))) continue;
                if (row > 0 && !tile.PossibleSides.Contains(Tile.GetInverse(Puzzle[row - 1, col].Sides[2]))) continue;

                // Put this piece into the puzzle.
                if (col > 0)
                {
                    while (tile.Sides[3] != Tile.GetInverse(Puzzle[row, col - 1].Sides[1]))
                    {
                        tile.NextOrientation();
                    }
                }
                if (row > 0)
                {
                    while (tile.Sides[0] != Tile.GetInverse(Puzzle[row - 1, col].Sides[2]))
                    {
                        tile.NextOrientation();
                    }
                }

                // Jump out if the piece doesn't fit, even after rotating it.
                if (col > 0 && tile.Sides[3] != Tile.GetInverse(Puzzle[row, col - 1].Sides[1]))
                {
                    continue;
                }
                if (row > 0 && tile.Sides[0] != Tile.GetInverse(Puzzle[row - 1, col].Sides[2]))
                {
                    continue;
                }

                Puzzle[row, col] = tile;
                PiecesUsed[tile.TileId] = true;
                foundMatch = true;
            }
            
            if (!foundMatch)
            {
                // Piece at [0,0] is wrong, so remove it.
                Puzzle[0, 0] = null;
            }
            



            return -1;
        }

        /// <summary>
        /// Represents a tile (or, specifically, the outside border).
        /// </summary>
        public class Tile : ICloneable
        {
            // Sides' is an array of 4 integers for the 4 sides, representing the 'value' of the side.
            // (The sides are represented as a binary number from 0 to 1023.)
            // Tiles can be rotated and flipped, which gives 8 orientations.
            // Tiles match when one side of a tile matches the side of another tile, remembering to reverse the 
            // binary representation of the tile when comparing.
            // (For example, 0 matches 0; 1 matches 512; 1023 matches 1023; .... not sure of the shortcut for finding matches yet.)
            public int[] Sides { get; private set; }
            public int TileId { get; set; }

            /// <summary>
            /// Value from 0 to 7 representing its orientation.
            /// </summary>
            public int Orientation { get; private set; }

            protected string _tileInfo;

            public Tile(int tileId, string tileInfo)
            {
                TileId = tileId;
                _tileInfo = tileInfo.Replace("\r\n", "!").Replace("\n", "!").Replace("!", "\r\n");

                // Sides are read clockwise; top side first.
                int iSide0 = GetSideFromString(tileInfo.Split('\n')[0].Trim());
                int iSide2 = GetInverse(GetSideFromString(tileInfo.Split('\n')[9].Trim()));

                var strSide1 = "";
                var strSide3 = "";
                foreach(var rawRow in tileInfo.Split('\n'))
                {
                    if (string.IsNullOrWhiteSpace(rawRow)) continue;
                    var row = rawRow.Trim();
                    strSide3 += row[0];
                    strSide1 += row[9];
                }

                int iSide1 = GetSideFromString(strSide1);
                int iSide3 = GetInverse(GetSideFromString(strSide3));

                Sides = new int[4] { iSide0, iSide1, iSide2, iSide3 };
            }

            public void NextOrientation()
            {
                Rotate();
                if (Orientation == 0 || Orientation == 4)
                {
                    Flip();
                }
            }


            /// <summary>
            /// Set the tile to its default orientation (0).
            /// </summary>
            public void Reset()
            {
                if (Orientation >= 4)
                {
                    Flip();
                }

                while (Orientation != 0)
                {
                    NextOrientation();
                }
            }

            private int GetSideFromString(string sideInfo)
            {
                var binaryString = sideInfo.Replace('.', '0').Replace('#', '1');
                var sideValue = Convert.ToInt32(binaryString, 2);
                return sideValue;
            }


            private int[] _possibleSides = null;
            public int[] PossibleSides
            {
                get
                {
                    if (_possibleSides == null)
                    {
                        _possibleSides = new int[8] { Sides[0], Sides[1], Sides[2], Sides[3], 0, 0, 0, 0 };
                        this.Flip();
                        _possibleSides[4] = Sides[0];
                        _possibleSides[5] = Sides[1];
                        _possibleSides[6] = Sides[2];
                        _possibleSides[7] = Sides[3];
                        this.Flip();
                    }
                    return _possibleSides;
                }
            }

            public void Rotate()
            {
                Sides = new int[4] { Sides[1], Sides[2], Sides[3], Sides[0] };
                var newOrientation = -1;
                switch(Orientation)
                {
                    case 3:
                        newOrientation = 0;
                        break;
                    case 7:
                        newOrientation = 4;
                        break;
                    default:
                        newOrientation = Orientation + 1;
                        break;
                }
                Orientation = newOrientation;
            }

            public void Flip()
            {
                Sides = new int[4] { GetInverse(Sides[0]), GetInverse(Sides[3]), GetInverse(Sides[2]), GetInverse(Sides[1]) };
                Orientation = (Orientation >= 4 ? Orientation - 4 : Orientation + 4);
            }

            public static int GetInverse(int input)
            {
                var binary = Convert.ToString(input + 1024, 2);
                var charArray = binary.ToCharArray();
                Array.Reverse(charArray);
                var reverse = new string(charArray);
                var converted = Convert.ToInt32(reverse, 2);
                converted = (converted - 1) / 2;
                return converted;
            }

            public override string ToString()
            {
                return $"{TileId} [{Orientation}]: ({Sides[0]}, {Sides[1]}, {Sides[2]}, {Sides[3]}); All sides: ({PossibleSides[0]}, {PossibleSides[1]}, {PossibleSides[2]}, {PossibleSides[3]}, {PossibleSides[4]}, {PossibleSides[5]}, {PossibleSides[6]}, {PossibleSides[7]})";
            }

            public object Clone()
            {
                var newTile = new Tile(this.TileId, this._tileInfo);
                newTile._possibleSides = this._possibleSides;
                while(newTile.Orientation != this.Orientation)
                {
                    newTile.NextOrientation();
                }
                return newTile;
            }

            public string PrintShortTile()
            {
                var top = BinToStr(this.Sides[0]);
                var left = GetInverse(this.Sides[3]);
                var right = this.Sides[1];
                var result = "";

                left %= 512;
                right %= 512;

                result += top + Environment.NewLine;
                for(int i = 256; i > 1; i /= 2)
                {
                    result += $"{(left > i ? '#' : '.')}  {(i == 32 ? this.TileId.ToString() : i == 16 ? $" [{this.Orientation}]" : "    ")}  {(right > i ? '#' : '.')}{Environment.NewLine}";
                    left %= i;
                    right %= i;
                }

                var bottom = BinToStr(GetInverse(this.Sides[2]));
                result += bottom + Environment.NewLine;
                return result;
            }

            public string PrintTile()
            {
                // NOTE: Doesn't handle rotations or flips.
                return this._tileInfo;
            }

            public string BinToStr(int value)
            {
                var result = "";
                while(value > 0)
                {
                    if (value % 2 == 1)
                    {
                        result = "#" + result;
                    }
                    else
                    {
                        result = "." + result;
                    }
                    value /= 2;
                }

                return result.PadLeft(10, '.');
            }
        }
    }
}

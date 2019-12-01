using System;
using System.Collections.Generic;
using System.Linq;

namespace RMays.Aoc2018
{
    public class Day13
    {
        public class Cart
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public Path DirectionFacing { get; set; }
            public bool IsCrashed { get; set; }
            public int nextCartTurn = 0; // 0 = left, 1 = straight, 2 = right
            public int CartId { get; set; }

            public Cart()
            {
                IsCrashed = false;
                nextCartTurn = 0;
                // Everything else needs to be set explicitly.
            }

            public void TurnAround()
            {
                switch (DirectionFacing)
                {
                    case Path.North:
                        DirectionFacing = Path.South;
                        break;
                    case Path.South:
                        DirectionFacing = Path.North;
                        break;
                    case Path.East:
                        DirectionFacing = Path.West;
                        break;
                    case Path.West:
                        DirectionFacing = Path.East;
                        break;
                }
            }

            public void TurnLeft()
            {
                switch (DirectionFacing)
                {
                    case Path.North:
                        DirectionFacing = Path.West;
                        break;
                    case Path.South:
                        DirectionFacing = Path.East;
                        break;
                    case Path.East:
                        DirectionFacing = Path.North;
                        break;
                    case Path.West:
                        DirectionFacing = Path.South;
                        break;
                }
            }

            public void TurnRight()
            {
                switch (DirectionFacing)
                {
                    case Path.North:
                        DirectionFacing = Path.East;
                        break;
                    case Path.South:
                        DirectionFacing = Path.West;
                        break;
                    case Path.East:
                        DirectionFacing = Path.South;
                        break;
                    case Path.West:
                        DirectionFacing = Path.North;
                        break;
                }
            }

            public void TurnAtIntersection()
            {
                switch (nextCartTurn)
                {
                    case 0: // left
                        TurnLeft();
                        break;
                    case 1: // straight
                        // do nothing!
                        break;
                    case 2: // right
                        TurnRight();
                        break;
                }

                nextCartTurn++;
                nextCartTurn %= 3;
            }
        }

        public class Grid
        {
            protected Path[,] pathGrid { get; set; }
            public int Rows { get; set; }
            public int Cols { get; set; }
            public List<Cart> Carts { get; set; }
            public List<string> Crashes { get; set; }

            public Grid(string input)
            {
                int numRows;
                int numCols;
                var charGrid = GetCharGridFromInput(input, out numRows, out numCols);
                Rows = numRows;
                Cols = numCols;
                InitializePathGrid(charGrid);
                Crashes = new List<string>();
            }

            public void PrettyPrint()
            {
                for(var row = 0; row < Rows; row++)
                {
                    for(var col = 0; col < Cols; col++)
                    {
                        var cart = Carts.Where(x => x.Row == row && x.Col == col).FirstOrDefault();
                        if (cart != null)
                        {
                            if (cart.IsCrashed)
                            {
                                Console.Write("X");
                            }
                            else
                            {
                                switch (cart.DirectionFacing)
                                {
                                    case Path.North:
                                        Console.Write("^");
                                        break;
                                    case Path.South:
                                        Console.Write("v");
                                        break;
                                    case Path.East:
                                        Console.Write(">");
                                        break;
                                    case Path.West:
                                        Console.Write("<");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            switch(pathGrid[row,col])
                            {
                                case Path.All:
                                    Console.Write("+");
                                    break;
                                case Path.EastWest:
                                    Console.Write("-");
                                    break;
                                case Path.NorthSouth:
                                    Console.Write("|");
                                    break;
                                case Path.NorthEast:
                                    Console.Write("\\");
                                    break;
                                case Path.NorthWest:
                                    Console.Write("/");
                                    break;
                                case Path.SouthEast:
                                    Console.Write("/");
                                    break;
                                case Path.SouthWest:
                                    Console.Write("\\");
                                    break;
                                case Path.None:
                                    Console.Write(" ");
                                    break;
                            }
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            public char[,] GetCharGridFromInput(string input, out int numRows, out int numCols)
            {
                var lines = input.Split(new char[] { '\r', '\n' }).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x).ToList();
                // Turn the lines into a grid of characters.
                numRows = lines.Count;
                numCols = lines[0].Length;

                var grid = new char[numRows, numCols];

                var row = 0;
                foreach (var line in lines)
                {
                    var col = 0;
                    foreach (var cell in line.ToCharArray())
                    {
                        grid[row, col] = cell;
                        col++;
                    }
                    row++;
                }

                return grid;
            }

            private void InitializePathGrid(char[,] charGrid)
            {
                int currCartId = 0;
                Carts = new List<Cart>();
                pathGrid = new Path[Rows, Cols];
                var cartChars = new Dictionary<char, Path>();
                cartChars.Add('^', Path.North);
                cartChars.Add('v', Path.South);
                cartChars.Add('>', Path.East);
                cartChars.Add('<', Path.West);
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Cols; col++)
                    {
                        var currChar = charGrid[row, col];
                        if (cartChars.Keys.Contains(currChar))
                        {
                            Carts.Add(new Cart
                            {
                                CartId = currCartId,
                                Row = row,
                                Col = col,
                                DirectionFacing = cartChars[currChar],
                                IsCrashed = false
                            });
                            currCartId++;
                        }

                        pathGrid[row, col] = GetPathValue(currChar);
                    }
                }

                // Now, fix the unknowns.
                for (int row = 0; row < Rows; row++)
                {
                    for (int col = 0; col < Cols; col++)
                    {
                        var currPathCell = pathGrid[row, col];
                        if ((currPathCell & Path.Unknown) == Path.Unknown)
                        {
                            if (currPathCell == Path.NEorSW)
                            {
                                if (row == 0 || col == Cols - 1)
                                {
                                    pathGrid[row, col] = Path.SouthWest;
                                    continue;
                                }
                                if (col == 0 || row == Rows - 1)
                                {
                                    pathGrid[row, col] = Path.NorthEast;
                                    continue;
                                }
                                if (pathGrid[row + 1, col] == Path.NorthSouth || pathGrid[row + 1, col] == Path.All ||
                                    pathGrid[row, col - 1] == Path.EastWest || pathGrid[row, col - 1] == Path.All)
                                {
                                    pathGrid[row, col] = Path.SouthWest;
                                    continue;
                                }
                                if (pathGrid[row - 1, col] == Path.NorthSouth || pathGrid[row - 1, col] == Path.All ||
                                    pathGrid[row, col + 1] == Path.EastWest || pathGrid[row, col + 1] == Path.All)
                                {
                                    pathGrid[row, col] = Path.NorthEast;
                                    continue;
                                }
                                throw new ApplicationException($"Couldn't decode this ambiguous track.  Cell: {row},{col}");
                            }
                            else if (currPathCell == Path.NWorSE)
                            {
                                if (row == 0 || col == 0)
                                {
                                    pathGrid[row, col] = Path.SouthEast;
                                    continue;
                                }
                                if (col == Cols - 1 || row == Rows - 1)
                                {
                                    pathGrid[row, col] = Path.NorthWest;
                                    continue;
                                }
                                if (pathGrid[row + 1, col] == Path.NorthSouth || pathGrid[row + 1, col] == Path.All ||
                                    pathGrid[row, col + 1] == Path.EastWest || pathGrid[row, col + 1] == Path.All)
                                {
                                    pathGrid[row, col] = Path.SouthEast;
                                    continue;
                                }
                                if (pathGrid[row - 1, col] == Path.NorthSouth || pathGrid[row - 1, col] == Path.All ||
                                    pathGrid[row, col - 1] == Path.EastWest || pathGrid[row, col - 1] == Path.All)
                                {
                                    pathGrid[row, col] = Path.NorthWest;
                                    continue;
                                }
                                throw new ApplicationException($"Couldn't decode this ambiguous track.  Cell: {row},{col}");
                            }
                            else
                            {
                                throw new ApplicationException($"Couldn't decode this ambiguous track.  Cell: {row},{col}");
                            }
                        }
                    }
                }
            }

            private Path GetPathValue(char gridCell)
            {
                Path path = Path.None;
                switch(gridCell)
                {
                    case ' ':
                        path = Path.None;
                        break;
                    case '/':
                        path = Path.NWorSE;
                        break;
                    case '\\':
                        path = Path.NEorSW;
                        break;
                    case '|':
                        path = Path.NorthSouth;
                        break;
                    case '-':
                        path = Path.EastWest;
                        break;
                    case '+':
                        path = Path.All;
                        break;
                    case '>':
                        path = Path.EastWest;
                        break;
                    case '<':
                        path = Path.EastWest;
                        break;
                    case '^':
                        path = Path.NorthSouth;
                        break;
                    case 'v':
                        path = Path.NorthSouth;
                        break;
                    default:
                        throw new ApplicationException($"Invalid character: {gridCell}");
                }
                return path;
            }

            /// <summary>
            /// Run 1 tick.
            /// Each cart moves forward 1 spot, following the turning rules (Left, Straight, Right) at each intersection.
            /// Carts move in order from top to bottom, left to right.
            /// </summary>
            public void ProcessTick()
            {
                // Get all the carts, in order from top to bottom, left to right.
                foreach (var cart in Carts.Where(x => !x.IsCrashed).OrderBy(x => x.Row).ThenBy(x => x.Col))
                {
                    switch (cart.DirectionFacing)
                    {
                        case Path.North:
                            cart.Row--;
                            break;
                        case Path.South:
                            cart.Row++;
                            break;
                        case Path.East:
                            cart.Col++;
                            break;
                        case Path.West:
                            cart.Col--;
                            break;
                    }

                    // Did we collide with anyone?
                    foreach (var secondCart in Carts.Where(x => x.CartId != cart.CartId))
                    {
                        if (secondCart.IsCrashed) continue;
                        if (cart.Row == secondCart.Row && cart.Col == secondCart.Col)
                        {
                            cart.IsCrashed = true;
                            secondCart.IsCrashed = true;
                            //Crashes.Add($"Carts {cart.CartId} and {secondCart.CartId} crashed at {cart.Row},{cart.Col}.");
                            Crashes.Add($"{cart.Col},{cart.Row}");
                        }
                    }

                    // What direction are we facing now?
                    var spot = pathGrid[cart.Row, cart.Col];
                    if (spot == Path.All)
                    {
                        cart.TurnAtIntersection();
                    }
                    else
                    { 
                        // If on straightaway, don't change directions.
                        if (spot != Path.NorthSouth && spot != Path.EastWest)
                        {
                            cart.DirectionFacing = (Path)((spot ^ Path.All) - cart.DirectionFacing);
                            cart.TurnAround();
                        }
                    }
                }
            }
        }

        [Flags]
        public enum Path
        {
            None = 0,

            North = 1,
            South = 2,
            East = 4,
            West = 8,

            NorthSouth = 3, //   |
            NorthEast = 5,  //   \
            NorthWest = 9,  //   /
            SouthEast = 6,  //   /
            SouthWest = 10, //   \
            EastWest = 12,  //   -
            All = 15,       //   +

            Unknown = 16,
            NEorSW = 17,   //   \
            NWorSE = 18    //   /
        }

        public string SolveA(string input)
        {
            var myGrid = new Grid(input);
            //myGrid.PrettyPrint();
            while (myGrid.Carts.Count(x => x.IsCrashed) == 0)
            {
                myGrid.ProcessTick();
                //myGrid.PrettyPrint();
            }

            return myGrid.Crashes.First();
        }

        public string SolveB(string input)
        {
            var myGrid = new Grid(input);
            while (myGrid.Carts.Count(x => !x.IsCrashed) != 1)
            {
                myGrid.ProcessTick();
            }

            var cart = myGrid.Carts.Where(x => !x.IsCrashed).First();

            return $"{cart.Col},{cart.Row}";
        }
    }
}

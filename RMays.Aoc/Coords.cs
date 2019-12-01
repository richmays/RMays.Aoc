using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc
{
    public class Coords : IEquatable<Coords>, IComparable<Coords>, ICloneable
    {
        public Coords()
        {
        }

        public Coords(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override string ToString()
        {
            return $"{Row}, {Col}";
        }

        public int Row { get; set; }
        public int Col { get; set; }

        public Coords Up()
        {
            return new Coords(Row - 1, Col);
        }
        public Coords Down()
        {
            return new Coords(Row + 1, Col);
        }
        public Coords Left()
        {
            return new Coords(Row, Col - 1);
        }
        public Coords Right()
        {
            return new Coords(Row, Col + 1);
        }

        public bool Equals(Coords other)
        {
            return this.Row == other.Row && this.Col == other.Col;
        }

        public int CompareTo(Coords other)
        {
            if (this.Row < other.Row) return -1;
            if (this.Col < other.Col) return -1;
            if (this.Row > other.Row) return 1;
            if (this.Col > other.Col) return 1;
            return 0;
        }

        public object Clone()
        {
            return new Coords(this.Row, this.Col);
        }
    }
}

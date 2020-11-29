using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    public abstract class DayBase<T> : IDay<T>
    {
        public virtual T SolveA(string input)
        {
            throw new NotImplementedException();
        }

        public virtual T SolveB(string input)
        {
            throw new NotImplementedException();
        }

        public virtual T Solve(string input, bool isPartB)
        {
            throw new NotImplementedException();
        }
    }
}

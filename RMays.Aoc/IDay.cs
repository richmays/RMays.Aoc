using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc
{
    public interface IDay<T>
    {
        T Solve(string input, bool isPartB = false);
    }
}

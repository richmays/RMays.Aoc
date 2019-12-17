using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day9 : DayBase<long>
    {
        public long SolveA(string input)
        {
            var Compy = new IntcodeComp(input);
            Compy.Initialize();
            Compy.InjectInput(1);
            var results = Compy.Run9();
            return results[0];
        }

        public List<long> Solve(string input)
        {
            var Compy = new IntcodeComp(input);
            Compy.Initialize();
            var result = Compy.Run9();
            return Compy.Outputs;
        }

        public long SolveB(string input)
        {
            var Compy = new IntcodeComp(input);
            Compy.Initialize();
            Compy.InjectInput(2);
            var results = Compy.Run9();
            return results[0];
        }
    }
}

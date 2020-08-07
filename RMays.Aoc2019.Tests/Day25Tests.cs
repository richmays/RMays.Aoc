using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019.Tests
{
    [TestFixture]
    public class Day25Tests
    {
        private string inputData = InputData.Day25;
        private string knownOutputA = "1077936448";
        private string knownOutputB = "456";

        private IDay<long> GetDayObject()
        {
            return new Day25();
        }

        // Unit tests can't easily be used for this day.
    }
}

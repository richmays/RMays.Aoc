using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc
{
    public class Parser
    {
        public static List<string> Tokenize(string input, char splitter)
        {
            return input.Split(splitter).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();
        }

        public static List<string> Tokenize(string input)
        {
            return input.Split(new char[] { ',', '\r', '\n' }).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();
        }

        public static List<string> TokenizeLines(string input)
        {
            return input.Split(new char[] { '\r', '\n' }).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();
        }
    }
}

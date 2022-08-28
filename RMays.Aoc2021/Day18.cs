using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021
{
    #region Day 0
    /*
--- Day 0: Template ---

    */
    #endregion

    public class Day18 : IDay<long>
    {
        internal class SNum
        {
            public bool IsRegular { get; set; } = true;
            public SNum Item1 { get; set; }
            public SNum Item2 { get; set; }
            public SNum Parent { get; private set; } = null;
            public int NumValue { get; set; }

            public int GetMagnitude() {
                if (IsRegular) return NumValue;
                return 3 * Item1.GetMagnitude() + 2 * Item2.GetMagnitude();
            }

            public SNum() : this(0)
            {
            }

            public SNum(int num1)
            {
                IsRegular = true;
                NumValue = num1;
            }

            public SNum(int num1, int num2)
            {
                IsRegular = false;
                Item1 = new SNum(num1);
                Item1.Parent = this;
                Item2 = new SNum(num2);
                Item2.Parent = this;
            }

            public SNum(int num1, SNum item2)
            {
                IsRegular = false;
                Item1 = new SNum(num1);
                Item1.Parent = this;
                Item2 = item2;
            }

            public SNum(SNum item1, int num2)
            {
                IsRegular = false;
                Item1 = item1;
                Item2 = new SNum(num2);
                Item2.Parent = this;
            }

            public SNum(SNum item1, SNum item2)
            {
                IsRegular = false;
                Item1 = item1;
                Item1.Parent = this;
                Item2 = item2;
                Item2.Parent = this;
            }

            public static SNum Add(SNum snum1, SNum snum2)
            {
                var result = new SNum(snum1, snum2);
                result.Item1.Parent = result;
                result.Item2.Parent = result;
                result = SNum.Reduce(result);
                return result;
            }

            private static SNum Reduce(SNum snum)
            {
                // Do 0 or 1 of the following, then reduce again.
                //   Explode:
                //     If any pair is nested inside four pairs, the leftmost such pair explodes.
                //   Split:
                //     If any regular number is 10 or greater, the leftmost such regular number splits.

                SNum result = snum;
                bool done = false;
                while (!done)
                {
                    done = true;
                    if (result.GetMaxDepth() >= 5)
                    {
                        result = SNum.Explode(result);
                        done = false;
                        continue;
                    }

                    var didSplit = SNum.TrySplit(result, out result);
                    if (didSplit)
                    {
                        done = false;
                    }
                }

                /*




                if (snum.GetMaxDepth() < 5) return snum;

                SNum result = snum;
                var didSplit = false;
                do
                {

                    do
                    {
                        result = SNum.Explode(result);
                    }
                    while (result.GetMaxDepth() >= 5);

                    didSplit = SNum.TrySplit(result, out result);
                }
                while (didSplit);
                */

                return result;
            }

            private static SNum Explode(SNum snum)
            {
                string raw = snum.ToString();
                int depth = 0;
                bool reading = false;
                bool doneReading = false;
                var result = new StringBuilder();
                var cIndex = -1;
                var nodeStartIndex = 0;
                foreach (var c in raw.ToCharArray())
                {
                    cIndex++;
                    if (reading)
                    {
                        result.Append(c);
                    }
                    if (c == '[')
                    {
                        depth++;
                        if (depth == 5)
                        {
                            // Inside the deep node; let's figure out what it is.
                            // Turn on 'read' mode.
                            if (!doneReading)
                            {
                                reading = true;
                                nodeStartIndex = cIndex;
                                result.Append('[');
                            }
                        }
                    }
                    else if (c == ']')
                    {
                        depth--;
                        if (reading)
                        {
                            reading = false;
                            doneReading = true;
                        }
                    }
                }

                var nodeEndIndex = nodeStartIndex + result.Length - 1;
                //Console.WriteLine($"Exploding node: {result} (start index: {nodeStartIndex}, end index: {nodeEndIndex})");

                var trimResult = result.ToString().Substring(1, result.Length - 2);
                //Console.WriteLine($"Trimmed node: {trimResult}");
                var leftNum = int.Parse(trimResult.Split(',')[0]);
                var rightNum = int.Parse(trimResult.Split(',')[1]);

                // Explode Left
                var c2 = nodeStartIndex - 1;
                while(c2 > 0 && (raw[c2] < '0' || raw[c2] > '9'))
                {
                    c2--;
                }

                if (c2 == 0)
                {
                    // Do nothing!
                }
                else
                {
                    var endReplace = c2;
                    while (raw[c2] >= '0' && raw[c2] <= '9')
                    {
                        c2--;
                    }
                    var startReplace = c2 + 1;
                    // The number is the range from 'startReplace' to 'endReplace' in raw.
                    // Necessary because the actual token (number) could be greater than 9 when exploding.

                    var sourceNum = int.Parse(raw.Substring(startReplace, endReplace - startReplace + 1));
                    var oldRawLength = raw.Length;
                    //Console.WriteLine($"Before exploding left: {raw}");
                    raw = raw.Substring(0, startReplace) + (sourceNum + leftNum).ToString() + raw.Substring(endReplace + 1);
                    //Console.WriteLine($"After exploding left:  {raw}");

                    // Adjust the 'replace' indexes if the raw length changed.
                    // This will change the nodeStartIndex and nodeEndIndexes by 1, 0, or -1.
                    nodeStartIndex = nodeStartIndex - oldRawLength + raw.Length;
                    nodeEndIndex = nodeEndIndex - oldRawLength + raw.Length;
                }

                // Explode Right
                c2 = nodeEndIndex + 1;
                while (c2 < raw.Length && (raw[c2] < '0' || raw[c2] > '9'))
                {
                    c2++;
                }

                if (c2 >= raw.Length)
                {
                    // Do nothing!
                }
                else
                {
                    var startReplace = c2;
                    while (raw[c2] >= '0' && raw[c2] <= '9')
                    {
                        c2++;
                    }
                    var endReplace = c2 - 1;

                    // The number is the range from 'startReplace' to 'endReplace' in raw.
                    // Necessary because the actual token (number) could be greater than 9 when exploding.

                    var sourceNum = int.Parse(raw.Substring(startReplace, endReplace - startReplace + 1));
                    //Console.WriteLine($"Before exploding right: {raw}");
                    raw = raw.Substring(0, startReplace) + (sourceNum + rightNum).ToString() + raw.Substring(endReplace + 1);
                    //Console.WriteLine($"After exploding right:  {raw}");
                }

                // Now, replace the exploded node with 0.
                //Console.WriteLine($"Before exploding: {raw}");
                raw = raw.Substring(0, nodeStartIndex) + "0" + raw.Substring(nodeEndIndex + 1);
                //Console.WriteLine($"After exploding:  {raw}");

                return new SNum(raw);
            }

            private static bool TrySplit(SNum snum, out SNum newSNum)
            {
                string raw = snum.ToString();
                var result = new StringBuilder();
                var cIndex = -1;
                var nodeStartIndex = 0;
                var nodeEndIndex = 0;
                var intNodeValue = 0;
                foreach (var c in raw.ToCharArray())
                {
                    cIndex++;
                    if (c >= '0' && c <= '9')
                    {
                        if (nodeStartIndex == 0)
                        {
                            nodeStartIndex = cIndex;
                        }
                        intNodeValue = intNodeValue * 10 + (c - '0');
                    }
                    else
                    {
                        if (intNodeValue < 10)
                        {
                            // Reset; didn't find a large number.
                            intNodeValue = 0;
                            nodeStartIndex = 0;
                        }
                        else
                        {
                            // Finished reading in a large number!
                            nodeEndIndex = cIndex;
                            break;
                        }
                    }
                }

                if (nodeStartIndex == 0)
                {
                    // No splits; jump out.
                    newSNum = snum;
                    return false;
                }

                // Figure out the value of the new node to insert.
                var newNode = $"[{intNodeValue / 2},{(intNodeValue + 1) / 2}]";

                // Split the node we just found.
                //Console.WriteLine($"Start: {nodeStartIndex}, End: {nodeEndIndex}, intNodeValue: {intNodeValue}");
                //Console.WriteLine($"Before split:  {raw}");
                raw = raw.Substring(0, nodeStartIndex) + newNode + raw.Substring(nodeEndIndex);
                //Console.WriteLine($"After split:   {raw}");

                newSNum = new SNum(raw);
                return true;
            }

            private List<string> TokenizeSNum()
            {
                var result = new List<string>();
                var currInt = 0;
                var readingNum = false;
                foreach (var c in this.ToString().ToCharArray())
                {
                    if (c == '[')
                    {
                        result.Add("[");
                    }
                    else if (c == ']')
                    {
                        if (readingNum)
                        {
                            result.Add(currInt.ToString());
                            currInt = 0;
                            readingNum = false;
                        }
                        result.Add("]");
                    }
                    else if (c == ',')
                    {
                        if (readingNum)
                        {
                            result.Add(currInt.ToString());
                            currInt = 0;
                            readingNum = false;
                        }
                        result.Add(",");
                    }
                    else
                    {
                        readingNum = true;
                        currInt = 10 * currInt + (c - '0');
                    }
                }

                return result;
            }

            private int GetMaxDepth()
            {
                if (IsRegular)
                {
                    return 0;
                }
                return 1 + Math.Max(Item1.GetMaxDepth(), Item2.GetMaxDepth());
            }

            private SNum GetFirstDepthXNode(int depth)
            {
                if (this.IsRegular)
                {
                    return this.Parent;
                }
                else if (this.Item1.GetMaxDepth() == depth - 1)
                {
                    // Found it; let's dig deeper.
                    return this.Item1.GetFirstDepthXNode(depth - 1);
                }
                else
                {
                    // It's in Item2 instead.
                    return this.Item2.GetFirstDepthXNode(depth - 1);
                }
            }

            public SNum(string initial)
            {
                // Let's read in a new SNum.
                // This won't work; how do I know how they're related?
                // How do I know which SNum goes with which SNum??
                // I think I need to parse this string as a tree containing nodes with 2 children each.
                // Better idea; we are building up each of the 4 levels of nodes as we go.
                // eg. for [[1,2],3],
                // [  -> 0: SNum(-1,-1), L
                // [  ->                       1: SNum(-1,-1), L
                // 1  ->                       1: SNum(1, -1), R
                // ,  -> (do nothing)
                // 2  ->                       1: SNum(1, 2), R
                // ]  -> 0: SNum(SNum(1,2), -1), R
                // ,  -> (do nothing)
                // 3  -> 0: SNum(SNum(1,2), 3), R
                // ]  -> Return this:  SNum(SNum(1, 2), 3)
                var SNums = new SNum[5];
                var SNumDirs = new char[5];
                var currSnum = -1;
                var currInt = 0;
                var readingNum = false;

                foreach(var c in initial.ToCharArray())
                {
                    if (c == '[')
                    {
                        currSnum++;
                        SNums[currSnum] = new SNum(-1, -1);
                        SNumDirs[currSnum] = 'L';
                    }
                    else if (c == ']')
                    {
                        if (readingNum)
                        {
                            if (SNumDirs[currSnum] == 'L')
                            {
                                SNums[currSnum].Item1 = new SNum(currInt);
                                SNums[currSnum].Item1.Parent = SNums[currSnum];
                                SNumDirs[currSnum] = 'R';
                            }
                            else
                            {
                                SNums[currSnum].Item2 = new SNum(currInt);
                                SNums[currSnum].Item2.Parent = SNums[currSnum];
                            }
                            currInt = 0;
                            readingNum = false;
                        }

                        currSnum--;
                        if (currSnum == -1)
                        {
                            // Done!  Do nothing.
                        }
                        else
                        {
                            if (SNumDirs[currSnum] == 'L')
                            {
                                SNums[currSnum].Item1 = SNums[currSnum + 1];
                                SNums[currSnum].Item1.Parent = SNums[currSnum];
                                SNumDirs[currSnum] = 'R';
                            }
                            else
                            {
                                SNums[currSnum].Item2 = SNums[currSnum + 1];
                                SNums[currSnum].Item2.Parent = SNums[currSnum];
                            }
                        }
                    }
                    else if (c == ',')
                    {
                        if (readingNum)
                        {
                            if (SNumDirs[currSnum] == 'L')
                            {
                                SNums[currSnum].Item1 = new SNum(currInt);
                                SNums[currSnum].Item1.Parent = SNums[currSnum];
                                SNumDirs[currSnum] = 'R';
                            }
                            else
                            {
                                SNums[currSnum].Item2 = new SNum(currInt);
                                SNums[currSnum].Item2.Parent = SNums[currSnum];
                            }
                            currInt = 0;
                            readingNum = false;
                        }
                    }
                    else if (c <= '9' && c >= '0')
                    {
                        readingNum = true;
                        currInt = currInt * 10 + (c - '0');

                        /*
                        if (SNumDirs[currSnum] == 'L')
                        {
                            SNums[currSnum].Item1 = new SNum(c - '0');
                            SNums[currSnum].Item1.Parent = SNums[currSnum];
                        }
                        else
                        {
                            SNums[currSnum].Item2 = new SNum(c - '0');
                            SNums[currSnum].Item2.Parent = SNums[currSnum];
                        }
                        */

                        //SNumDirs[currSnum] = 'R';
                    }

                    //Console.WriteLine($"{c}: {SNums[0]}{SNumDirs[0]} {SNums[1]}{SNumDirs[1]} {SNums[2]}{SNumDirs[2]} {SNums[3]}{SNumDirs[3]}");
                }

                this.IsRegular = false;
                this.Item1 = SNums[0].Item1;
                this.Item2 = SNums[0].Item2;

                //Console.WriteLine(this);
            }

            public override string ToString()
            {
                if (IsRegular)
                {
                    return $"{NumValue}";
                }
                else
                {
                    return $"[{Item1},{Item2}]";
                }
            }
        }

        public long Solve(string input, bool IsPartB = false)
        {
            var lines = Parser.TokenizeLines(input);
            SNum sumSNum = null;
            var SNums = new List<SNum>();
            foreach(var line in lines)
            {
                var snum = new SNum(line);
                if (!IsPartB)
                {
                    if (sumSNum == null)
                    {
                        sumSNum = snum;
                    }
                    else
                    {
                        sumSNum = SNum.Add(sumSNum, snum);
                        //Console.WriteLine($"SUM: {sumSNum}");
                    }
                }
                else
                {
                    SNums.Add(snum);
                }
            }

            if (!IsPartB)
            {
                return sumSNum.GetMagnitude();
            }
            else
            {
                int best = -1;
                for(int x = 0; x < SNums.Count; x++)
                {
                    for(int y = 0; y < SNums.Count; y++)
                    {
                        if (x == y) continue;
                        var result = SNum.Add(SNums[x], SNums[y]).GetMagnitude();
                        if (result > best)
                        {
                            best = result;
                        }
                    }
                }

                return best;
            }
        }
    }
}

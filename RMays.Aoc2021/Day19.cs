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

    public class Day19 : IDay<long>
    {
        internal class Scanner
        {
            public int ScannerId { get; set; }

            /// <summary>
            /// Do we know this scanner's position?
            /// </summary>
            public bool PositionKnown = false;

            /// <summary>
            /// If we know this scanner's position, this is its position.
            /// </summary>
            public (int, int, int) Position;

            /// <summary>
            /// Initial beacon locations
            /// </summary>
            public List<(int, int, int)> OriginalBeacons { get; private set; }

            /// <summary>
            /// Beacon locations after rotating
            /// </summary>
            public List<(int, int, int)> Beacons { get; private set; }

            public override string ToString()
            {
                var result = new StringBuilder();
                result.Append($"Scanner ID {ScannerId} [{Orientation}]:{Environment.NewLine}");
                foreach (var beacon in Beacons)
                {
                    result.Append($" {beacon.Item1},{beacon.Item2},{beacon.Item3}{Environment.NewLine}");
                }
                return result.ToString();
            }

            /// <summary>
            /// Orientation is a number from 0 to 23.
            /// Rotate the scanner to change the relative values of all beacons.
            /// </summary>
            public int Orientation = 0;

            public Scanner(int scannerId, List<(int, int, int)> beacons)
            {
                ScannerId = scannerId;
                OriginalBeacons = beacons;
                Beacons = new List<(int, int, int)>();
                foreach(var beacon in OriginalBeacons)
                {
                    Beacons.Add((beacon.Item1, beacon.Item2, beacon.Item3));
                }
                PositionKnown = false;
                Position = (0, 0, 0);
            }

            /// <summary>
            /// Rotates the scanner; updates the locations of all beacons.
            /// It says there's 24 combinations, .... but it should be (3!) * 2^3, which is .... 6*8 (48)
            /// Tricky!  So half of them are from a mirror-image cube.  Not sure how to detect.
            /// Maybe we don't care?  Let's go through it assuming there's no mirror-images.
            /// 0: x, y, z
            /// 1: -x, y, z
            /// 2: x, -y, z
            /// 3: -x, -y, z
            /// 4: x, y, -z
            /// 5: -x, y, -z
            /// 6: x, -y, -z
            /// 7: -x, -y, -z
            /// 8: y, x, z
            /// 16: x, z, y
            /// 24: z, x, y
            /// 32: y, z, x
            /// 40: z, y, x
            /// Hmm.  Too tricky.
            /// There's only 6 ways to make a single rotation of a cube: x, -x, y, -y, z, -z.
            /// How do we map these??
            /// (1,2,3) -> (-2,1,3) -> (-1,-2,3) -> (2,-1,3)
            /// Rotate Z: (x,y,z) -> (-y,x,z)
            /// Rotate Y: (x,y,z) -> (-z,y,x)
            /// Rotate X: (x,y,z) -> (x,-z,y)
            /// Each of the 3 rotations can be done 0, 1, 2, or 3 times.
            /// So ... that's 24 total combinations!
            /// How do we map each number from 0 to 24 (R) to one of these maps?
            /// Turn the rotation-number (R) into a 3-digit base-4 number.
            /// Rotate X: (R % 3)
            /// Rotate Y: (R / 3) % 3
            /// Rotate Z: (R / 9)
            /// </summary>
            public void Rotate()
            {
                Orientation++;
                if (Orientation >= 24) Orientation = 0;

                Beacons.Clear();
                foreach (var oldBeacon in OriginalBeacons)
                {
                    // Start with (1,2,3)
                    (int, int, int) faces = (oldBeacon.Item1, oldBeacon.Item2, oldBeacon.Item3);

                    switch (Orientation / 4)
                    {
                        case 0:
                            faces = (faces.Item1, faces.Item2, faces.Item3);
                            break;
                        case 1:
                            faces = (-1 * faces.Item1, faces.Item3, faces.Item2);
                            break;
                        case 2:
                            faces = (-1 * faces.Item2, faces.Item1, faces.Item3);
                            break;
                        case 3:
                            faces = (faces.Item2, faces.Item3, faces.Item1);
                            break;
                        case 4:
                            faces = (faces.Item3, faces.Item1, faces.Item2);
                            break;
                        case 5:
                            faces = (-1 * faces.Item3, faces.Item2, faces.Item1);
                            break;
                    }

                    switch (Orientation % 4)
                    {
                        case 0:
                            // Do nothing
                            break;
                        case 1:
                            faces = (faces.Item1, faces.Item2 * -1, faces.Item3 * -1);
                            break;
                        case 2:
                            faces = (faces.Item1 * -1, faces.Item2, faces.Item3 * -1);
                            break;
                        case 3:
                            faces = (faces.Item1 * -1, faces.Item2 * -1, faces.Item3);
                            break;
                    }

                    Beacons.Add(faces);
                }
            }
        }

        public long Solve(string input, bool IsPartB = false)
        {
            var requiredMatches = 12;
            var lines = Parser.TokenizeLines(input);
            var scanners = new List<Scanner>();
            var beacons = new List<(int, int, int)>();
            var scannerId = 0;
            foreach(var line in lines)
            {
                if (line.Length == 0) continue;
                if (line.StartsWith("---"))
                {
                    if (beacons.Any())
                    {
                        scanners.Add(new Scanner(scannerId, beacons));
                        beacons = new List<(int, int, int)>();
                        scannerId = -1;
                    }

                    // Starting a new scanner.
                    scannerId = int.Parse(line.Split(' ')[2]);
                    beacons.Clear();
                }
                else
                {
                    // Turn the string '432,-224,523' into a 3-tuple with those values.
                    beacons.Add((int.Parse(line.Split(',')[0]), int.Parse(line.Split(',')[1]), int.Parse(line.Split(',')[2])));
                }

            }

            // In case the final newline isn't where it should be.
            if (beacons.Any())
            {
                scanners.Add(new Scanner(scannerId, beacons));
            }

            Console.WriteLine($"Found {scanners.Count()} scanners.");
            foreach(var scanner in scanners)
            {
                //Console.WriteLine($"{scanner}");

                /*
                 * Rotation works!
                for (int orientation = 0; orientation <= 25; orientation++)
                {
                    scanner.Rotate();
                }
                */
            }

            // If there's only 2 scanners, we need only 3 beacons to match.
            if (scanners.Count() <= 2)
            {
                requiredMatches = 3;
            }

            // We have some scanners.
            // Set scanner 1's position to (0,0,0).
            scanners[0].PositionKnown = true;
            scanners[0].Position = (0, 0, 0);

            var breaker = false;
            while (!breaker && scanners.Any(x => !x.PositionKnown))
            {
                breaker = true;
                //Console.WriteLine("Not done yet.  Let's try to find more scanner locations.");
                for (var scanner1Id = 0; scanner1Id < scanners.Count - 1; scanner1Id++)
                {
                    for (var scanner2Id = 1; scanner2Id < scanners.Count; scanner2Id++)
                    {
                        if (scanner1Id == scanner2Id) continue;
                        if (scanners[scanner1Id].PositionKnown == scanners[scanner2Id].PositionKnown)
                        {
                            // Skip; they're either both unknown, or both known.
                            // We don't learn anything by seeing if they overlap.
                            //Console.WriteLine($"Skipping scanners {scanner1Id} and {scanner2Id}.  (Both are {(scanners[scanner1Id].PositionKnown ? "known" : "unknown")}.)");
                            continue;
                        }

                        var scanner1 = scanners[scanner1Id];
                        var scanner2 = scanners[scanner2Id];
                        bool matchFound = false;
                        if (scanner1.PositionKnown)
                        {
                            matchFound = ScannerMatch(scanner1, scanner2, requiredMatches);
                        }
                        else
                        {
                            matchFound = ScannerMatch(scanner2, scanner1, requiredMatches);
                        }

                        if (matchFound)
                        {
                            // We found a match, so we should keep going if we havent found matches for every scanner.
                            breaker = false;
                        }
                    }
                }

                //Console.WriteLine("Let's see if we're done...");
            }

            if (breaker)
            {
                // Breaker hit!  We didn't find a match last time we looked.
                Console.WriteLine("Problem; we didn't find a match for all scanners.");
                return -1;
            }

            // Done!
            // Return the number of beacons found.
            var beaconsFound = new List<(int, int, int)>();
            foreach (var scanner in scanners)
            {
                foreach (var beacon in scanner.Beacons)
                {
                    var tmpBeacon = (
                        beacon.Item1 + scanner.Position.Item1,
                        beacon.Item2 + scanner.Position.Item2,
                        beacon.Item3 + scanner.Position.Item3);
                    if (!beaconsFound.Contains(tmpBeacon))
                    {
                        beaconsFound.Add(tmpBeacon);
                    }
                }
            }

            if (!IsPartB)
            {
                return beaconsFound.Count();
            }

            var maxDist = 0;

            // Get the maximum manhattan distance between any 2 scanners.
            for(int i = 0; i < scanners.Count - 1; i++)
            {
                var s1 = scanners[i];
                for(int j = 1; j < scanners.Count; j++)
                {
                    if (i == j) continue;
                    var s2 = scanners[j];

                    var dist =
                        Math.Abs(s1.Position.Item1 - s2.Position.Item1) +
                        Math.Abs(s1.Position.Item2 - s2.Position.Item2) +
                        Math.Abs(s1.Position.Item3 - s2.Position.Item3);
                    if (dist > maxDist)
                    {
                        maxDist = dist;
                    }
                }
            }

            return maxDist;
        }

        /// <summary>
        /// Returns whether or not a match was found between 2 scanners (the first scanner's position is known, the second scanner is not).
        /// </summary>
        /// <param name="scanner1"></param>
        /// <param name="scanner2"></param>
        /// <returns></returns>
        private bool ScannerMatch(Scanner scanner1, Scanner scanner2, int requiredMatches)
        {
            //Console.WriteLine($"Checking for a match between {scanner1.ScannerId} and {scanner2.ScannerId}...");

            // Look for a match, and rotate scanner 2 until we've found a match.
            for (int rotation = 0; rotation < 24; rotation++)
            {
                foreach(var beacon1 in scanner1.Beacons)
                {
                    foreach (var beacon2 in scanner2.Beacons)
                    {
                        // Let's assume these are a match.
                        // If they are, we need 12 total beacons to match up.
                        // IF they match, figure out scanner 2's new position, if scanner 1 is at (0,0,0).
                        var offset = (
                            beacon1.Item1 - beacon2.Item1,
                            beacon1.Item2 - beacon2.Item2,
                            beacon1.Item3 - beacon2.Item3);

                        // Now, find how many beacons match between these two scanners, using this offset.
                        var matches = 0;
                        for (int i = 0; i < scanner2.Beacons.Count; i++)
                        {
                            var b2 = scanner2.Beacons[i];
                            var newBeacon2 = (
                                b2.Item1 + offset.Item1,
                                b2.Item2 + offset.Item2,
                                b2.Item3 + offset.Item3);
                            if (scanner1.Beacons.Contains(newBeacon2))
                            {
                                matches++;
                            }
                        }

                        if (matches >= requiredMatches)
                        {
                            // The scanners match up!
                            //Console.WriteLine($"Found a match between scanners {scanner1.ScannerId} and {scanner2.ScannerId}!");
                            scanner2.PositionKnown = true;
                            scanner2.Position = (
                                scanner1.Position.Item1 + offset.Item1,
                                scanner1.Position.Item2 + offset.Item2,
                                scanner1.Position.Item3 + offset.Item3);
                            return true;
                        }
                    }

                    // Didn't match; no problem, rotate and try again.
                }

                scanner2.Rotate();
            }

            //Console.WriteLine("None found (yet)");
            return false;
        }
    }
}

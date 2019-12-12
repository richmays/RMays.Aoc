using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    public class Day12 : IDay<long>
    {
        public long SolveA(string input)
        {
            return Solve(input, 1000);
        }

        public long Solve(string input, int steps, bool isPartB = false)
        {
            /*
                <x=-16, y=-1, z=-12>
                <x=0, y=-4, z=-17>
                <x=-11, y=11, z=0>
                <x=2, y=2, z=-6>
            */

            // Read planets
            var myRows = Parser.TokenizeLines(input);
            var Planets = new List<Planet>();
            foreach(var row in myRows)
            {
                var NewPlanet = new Planet();
                NewPlanet.Read(row);
                Planets.Add(NewPlanet);
            }

            var totalSteps = Run(Planets, steps, isPartB);

            if (!isPartB)
            {
                return GetTotalEnergyOfAllPlanets(Planets);
            }
            else
            {
                return totalSteps;
            }
        }

        public long Run(List<Planet> Planets, int steps = 1, bool isPartB = false)
        {
            Log($"After 0 steps:");
            for (int p = 0; p < Planets.Count; p++)
            {
                PrintPlanet(Planets[p]);
            }
            Log("");

            long totalStepsTaken = 0;
            var PlanetXHashes = new List<string>();
            var PlanetYHashes = new List<string>();
            var PlanetZHashes = new List<string>();
            long XSteps = 0;
            long YSteps = 0;
            long ZSteps = 0;
            for (int i = 1; i <= steps || isPartB; i++)
            {
                for(int p1 = 0; p1 < Planets.Count - 1; p1++)
                {
                    for(int p2 = p1 + 1; p2 < Planets.Count; p2++)
                    {
                        ApplyGravity(Planets[p1], Planets[p2]);
                    }
                }

                for(int p = 0; p < Planets.Count; p++)
                {
                    ApplyVelocity(Planets[p]);
                }

                totalStepsTaken++;

                var hashes = GetHashes(Planets);
                if (PlanetXHashes.Contains(hashes[0]))
                {
                    if (XSteps == 0)
                    {
                        XSteps = totalStepsTaken;
                    }
                }
                else
                {
                    PlanetXHashes.Add(hashes[0]);
                }

                if (PlanetYHashes.Contains(hashes[1]))
                {
                    if (YSteps == 0) YSteps = totalStepsTaken;
                }
                else
                {
                    PlanetYHashes.Add(hashes[1]);
                }

                if (PlanetZHashes.Contains(hashes[2]))
                {
                    if (ZSteps == 0) ZSteps = totalStepsTaken;
                }
                else
                {
                    PlanetZHashes.Add(hashes[2]);
                }

                if (XSteps != 0 && YSteps != 0 && ZSteps != 0)
                {
                    // Done!  TODO: Simplify; reduce by common factors.
                    XSteps--;
                    YSteps--;
                    ZSteps--;

                    for (int f = 2; f <= Math.Sqrt(XSteps) + 1; f++)
                    {
                        if (XSteps % f == 0 && YSteps % f == 0 && ZSteps % f == 0)
                        {
                            XSteps /= f;
                            YSteps /= f;
                            ZSteps /= f;
                        }
                    }

                    long overallFactor = 1;

                    for(int f = 2; f <= Math.Sqrt(XSteps) + 1; f++)
                    {
                        if (XSteps % f == 0 && YSteps % f == 0)
                        {
                            XSteps /= f;
                            YSteps /= f;
                            overallFactor *= f;
                        }
                    }

                    for (int f = 2; f <= Math.Sqrt(XSteps) + 1; f++)
                    {
                        if (XSteps % f == 0 && ZSteps % f == 0)
                        {
                            XSteps /= f;
                            ZSteps /= f;
                            overallFactor *= f;
                        }
                    }

                    for (int f = 2; f <= Math.Sqrt(YSteps) + 1; f++)
                    {
                        if (YSteps % f == 0 && ZSteps % f == 0)
                        {
                            YSteps /= f;
                            ZSteps /= f;
                            overallFactor *= f;
                        }
                    }

                    return /* overallFactor * */ XSteps * YSteps * ZSteps;
                }

                Log(totalStepsTaken + ": " + hashes[0], true);

                // Print something?
                Log($"After {i} steps:");
                for (int p = 0; p < Planets.Count; p++)
                {
                    PrintPlanet(Planets[p]);
                }
                Log("");


            }

            return -1;
        }

        public List<string> GetHashes(List<Planet> Planets)
        {
            var hashes = new List<string> { "", "", "" };
            for (int p = 0; p < Planets.Count; p++)
            {
                hashes[0] += $"({Planets[p].X},{Planets[p].XVel})";
                hashes[1] += $"({Planets[p].Y},{Planets[p].YVel})";
                hashes[2] += $"({Planets[p].Z},{Planets[p].ZVel})";
            }

            return hashes;
        }

        public int GetTotalEnergyOfAllPlanets(List<Planet> Planets)
        {
            int totalEnergy = 0;
            for (int p = 0; p < Planets.Count; p++)
            {
                totalEnergy += Planets[p].TotalEnergy;
            }
            return totalEnergy;
        }

        public void Log(string log, bool logOverride = false)
        {
            var PrintingEnabled = false;
            if (logOverride || PrintingEnabled)
            {
                Console.WriteLine(log);
            }
        }

        public void ApplyVelocity(Planet planet)
        {
            planet.X += planet.XVel;
            planet.Y += planet.YVel;
            planet.Z += planet.ZVel;
        }

        public void PrintPlanet(Planet planet)
        {
            Log($"pos=<x={planet.X}, y={planet.Y}, z={planet.Z}>, vel=<x={planet.XVel}, y={planet.YVel}, z={planet.ZVel}>");
        }

        public void ApplyGravity(Planet planet1, Planet planet2)
        {
            if (planet1.X < planet2.X)
            {
                planet1.XVel++;
                planet2.XVel--;
            }
            else if (planet1.X > planet2.X)
            {
                planet1.XVel--;
                planet2.XVel++;
            }

            if (planet1.Y < planet2.Y)
            {
                planet1.YVel++;
                planet2.YVel--;
            }
            else if (planet1.Y > planet2.Y)
            {
                planet1.YVel--;
                planet2.YVel++;
            }

            if (planet1.Z < planet2.Z)
            {
                planet1.ZVel++;
                planet2.ZVel--;
            }
            else if (planet1.Z > planet2.Z)
            {
                planet1.ZVel--;
                planet2.ZVel++;
            }
        }

        public class Planet
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public int XVel { get; set; } = 0;
            public int YVel { get; set; } = 0;
            public int ZVel { get; set; } = 0;

            public int PotentialEnergy
            {
                get
                {
                    return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
                }
            }

            public int KineticEnergy
            {
                get
                {
                    return Math.Abs(XVel) + Math.Abs(YVel) + Math.Abs(ZVel);
                }
            }

            public int TotalEnergy
            {
                get
                {
                    return KineticEnergy * PotentialEnergy;
                }
            }

           public string GetHash()
            {
                return $"{X}|{Y}|{Z}|{XVel}|{YVel}|{ZVel}";
            }

            public void Read(string input)
            {
                var row = Parser.Tokenize(input, ',');
                X = int.Parse(row[0].Substring(3));
                Y = int.Parse(row[1].Substring(2));
                Z = int.Parse(row[2].Split('>')[0].Substring(2));
            }
        }

        public long SolveB(string input)
        {
            var myList = Parser.Tokenize(input);
      

            return 456;
        }
    }
}

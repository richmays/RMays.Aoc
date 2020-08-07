using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    #region Day 25
    /*
    --- Day 25: Cryostasis ---
    As you approach Santa's ship, your sensors report two important details:

    First, that you might be too late: the internal temperature is -40 degrees.

    Second, that one faint life signature is somewhere on the ship.

    The airlock door is locked with a code; your best option is to send in a 
    small droid to investigate the situation. You attach your ship to Santa's,
    break a small hole in the hull, and let the droid run in before you seal it
    up again. Before your ship starts freezing, you detach your ship and set it
    to automatically stay within range of Santa's ship.

    This droid can follow basic instructions and report on its surroundings; 
    you can communicate with it through an Intcode program (your puzzle input)
    running on an ASCII-capable computer.

    As the droid moves through its environment, it will describe what it 
    encounters. When it says Command?, you can give it a single instruction 
    terminated with a newline (ASCII code 10). Possible instructions are:

      - Movement via north, south, east, or west.
      - To take an item the droid sees in the environment, use the command 
        take <name of item>. For example, if the droid reports seeing a 
        red ball, you can pick it up with take red ball.
      - To drop an item the droid is carrying, use the command
        drop <name of item>. For example, if the droid is carrying a
        green ball, you can drop it with drop green ball.
      - To get a list of all of the items the droid is currently carrying, use
        the command inv (for "inventory").

    Extra spaces or other characters aren't allowed - instructions must be
    provided precisely.

    Santa's ship is a Reindeer-class starship; these ships use pressure-
    sensitive floors to determine the identity of droids and crew members. The
    standard configuration for these starships is for all droids to weigh
    exactly the same amount to make them easier to detect. If you need to get
    past such a sensor, you might be able to reach the correct weight by 
    carrying items from the environment.

    Look around the ship and see if you can find the password for the main 
    airlock.

    */
    #endregion

    public class Day25 : IDay<long>
    {
        private StringBuilder Output = new StringBuilder();

        private List<string> Items = new List<string>
        {
            "mug",
            "coin",
            "pointer",
            "manifold",
            "astrolabe",
            "hypercube",
            "candy cane",
            "easter egg",
        };

        // Items needed:
        // - coin
        // - mug
        // - hypercube
        // - astrolabe

        /*
            A loud, robotic voice says "Analysis complete! You may proceed." and you enter the cockpit.
            Santa notices your small droid, looks puzzled for a moment, realizes what has happened, and radios your ship directly.
            "Oh, hello! You should be able to get in by typing 1077936448 on the keypad at the main airlock."
        */

        private List<string> Commands = new List<string> {
            // Collect everything.

            "west",
            "take mug",
            "north",
            "take easter egg",
            "south",
            "east",
            "south",
            "south",
            // causes an infinite loop.  go figure.
            // "take infinite loop",
            "north",
            "east",
            // It is suddenly completely dark! You are eaten by a Grue!
            // "take photons",
            "north",
            "take candy cane",

            // now, go back to the start (Hull Breach).
            "south",
            "west",
            "north",

            // Hull Breach


            "east",
            "east", "take coin",
            "north",
            "north",
            "take hypercube",
            "south",
            "east",
            "take manifold",
            "west",
            "south",
            "south",
            "east",
            "take pointer",
            "west",
            "west",
            "take astrolabe",
            "south",
            // The giant electromagnet is stuck to you.  You can't move!!
            //"take giant electromagnet",
            "north",
            "north",
            "east",
            // The molten lava is way too hot! You melt!
            //"take molten lava",
            "north",
            "east",
            "inv"

            // Try dropping stuff ... if you're too heavy.
        };

        public long Solve(string input, bool IsPartB = false)
        {
            if (!IsPartB)
            {
                var Comp = new IntcodeComp(input);
                Comp.Initialize();

                Comp.Run();
                PrintCompOutput(Comp);

                foreach (var command in Commands)
                {
                    SendCommand(Comp, command);
                    PrintCompOutput(Comp);
                }

                bool WeKnowTheSolution = true;
                if (!WeKnowTheSolution)
                {
                    // NOW, let's brute-force the solution.  There's 256 combinations, so it's not terrible.
                    // Figure out when we're too heavy / too light.

                    var IsTooHeavy = new bool[256];
                    IsTooHeavy[255] = true;

                    for (int Inv = 0; Inv <= 255; Inv--)
                    {
                        for (int bit = 0; bit < 8; bit++)
                        {
                            if ((Inv & (int)Math.Pow(2, bit)) != 0)
                            {
                                SendCommand(Comp, "take " + Items[bit]);
                            }
                            else
                            {
                                SendCommand(Comp, "drop " + Items[bit]);
                            }
                        }

                        SendCommand(Comp, "inv");
                        SendCommand(Comp, "east");
                        var result = GetCompOutput(Comp);
                        if (result.Contains("lighter"))
                        {
                            // Too light
                        }
                        else if (result.Contains("heavier"))
                        {
                            // Too heavy
                        }
                        else
                        {
                            // Just right!
                            Console.WriteLine(result);
                            return -1;
                        }
                    }
                }

                var log = Output.ToString();
                Console.WriteLine(log.Substring(Math.Max(log.Length - 3500, 0)));
            }

            return 456;
        }

        private void PrintCompOutput(IntcodeComp Comp)
        {
            while (Comp.Outputs.Any())
            {
                Output.Append((char)Comp.DequeueOutput());
            }
        }

        private string GetCompOutput(IntcodeComp Comp)
        {
            var result = new StringBuilder();
            while (Comp.Outputs.Any())
            {
                result.Append((char)Comp.DequeueOutput());
            }

            return result.ToString();
        }

        private void SendCommand(IntcodeComp Comp, string command, bool PrintCommand = true)
        {
            if (PrintCommand)
            {
                Output.Append($"> {command}");
            }

            foreach (var c in command)
            {
                Comp.InjectInput(c);
            }
            Comp.InjectInput(10);
            Comp.Run();
        }
    }
}

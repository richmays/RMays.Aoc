using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day24
    {
        public enum GroupType
        {
            Unknown,
            ImmuneSystem,
            Infection
        }

        public class Group
        {
            public GroupType GroupType { get; set; }
            public int Id { get; set; }
            public int Units { get; set; }
            public int HitPoints { get; set; }
            public List<string> Immunities { get; set; }
            public List<string> Weaknesses { get; set; }
            public int AttackPower { get; set; }
            public string AttackType { get; set; }
            public int Initiative { get; set; }
            public bool IsAlive() => Units > 0;
            public int EffectivePower => AttackPower * Units;

            public Group()
            {
                this.GroupType = GroupType.Unknown;
                this.Immunities = new List<string>();
                this.Weaknesses = new List<string>();
            }

            public override string ToString()
            {
                var imm = (this.Immunities.Any() ? this.Immunities.Aggregate((a, b) => $"{a},{b}") : "-");
                var weak = (this.Weaknesses.Any() ? this.Weaknesses.Aggregate((a, b) => $"{a},{b}") : "-");
                return $"{(GroupType == GroupType.Infection ? "INF" : "IMM")} - u:{this.Units} hp:{this.HitPoints} i:{imm} w:{weak} ap:{this.AttackPower} at:{this.AttackType} init:{this.Initiative}";
            }
        }

        private void Log(string log)
        {
            //Console.WriteLine(log);
        }

        private void Log()
        {
            Log("");
        }

        private List<Group> ReadGroups(string input)
        {
            var Groups = new List<Group>();

            var groupType = GroupType.Unknown;
            var lines = Parser.TokenizeLines(input);
            var currGroupId = 1;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var lineSplit = line.Split(' ');
                if (lineSplit[0] == "Immune")
                {
                    groupType = GroupType.ImmuneSystem;
                    continue;
                }
                if (lineSplit[0] == "Infection:")
                {
                    groupType = GroupType.Infection;
                    continue;
                }

                var group = new Group();
                group.GroupType = groupType;
                group.Units = int.Parse(lineSplit[0]);
                group.HitPoints = int.Parse(lineSplit[4]);
                group.Initiative = int.Parse(lineSplit[lineSplit.Length - 1]);
                group.AttackType = lineSplit[lineSplit.Length - 5];
                group.AttackPower = int.Parse(lineSplit[lineSplit.Length - 6]);

                if (line.IndexOf('(') > 0)
                {
                    var immuneWeak = line.Split('(')[1].Split(')')[0];
                    var currImmuneWeakState = "Unknown";
                    foreach (var token in immuneWeak.Split(' '))
                    {
                        switch (token)
                        {
                            case "to":
                                break;
                            case "immune":
                                currImmuneWeakState = "immune";
                                break;
                            case "weak":
                                currImmuneWeakState = "weak";
                                break;
                            default:
                                var currType = token.Replace(",", "").Replace(";", "");
                                switch (currImmuneWeakState)
                                {
                                    case "immune":
                                        group.Immunities.Add(currType);
                                        break;
                                    case "weak":
                                        group.Weaknesses.Add(currType);
                                        break;
                                    default:
                                        throw new ApplicationException($"Unexpected weak / immune state: {currImmuneWeakState}");
                                }
                                break;
                        }
                    }
                }

                group.Id = currGroupId++;
                Groups.Add(group);
            }

            return Groups;
        }

        public int FightUntilOneSideWins(List<Group> Groups)
        {
            var day = 1;
            while (SidesAlive(Groups) > 1)
            {
                Log($"Day {day}");
                Log($"Immune System:");
                foreach(var group in Groups.Where(x => x.IsAlive() && x.GroupType == GroupType.ImmuneSystem).OrderBy(x => x.Id))
                {
                    Log($"Group {group.Id} contains {group.Units} units");
                }
                Log($"Infection:");
                foreach (var group in Groups.Where(x => x.IsAlive() && x.GroupType == GroupType.Infection).OrderBy(x => x.Id))
                {
                    Log($"Group {group.Id} contains {group.Units} units");
                }
                Log();

                // Each group chooses their target.
                var targets = new Dictionary<int, int>();
                foreach (var group in Groups.Where(x => x.IsAlive()).OrderByDescending(x => x.EffectivePower).ThenByDescending(x => x.Initiative))
                {
                    //var targets = Groups.Where(x => x.IsAlive() && x.GroupType != group.GroupType).ToList();
                    var bestTarget = Groups.Where(x => x.IsAlive() && x.GroupType != group.GroupType && !targets.Values.Contains(x.Id))
                        .OrderBy(x => x.Weaknesses.Contains(group.AttackType) ? 0 : 1)
                        .ThenBy(x => x.Immunities.Contains(group.AttackType) ? 1 : 0)
                        .ThenByDescending(x => x.EffectivePower)
                        .ThenByDescending(x => x.Initiative)
                        .FirstOrDefault();

                    // Only choose a target if we would actually damage it.  (.. if we would kill units if it attacked.)

                    if (bestTarget != null)
                    {
                        // Don't actually deal the damage.  Just figure out if we Would.
                        // If we would, then select it as a target.
                        var damageFactor = bestTarget.Weaknesses.Contains(group.AttackType) ? 2
                                        : bestTarget.Immunities.Contains(group.AttackType) ? 0
                                        : 1;
                        var damageToDeal = group.EffectivePower * damageFactor;
                        //var unitsKilled = damageToDeal / bestTarget.HitPoints;
                        //if (unitsKilled > 0)
                        if (damageToDeal > 0)
                        {
                            targets.Add(group.Id, bestTarget.Id);
                        }
                    }
                }

                // Now, do damage.
                var totalUnitsLost = 0;
                var groupIdsToAttack = Groups.Where(x => targets.Keys.Contains(x.Id)).OrderByDescending(x => x.Initiative).Select(x => x.Id);
                foreach(var id in groupIdsToAttack)
                {
                    var group = Groups.Where(x => x.Id == id).First();
                    if (!group.IsAlive()) continue;
                    var target = Groups.Where(x => x.Id == targets[group.Id]).First();
                    var damageFactor = target.Weaknesses.Contains(group.AttackType) ? 2
                                    : target.Immunities.Contains(group.AttackType) ? 0
                                    : 1;
                    var damageToDeal = group.EffectivePower * damageFactor;
                    var unitsKilled = Math.Min(damageToDeal / target.HitPoints, target.Units);
                    Log($"{group.GroupType} group {group.Id} attacks defending group {target.Id}, killing {unitsKilled} units.");
                    totalUnitsLost += unitsKilled;
                    target.Units -= unitsKilled;
                }

                if (totalUnitsLost == 0)
                {
                    Log("Stalemate!  No side won.");
                    return -1;
                }

                day++;
                Log();
            }

            return LivingArmyScore(Groups);
        }


        public int SidesAlive(List<Group> Groups)
        {
            return Groups.Where(x => x.IsAlive()).Select(x => x.GroupType).Distinct().Count();
        }

        public GroupType WhoWon(List<Group> Groups)
        {
            var survivors = Groups.Where(x => x.IsAlive()).Select(x => x.GroupType).Distinct().ToList();
            return survivors.Count() > 1 ? GroupType.Unknown : survivors.First();
        }

        public int LivingArmyScore(List<Group> Groups)
        {
            return Groups.Where(x => x.IsAlive()).Sum(x => x.Units);
        }

        public void BoostImmunity(List<Group> Groups, int boost)
        {
            foreach (var group in Groups.Where(x => x.GroupType == GroupType.ImmuneSystem))
            {
                group.AttackPower += boost;
            }
        }

        public long SolveA(string input)
        {
            var Groups = this.ReadGroups(input);

            return this.FightUntilOneSideWins(Groups);
        }

        public long SolveB(string input)
        {
            int boostValue = 0;
            while(true)
            {
                var Groups = this.ReadGroups(input);
                BoostImmunity(Groups, boostValue);
                var result = this.FightUntilOneSideWins(Groups);
                if (WhoWon(Groups) == GroupType.ImmuneSystem)
                {
                    Console.WriteLine($"Boost value: {boostValue}");
                    Console.WriteLine($"Result: {result}");
                    return result;
                }
                boostValue++;
            }
        }
    }
}

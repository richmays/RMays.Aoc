using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2020
{
    #region Day 4
    /*
--- Day 4: Passport Processing ---
You arrive at the airport only to realize that you grabbed your North Pole Credentials instead of your passport. While these documents are extremely similar, North Pole Credentials aren't issued by a country and therefore aren't actually valid documentation for travel in most of the world.

It seems like you're not the only one having problems, though; a very long line has formed for the automatic passport scanners, and the delay could upset your travel itinerary.

Due to some questionable network security, you realize you might be able to solve both of these problems at the same time.

The automatic passport scanners are slow because they're having trouble detecting which passports have all required fields. The expected fields are as follows:

byr (Birth Year)
iyr (Issue Year)
eyr (Expiration Year)
hgt (Height)
hcl (Hair Color)
ecl (Eye Color)
pid (Passport ID)
cid (Country ID)
Passport data is validated in batch files (your puzzle input). Each passport is represented as a sequence of key:value pairs separated by spaces or newlines. Passports are separated by blank lines.

Here is an example batch file containing four passports:

ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in
The first passport is valid - all eight fields are present. The second passport is invalid - it is missing hgt (the Height field).

The third passport is interesting; the only missing field is cid, so it looks like data from North Pole Credentials, not a passport at all! Surely, nobody would mind if you made the system temporarily ignore missing cid fields. Treat this "passport" as valid.

The fourth passport is missing two fields, cid and byr. Missing cid is fine, but missing any other field is not, so this passport is invalid.

According to the above rules, your improved system would report 2 valid passports.

Count the number of valid passports - those that have all required fields. Treat cid as optional. In your batch file, how many passports are valid?

Your puzzle answer was 256.

--- Part Two ---
The line is moving more quickly now, but you overhear airport security talking about how passports with invalid data are getting through. Better add some data validation, quick!

You can continue to ignore the cid field, but each other field has strict rules about what values are valid for automatic validation:

byr (Birth Year) - four digits; at least 1920 and at most 2002.
iyr (Issue Year) - four digits; at least 2010 and at most 2020.
eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
hgt (Height) - a number followed by either cm or in:
If cm, the number must be at least 150 and at most 193.
If in, the number must be at least 59 and at most 76.
hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
pid (Passport ID) - a nine-digit number, including leading zeroes.
cid (Country ID) - ignored, missing or not.
Your job is to count the passports where all required fields are both present and valid according to the above rules. Here are some example values:

byr valid:   2002
byr invalid: 2003

hgt valid:   60in
hgt valid:   190cm
hgt invalid: 190in
hgt invalid: 190

hcl valid:   #123abc
hcl invalid: #123abz
hcl invalid: 123abc

ecl valid:   brn
ecl invalid: wat

pid valid:   000000001
pid invalid: 0123456789
Here are some invalid passports:

eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007
Here are some valid passports:

pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719
Count the number of valid passports - those that have all required fields and valid values. Continue to treat cid as optional. In your batch file, how many passports are valid?

Your puzzle answer was 198.

    */
    #endregion

    public class Day4 : IDay<long>
    {
        private List<string> required = new List<string>
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
            "cid"
        };

        public long Solve(string input, bool IsPartB = false)
        {
            List<string> passports = GetPassports(input);

            var totalValid = 0;

            if (!IsPartB)
            {
                foreach (var passport in passports)
                {
                    bool valid = true;
                    foreach(var item in required)
                    {
                        if (item == "cid") continue;
                        if (!passport.Contains(item + ":"))
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid) totalValid++;
                }

                return totalValid;
            }

            foreach (var passport in passports)
            {
                bool valid = true;
                foreach (var item in required)
                {
                    if (item == "cid") continue;
                    if (!passport.Contains(item + ":"))
                    {
                        //Console.WriteLine("INVALID: " + passport + "; reason: Missing field: '" + item + "'");
                        valid = false;
                        break;
                    }
                }

                if (valid)
                {
                    var reason = "";
                    if (PassportIsValid(passport, out reason))
                    {
                        totalValid++;
                    }
                    else
                    {
                        //Console.WriteLine("INVALID: " + passport + "; reason: " + reason);
                    }

                    /*
                    Console.WriteLine(passport);
                    foreach (var itemKey in required)
                    {
                        Console.WriteLine(itemKey + " : [" + GetValue(passport, itemKey) + "]");
                    }
                    */
                }
            }

            return totalValid;

        }

        private bool PassportIsValid(string passport, out string reason)
        {
            reason = "";   
            try
            {
                var byr = int.Parse(GetValue(passport, "byr"));
                if (byr < 1920 || byr > 2002)
                {
                    reason = "'byr' out of range; expected between 1920 and 2020.  Value was " + byr;
                    return false;
                }

                var iyr = int.Parse(GetValue(passport, "iyr"));
                if (iyr < 2010 || iyr > 2020)
                {
                    reason = "'iyr' out of range; expected between 2010 and 2020.  Value was " + iyr;
                    return false;
                }

                var eyr = int.Parse(GetValue(passport, "eyr"));
                if (eyr < 2020 || eyr > 2030)
                {
                    reason = "'eyr' out of range; expected between 2020 and 2030.  Value was " + eyr;
                    return false;
                }

                var hgt = GetValue(passport, "hgt");
                if (!hgt.EndsWith("cm") && !hgt.EndsWith("in"))
                {
                    {
                        reason = "'hgt' didn't end with either 'in' or 'cm'.  Value was " + hgt;
                        return false;
                    }
                }
                var hgtVal = int.Parse(hgt.Substring(0, hgt.Length - 2));
                switch(hgt.Substring(hgt.Length - 2,2))
                {
                    case "cm":
                        if (hgtVal < 150 || hgtVal > 193)
                        {
                            reason = "'hgt' out of range; expected between 150cm and 193cm.  Value was " + hgt;
                            return false;
                        }
                        break;
                    case "in":
                        if (hgtVal < 59 || hgtVal > 76)
                        {
                            reason = "'hgt' out of range; expected between 59in and 76in.  Value was " + hgt;
                            return false;
                        }
                        break;
                    default:
                        reason = "'hgt' didn't end with either 'cm' or 'in'.  Value was " + hgt;
                        return false;
                }

                var hcl = GetValue(passport, "hcl");
                if (hcl.Length != 7)
                {
                    reason = "'hcl' length wasn't 7.  Value was " + hcl;
                    return false;
                }
                if (hcl[0] != '#')
                {
                    reason = "'hcl' didn't start with '#'.  Value was " + hcl;
                    return false;
                }
                for (int i = 1; i <= 6; i++)
                {
                    char c = hcl[i];
                    if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'))
                    {
                        // valid!
                    }
                    else
                    {
                        reason = "'hcl' had an invalid character; expected all 0-9 and a-f.  Value was " + hcl;
                        return false;
                    }
                }

                var ecl = GetValue(passport, "ecl");
                if (ecl.Length != 3)
                {
                    reason = "'ecl' length wasn't 3.  Value was " + ecl;
                    return false;
                }
                var EyeColors = "amb,blu,brn,gry,grn,hzl,oth";
                if (!EyeColors.Contains(ecl))
                {
                    reason = "'ecl' had an invalid value; expected a valid eye color.  Value was " + ecl;
                    return false;
                }

                var pid = GetValue(passport, "pid");
                if (pid.Length != 9)
                {
                    reason = "'pid' length wasn't 9.  Value was " + pid;
                    return false;
                }
                for (int i = 0; i <= 8; i++ )
                {
                    char c = pid[i];
                    if (c < '0' || c > '9')
                    {
                        reason = "'pid' had an invalid character; expected all 0-9.  Value was " + pid;
                        return false;
                    }
                }
            }
            catch
            {
                reason = "Exception; unknown reason.";
                return false;
            }
            return true;
        }

        private string GetValue(string passport, string itemKey)
        {
            if (!passport.Contains(itemKey + ":")) return "";

            int start = passport.IndexOf(itemKey) + itemKey.Length + 1;
            int end = passport.IndexOf(" ", start);
            if (end == -1)
            {
                return passport.Substring(start);
            }
            else
            {
                return passport.Substring(start, end - start);
            }
        }

        private List<string> GetPassports(string input)
        {
            List<string> passports = new List<string>();
            var lines = input.Split('\n');
            var passport = "";
            foreach(var line in lines)
            {
                if (line.Trim().Length == 0)
                {
                    if (passport != "")
                    {
                        passports.Add(passport);
                    }
                    passport = "";
                }
                else
                {
                    passport += " " + line.Trim();
                }
            }

            if (passport != "" )
            {
                passports.Add(passport);
            }

            return passports;
        }
    }
}

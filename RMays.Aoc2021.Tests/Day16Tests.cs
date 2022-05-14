using NUnit.Framework;
using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2021.Tests
{
    [TestFixture]
    public class Day16Tests
    {
        // Final times:
        // part 1:   XXmXX.XXs
        // part 1+2: XXmXX.XXs

        private string inputData = InputData.Day16;
        private string knownOutputA = "925";
        private string knownOutputB = "342997120375";

        private IDay<long> GetDayObject()
        {
            return new Day16();
        }

        [Test]
        [TestCase(@"8A004A801A8002F478", 16)]
        [TestCase(@"620080001611562C8802118E34", 12)]
        [TestCase(@"C0015000016115A2E0802F182340", 23)]
        [TestCase(@"A0016C880162017C3686B18A3D4780", 31)]
        public void PartATests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase(@"D2FE28", 6, 4)]
        [TestCase(@"38006F45291200", 1, 6)]
        [TestCase(@"EE00D40C823060", 7, 3)]
        public void PacketTests(string input, int version, int typeId)
        {
            var packet = new Day16.Packet(input);
            Assert.AreEqual(version, packet.Version);
            Assert.AreEqual(typeId, packet.PacketTypeId);
        }

        [Test]
        [TestCase(@"C200B40A82", 3)]
        [TestCase(@"04005AC33890", 54)]
        [TestCase(@"880086C3E88112", 7)]
        [TestCase(@"CE00C43D881120", 9)]
        [TestCase(@"D8005AC2A8F0", 1)]
        [TestCase(@"F600BC2D8F", 0)]
        [TestCase(@"9C005AC2F8F0", 0)]
        [TestCase(@"9C0141080250320F1802104A08", 1)]
        public void PartBTests(string input, long expectedOutput)
        {
            var day = GetDayObject();
            var result = day.Solve(input, true);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void DoItA() // ?
        {
            var day = GetDayObject();
            Console.WriteLine(day.Solve(inputData));
        }

        [Test]
        public void DoItB() // ?
        {
            var day = GetDayObject();
            Console.WriteLine(day.Solve(inputData, true));
        }

        [Test]
        public void DoItA_Answer()
        {
            var day = GetDayObject();
            var result = day.Solve(inputData);
            Assert.AreEqual(knownOutputA, result.ToString());
        }

        [Test]
        public void DoItB_Answer()
        {
            var day = GetDayObject();
            var result = day.Solve(inputData, true);
            Assert.AreEqual(knownOutputB, result.ToString());
        }
    }
}

using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Globalization;
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

    public class Day16 : IDay<long>
    {
        public enum PacketTypeEnum
        {
            Literal = 4,
            Operator6 = 6
        }

        public class Packet
        {
            private static int DefaultPacketTypeId => -1;
            private static long DefaultLiteral => -9999999;

            public int Version { get; private set; }
            public int PacketTypeId { get; private set; } = DefaultPacketTypeId;
            public List<Packet> Subpackets { get; private set; } = new List<Packet>();
            private long? _literal = null;
            public long Literal
            {
                get
                {
                    if (_literal != null) return _literal.Value;

                    if (PacketTypeId != DefaultPacketTypeId)
                    {
                        switch (PacketTypeId)
                        {
                            case 0:
                                // Sum
                                _literal = Subpackets.Sum(x => x.Literal);
                                break;
                            case 1:
                                // Product
                                long product = 1;
                                foreach(var packet in Subpackets)
                                {
                                    product *= packet.Literal;
                                }
                                _literal = product;
                                break;
                            case 2:
                                // Minimum
                                _literal = Subpackets.Min(x => x.Literal);
                                break;
                            case 3:
                                // Maximum
                                _literal = Subpackets.Max(x => x.Literal);
                                break;
                            case 5:
                                // Greater Than
                                _literal = Subpackets[0].Literal > Subpackets[1].Literal ? 1 : 0;
                                break;
                            case 6:
                                // Less than
                                _literal = Subpackets[0].Literal < Subpackets[1].Literal ? 1 : 0;
                                break;
                            case 7:
                                // Equal
                                _literal = Subpackets[0].Literal == Subpackets[1].Literal ? 1 : 0;
                                break;
                        }
                    }
                    return _literal ?? DefaultLiteral;
                }
                private set
                {
                    _literal = value;
                }
            }

            /// <summary>
            /// How long is this packet AND all subpackets, in bits?
            /// </summary>
            public int BitLength { get; private set; }

            public int VersionTotal => Version + Subpackets.Sum(x => x.VersionTotal);

            private string BinaryPacket { get; set; }

            public override string ToString()
            {
                return $"V:{Version} T:{PacketTypeId} L:{Literal} Subs:{Subpackets.Count()}";
            }

            public Packet(string hex, bool IsBinary = false)
            {
                if (IsBinary)
                {
                    BinaryPacket = hex;
                }
                else
                {
                    // Convert to a string of 1s and 0s.
                    BinaryPacket = string.Join(string.Empty,
                        hex.Select(x =>
                            Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0')
                        )
                    );
                }

                // Initialize the packet length.
                // Important to determine how many binary digits are in subpackets.
                BitLength = 0;

                // Get the version.  3 binary digits.
                Version = (int)Pop(3);

                // Get the packet type ID.  3 binary digits.
                PacketTypeId = (int)Pop(3);

                if (PacketTypeId == 4)
                {
                    // Literal; get the literal, and jump out.
                    var done = false;
                    Literal = 0;
                    while (!done)
                    {
                        done = Pop(1) == 0;
                        var nextLiteral = Pop(4);
                        Literal = 16 * Literal + nextLiteral;
                    }

                    return;
                }

                // Operator (not sure what it is yet.)
                var lengthTypeId = Pop(1);
                int totalSubPacketLength;
                switch(lengthTypeId)
                {
                    case 0:
                        var totalLengthInBits = Pop(15);
                        totalSubPacketLength = 0;
                        while (totalSubPacketLength < totalLengthInBits)
                        {
                            var copyBinaryPacket = new string(BinaryPacket.ToCharArray());
                            var newPacket = new Packet(copyBinaryPacket, IsBinary: true);
                            totalSubPacketLength += newPacket.BitLength;
                            PopVoid(newPacket.BitLength);
                            this.Subpackets.Add(newPacket);
                        }

                        break;
                    case 1:
                        var numberOfSubPackets = Pop(11);
                        for (int i = 0; i < numberOfSubPackets; i++)
                        {
                            var copyBinaryPacket = new string(BinaryPacket.ToCharArray());
                            var newPacket = new Packet(copyBinaryPacket, IsBinary: true);
                            PopVoid(newPacket.BitLength);
                            this.Subpackets.Add(newPacket);
                        }

                        break;
                }
            }

            /// <summary>
            /// Pops the given number of binary digits from the binary packet representation.
            /// </summary>
            /// <param name="digits">Binary digits to pop</param>
            /// <returns></returns>
            private long Pop(int digits)
            {
                if (digits <= 0)
                {
                    return 0;
                }

                if (BinaryPacket.Length < digits)
                {
                    throw new ApplicationException($"Packet couldn't be popped; not enough binary bits.  BinaryPacket: {BinaryPacket}, pop: {digits}");
                }

                var result = Convert.ToInt64(BinaryPacket.Substring(0, digits), 2);
                BinaryPacket = BinaryPacket.Substring(digits, BinaryPacket.Length - digits);
                BitLength += digits;
                return result;
            }

            private void PopVoid(int digits)
            {
                if (digits <= 0)
                {
                    return;
                }

                if (BinaryPacket.Length < digits)
                {
                    throw new ApplicationException($"Packet couldn't be popped; not enough binary bits.  BinaryPacket: {BinaryPacket}, pop: {digits}");
                }

                BinaryPacket = BinaryPacket.Substring(digits, BinaryPacket.Length - digits);
                BitLength += digits;
            }
        }


        public long Solve(string input, bool IsPartB = false)
        {
            var packet = new Packet(input);
            if (!IsPartB)
            {
                return packet.VersionTotal;
            }
            else
            {
                return packet.Literal;
            }
        }
    }
}

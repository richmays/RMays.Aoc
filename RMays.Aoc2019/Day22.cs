﻿using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2019
{
    #region Day 22
    /*
--- Day 22: Slam Shuffle ---
There isn't much to do while you wait for the droids to repair your ship. At least you're drifting in the right direction. You decide
to practice a new card shuffle you've been working on.

Digging through the ship's storage, you find a deck of space cards! Just like any deck of space cards, there are 10007 cards in the 
deck numbered 0 through 10006. The deck must be new - they're still in factory order, with 0 on the top, then 1, then 2, and so on,
all the way through to 10006 on the bottom.

You've been practicing three different techniques that you use while shuffling. Suppose you have a deck of only 10 cards (numbered 0
through 9):

To deal into new stack, create a new stack of cards by dealing the top card of the deck onto the top of the new stack repeatedly until
you run out of cards:

Top          Bottom
0 1 2 3 4 5 6 7 8 9   Your deck
                      New stack

  1 2 3 4 5 6 7 8 9   Your deck
                  0   New stack

    2 3 4 5 6 7 8 9   Your deck
                1 0   New stack

      3 4 5 6 7 8 9   Your deck
              2 1 0   New stack

Several steps later...

                  9   Your deck
  8 7 6 5 4 3 2 1 0   New stack

                      Your deck
9 8 7 6 5 4 3 2 1 0   New stack
Finally, pick up the new stack you've just created and use it as the deck for the next technique.

To cut N cards, take the top N cards off the top of the deck and move them as a single unit to the bottom of the deck, retaining 
their order. For example, to cut 3:

Top          Bottom
0 1 2 3 4 5 6 7 8 9   Your deck

      3 4 5 6 7 8 9   Your deck
0 1 2                 Cut cards

3 4 5 6 7 8 9         Your deck
              0 1 2   Cut cards

3 4 5 6 7 8 9 0 1 2   Your deck
You've also been getting pretty good at a version of this technique where N is negative! In that case, cut (the absolute value of)
N cards from the bottom of the deck onto the top. For example, to cut -4:

Top          Bottom
0 1 2 3 4 5 6 7 8 9   Your deck

0 1 2 3 4 5           Your deck
            6 7 8 9   Cut cards

        0 1 2 3 4 5   Your deck
6 7 8 9               Cut cards

6 7 8 9 0 1 2 3 4 5   Your deck
To deal with increment N, start by clearing enough space on your table to lay out all of the cards individually in a long line.
Deal the top card into the leftmost position. Then, move N positions to the right and deal the next card there. If you would move 
into a position past the end of the space on your table, wrap around and keep counting from the leftmost card again. Continue this
process until you run out of cards.

For example, to deal with increment 3:


0 1 2 3 4 5 6 7 8 9   Your deck
. . . . . . . . . .   Space on table
^                     Current position

Deal the top card to the current position:

  1 2 3 4 5 6 7 8 9   Your deck
0 . . . . . . . . .   Space on table
^                     Current position

Move the current position right 3:

  1 2 3 4 5 6 7 8 9   Your deck
0 . . . . . . . . .   Space on table
      ^               Current position

Deal the top card:

    2 3 4 5 6 7 8 9   Your deck
0 . . 1 . . . . . .   Space on table
      ^               Current position

Move right 3 and deal:

      3 4 5 6 7 8 9   Your deck
0 . . 1 . . 2 . . .   Space on table
            ^         Current position

Move right 3 and deal:

        4 5 6 7 8 9   Your deck
0 . . 1 . . 2 . . 3   Space on table
                  ^   Current position

Move right 3, wrapping around, and deal:

          5 6 7 8 9   Your deck
0 . 4 1 . . 2 . . 3   Space on table
    ^                 Current position

And so on:

0 7 4 1 8 5 2 9 6 3   Space on table
Positions on the table which already contain cards are still counted; they're not skipped. Of course, this technique is carefully 
designed so it will never put two cards in the same position or leave a position empty.

Finally, collect the cards on the table so that the leftmost card ends up at the top of your deck, the card to its right ends up 
just below the top card, and so on, until the rightmost card ends up at the bottom of the deck.

The complete shuffle process (your puzzle input) consists of applying many of these techniques. Here are some examples that combine
techniques; they all start with a factory order deck of 10 cards:

deal with increment 7
deal into new stack
deal into new stack
Result: 0 3 6 9 2 5 8 1 4 7

cut 6
deal with increment 7
deal into new stack
Result: 3 0 7 4 1 8 5 2 9 6

deal with increment 7
deal with increment 9
cut -2
Result: 6 3 0 7 4 1 8 5 2 9

deal into new stack
cut -2
deal with increment 7
cut 8
cut -4
deal with increment 7
cut 3
deal with increment 9
deal with increment 3
cut -1
Result: 9 2 5 8 1 4 7 0 3 6

Positions within the deck count from 0 at the top, then 1 for the card immediately below the top card, and so on to the bottom. 
(That is, cards start in the position matching their number.)

After shuffling your factory order deck of 10007 cards, what is the position of card 2019?

    */
    #endregion

    public class Day22 : IDay<long>
    {
        /// <summary>
        /// How many cards start in the deck?
        /// </summary>
        public long DeckSize { get; set; }

        /// <summary>
        /// Which card do we want to check the position of at the end? (Part A only)
        /// </summary>
        public long CardToCheck { get; set; }

        /// <summary>
        /// Which position do we want to check the value of at the end? (Part B only)
        /// </summary>
        public long PositionToCheck { get; set; }

        /// <summary>
        /// How many times should we run the shuffle process?  Part A is 1, Part B is a huge number.
        /// </summary>
        public long ShuffleProcesses { get; set; }

        public Day22()// : this(10007, 2019)
        {
        }

        /*

        public Day22(long deckSize, long cardToCheck)
        {
            DeckSize = deckSize;
            CardToCheck = cardToCheck;
            ShuffleProcesses = 1;
        }

        public Day22(long deckSize, long cardToCheck, long shuffleProcesses)
        {
            DeckSize = deckSize;
            CardToCheck = cardToCheck;
            ShuffleProcesses = shuffleProcesses;
        }
        */

        public string SolveFull(string input)
        {
            var deck = SolveForwardsFull(input, false);

            var result = "";
            for(int i = 0; i < DeckSize; i++)
            {
                result += $"{deck[i]} ";
            }

            return result.Trim();
        }

        public long Solve(string input, bool IsPartB = false)
        {
            if (!IsPartB)
            {
                return SolveForwards(input, IsPartB);
            }
            else
            {
                return SolveForwards(input, IsPartB);
            }
        }

        public long SolveNewMethodB(string input)
        {
            // Simplest way is to use an array.  Maybe a stack?  Let's use an array.
            var commands = Parser.TokenizeLines(input);

            // Theory: Each command can be reduced to 2 numbers.  We need to combine these numbers so we can do some fancy modular-exponentiation at the end.
            // Linear Congruential Generator!  https://en.wikipedia.org/wiki/Linear_congruential_generator
            // X[n+1] = (aX[n] + c) mod m
            // X is sequence
            // X[n] is the nth item of sequence
            // m is the modulus; 0 < m
            // a is the multiplier; 0 < a < m
            // c is the increment; 0 <= c < m
            // X[0] is the seed; 0 <= X[0] < m

            // Given a bunch of shuffles, build up 'a' and 'c'.
            // Use the expression 'AddDelta(a,c)'.


            // What does it mean to 'deal with increment N', in terms of the original deck?
            // AddDelta(N,0)

            // What does it mean to 'deal into new stack'?
            // AddDelta(-1,-1)

            // What does it mean to 'cut N'?
            // AddDelta(1,-N)

            long a = 1;
            long c = 0;
            int N; // the numeric parameter to the deck action command

            foreach (var command in commands)
            {
                var splitCommand = Parser.Tokenize(command, ' ');
                // The 2nd token has the command.
                switch (splitCommand[1])
                {
                    case "into":
                        // deal into new stack
                        UpdateFactor(ref a, -1, DeckSize);
                        UpdateFactor(ref c, -1, DeckSize);
                        break;
                    case "with":
                        // deal with increment N
                        N = int.Parse(splitCommand[3]);
                        UpdateFactor(ref a, N, DeckSize);
                        UpdateFactor(ref c, 0, DeckSize);
                        break;
                    default:
                        // cut N
                        N = int.Parse(splitCommand[1]);
                        UpdateFactor(ref a, 1, DeckSize);
                        UpdateFactor(ref c, -N, DeckSize);
                        break;
                }
            }

            // Part B
            return ((a * PositionToCheck) + c) % DeckSize;
        }

        private void UpdateFactor(ref long factor, long delta, long modulus)
        {
            factor = (factor + delta) % modulus;
            if (factor < 0)
            {
                factor += modulus;
            }
        }

        private long SolveBackwards(string input)
        {
            // Starting with a factory order deck, run the commands Backwards, remembering ONLY what's in position 'positionToCheck'.
            long currPos = PositionToCheck;
            var commands = Parser.TokenizeLines(input);

            commands.Reverse();

            foreach (var command in commands)
            {
                var splitCommand = Parser.Tokenize(command, ' ');
                // The 2nd token has the command.
                switch (splitCommand[1])
                {
                    case "into":
                        // deal into new stack
                        currPos = DeckSize - currPos - 1;
                        break;
                    case "with":
                        // deal with increment N
                        var increment = int.Parse(splitCommand[3]);
                        // Works, but is sloppy
                        //currPos = (DeckSize * DeckSize + (currPos * (-1 * increment))) % DeckSize;

                        // A little better; we won't get an overflow, I think.
                        // We might.  We'll see.
                        currPos = (DeckSize - (currPos * increment) % DeckSize) % DeckSize;
                        break;
                    default:
                        // cut N
                        var cut = int.Parse(splitCommand[1]);
                        currPos = (DeckSize + currPos + cut) % DeckSize;
                        break;
                }
            }

            return currPos;
        }

        private long[] SolveForwardsFull(string input, bool IsPartB)
        {
            // Simplest way is to use an array.  Maybe a stack?  Let's use an array.
            var deck = FactoryResetDeck(DeckSize);

            var commands = Parser.TokenizeLines(input);
            if (IsPartB)
            {
                //commands.Reverse();
            }

            foreach (var command in commands)
            {
                var splitCommand = Parser.Tokenize(command, ' ');
                // The 2nd token has the command.
                switch (splitCommand[1])
                {
                    case "into":
                        // deal into new stack
                        DealIntoNewStack(ref deck);
                        break;
                    case "with":
                        // deal with increment N
                        DealWithIncrementN(ref deck, int.Parse(splitCommand[3]));
                        break;
                    default:
                        // cut N
                        CutN(ref deck, int.Parse(splitCommand[1]));
                        break;
                }
            }

            return deck;
        }

        public long SolveForwards(string input, bool IsPartB = false)
        {
            var deck = SolveForwardsFull(input, IsPartB);
            if (!IsPartB)
            {
                return FindCardPosition(deck, CardToCheck);
            }
            else
            {
                return deck[PositionToCheck];
            }
        }

        private long FindCardPosition(long[] deck, long cardToCheck)
        {
            for (int i = 0; i < this.DeckSize; i++)
            {
                if (deck[i] == cardToCheck) return i;
            }
            return -1;
        }

        private void DealIntoNewStack(ref long[] deck)
        {
            var newDeck = new long[DeckSize];
            for(long i = 0; i < this.DeckSize; i++)
            {
                newDeck[i] = deck[DeckSize - i - 1];
            }

            deck = newDeck;
        }

        private void DealWithIncrementN(ref long[] deck, int increment)
        {
            var newDeck = new long[DeckSize];
            long pointer = 0;
            for (long i = 0; i < this.DeckSize; i++)
            {
                newDeck[pointer] = deck[i];

                pointer += increment;
                pointer = pointer % DeckSize;
            }

            deck = newDeck;
        }

        private void CutN(ref long[] deck, long cut)
        {
            if (cut < 0)
            {
                CutN(ref deck, DeckSize - Math.Abs(cut));
                return;
            }

            var newDeck = new long[DeckSize];
            for (long i = 0; i < this.DeckSize; i++)
            {
                newDeck[i] = deck[(i + cut) % DeckSize];
            }

            deck = newDeck;
        }

        private long[] FactoryResetDeck(long deckSize)
        {
            var deck = new long[DeckSize];
            for (long i = 0; i < DeckSize; i++)
            {
                deck[i] = i;
            }
            return deck;
        }
    }
}

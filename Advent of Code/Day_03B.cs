using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_03B
    {
        public void Run(List<string> data)
        {
            List<Instruction> instructions = new List<Instruction>();
            foreach (string instruction in data)
            {
                instructions.Add(new Instruction
                {
                    claim = Int32.Parse(Between(instruction, "#", " @")),
                    x = Int32.Parse(Between(instruction, "@ ", ",")),
                    y = Int32.Parse(Between(instruction, ",", ":")),
                    length = Int32.Parse(Between(instruction, ": ", "x")),
                    height = Int32.Parse(instruction.Substring(instruction.LastIndexOf('x') + 1))
                });
            }

            int[,] area = new int[1200, 1200];
            List<int>[,] claims = new List<int>[1200, 1200];

            for (int i = 0; i < 1200; i++)
            {
                for (int j = 0; j < 1200; j++)
                {
                    area[i, j] = -1;
                }
            }

            foreach (Instruction instruction in instructions)
            {
                for (int i = 0; i < instruction.length; i++)
                {
                    for (int j = 0; j < instruction.height; j++)
                    {
                        if (claims[instruction.x + i, instruction.y + j] == null)
                        {
                            claims[instruction.x + i, instruction.y + j] = new List<int>();
                        }

                        area[instruction.x + i, instruction.y + j] += 1;
                        claims[instruction.x + i, instruction.y + j].Add(instruction.claim);
                    }
                }
            }

            List<int> used = new List<int>();
            for (int i = 0; i < 1200; i++)
            {
                for (int j = 0; j < 1200; j++)
                {
                    if (area[i, j] > 0)
                    {
                        foreach (int claim in claims[i, j])
                        {
                            used.Add(claim);
                        }
                    }
                }
            }

            used.Sort();
            int unused = -1;
            for (int i = 1; i < 1200; i++)
            {
                if (used.Contains(i) == false)
                {
                    unused = i;
                    break;
                }
            }

            Console.WriteLine("Answer: " + unused);
        }

        //#1 @ 265,241: 16x26
        public struct Instruction
        {
            public int claim;
            public int x;
            public int y;
            public int length;
            public int height;
        }


        /// EXTENSIONS
        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// </summary>
        public string Between(string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }
    }
}

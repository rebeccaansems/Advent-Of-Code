using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_03A
    {
        public void Run(List<string> data)
        {
            List<Instruction> instructions = new List<Instruction>();
            foreach (string instruction in data)
            {
                instructions.Add(new Instruction
                {
                    x = Int32.Parse(Between(instruction, "@ ", ",")),
                    y = Int32.Parse(Between(instruction, ",", ":")),
                    length = Int32.Parse(Between(instruction, ": ", "x")),
                    height = Int32.Parse(instruction.Substring(instruction.LastIndexOf('x') + 1))
                });
            }

            int[,] area = new int[1000, 1000];

            foreach (Instruction instruction in instructions)
            {
                for (int i = 0; i < instruction.height; i++)
                {
                    for (int j = 0; j < instruction.length; j++)
                    {
                        area[instruction.x + j, instruction.y + i] += 1;
                    }
                }
            }

            int counter = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (area[i, j] > 1)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine("Answer: " + counter);
        }

        //#1 @ 265,241: 16x26
        public struct Instruction
        {
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

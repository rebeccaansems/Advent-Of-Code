using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_04A
    {
        public void Run(List<string> data)
        {
            List<Instruction> instructions = new List<Instruction>();
            foreach (string instruction in data)
            {
                int localYear = Int32.Parse(Between(instruction, "[", "-"));
                int localMonth = Int32.Parse(BetweenLast(instruction, "-", "-"));
                int localDay = Int32.Parse(Between(instruction, localMonth.ToString("00") + "-", " "));
                int localHour = Int32.Parse(Between(instruction, " ", ":"));
                int localMin = Int32.Parse(Between(instruction, ":", "]"));
                string localShiftInstruction = instruction.Substring(instruction.LastIndexOf(']') + 1);

                instructions.Add(new Instruction
                {
                    year = localYear,
                    month = localMonth,
                    day = localDay,
                    hour = localHour,
                    min = localMin,
                    shiftInstruction = localShiftInstruction
                });
            }

            instructions = instructions.OrderBy(o => o.min).OrderBy(o => o.hour)
                .OrderBy(o => o.day).OrderBy(o => o.month).OrderBy(o => o.year).ToList();

            Instruction prevInstruction = new Instruction();
            for (int i = 0; i < instructions.Count; i++)
            {
                if (instructions[i].shiftInstruction.Contains("#"))
                {
                    instructions[i].guardId = Int32.Parse(Between(instructions[i].shiftInstruction, "#", " begins"));
                    instructions[i].isAsleep = false;
                }
                else
                {
                    instructions[i].guardId = prevInstruction.guardId;
                    instructions[i].isAsleep = instructions[i].shiftInstruction.Contains("asleep");
                }
                prevInstruction = instructions[i];
            }

            Dictionary<int, int> guardTime = new Dictionary<int, int>();
            for (int i = 1; i < instructions.Count - 1; i++)
            {
                if (instructions[i].isAsleep)
                {
                    if (guardTime.ContainsKey(instructions[i].guardId))
                    {
                        guardTime[instructions[i].guardId] += instructions[i + 1].min - instructions[i].min;
                    }
                    else
                    {
                        guardTime.Add(instructions[i].guardId, instructions[i + 1].min - instructions[i].min);
                    }
                }
            }

            int sleepiestGuard = guardTime.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            instructions.RemoveAll(x => x.guardId != sleepiestGuard);
            instructions.RemoveAll(x => x.shiftInstruction.Contains("#"));

            int[] timeAsleep = new int[60];
            for (int j = 0; j < instructions.Count - 1; j += 2)
            {
                for (int i = instructions[j].min; i < instructions[j + 1].min; i++)
                {
                    timeAsleep[i]++;
                }
            }


            int maxValue = -1;
            int sleepiestTime = 0;
            for (int i = 0; i < 60; i++)
            {
                if (maxValue < timeAsleep[i])
                {
                    maxValue = timeAsleep[i];
                    sleepiestTime = i;
                }
            }

            Console.WriteLine("Answer: " + sleepiestGuard * sleepiestTime);
        }




        //[1518-11-07 00:21] falls asleep
        public class Instruction
        {
            public int year;
            public int month;
            public int day;

            public int hour;
            public int min;

            public string shiftInstruction;

            public int guardId;
            public bool isAsleep;
        }

        /// EXTENSIONS
        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// </summary>
        public string Between(string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.IndexOf(b);
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

        public string BetweenLast(string value, string a, string b)
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

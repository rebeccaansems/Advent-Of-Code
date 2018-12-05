using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_05B
    {
        public void Run(List<string> data)
        {
            List<byte> basePolymer = Encoding.ASCII.GetBytes(data[0].ToCharArray()).ToList();

            int shortestPoly = int.MaxValue;
            for (int j = 65; j < 90; j++)
            {
                List<byte> polymer = Encoding.ASCII.GetBytes(data[0].ToCharArray()).ToList();

                polymer.RemoveAll(x => x == j);
                polymer.RemoveAll(x => x == j + 32);

                for (int i = 0; i < polymer.Count - 1; i++)
                {
                    if (Math.Abs(polymer[i] - polymer[i + 1]) == 32)
                    {
                        polymer.RemoveAt(i + 1);
                        polymer.RemoveAt(i);

                        i -= 2;
                        if (i < 0)
                        {
                            i = 0;
                        }
                    }
                }

                if (shortestPoly > polymer.Count)
                {
                    shortestPoly = polymer.Count;
                }
            }

            Console.WriteLine("Answer: " + shortestPoly);
        }
    }
}

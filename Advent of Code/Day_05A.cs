using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_05A
    {
        public void Run(List<string> data)
        {
            List<byte> polymer = Encoding.ASCII.GetBytes(data[0].ToCharArray()).ToList();

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

            Console.WriteLine("Answer: " + polymer.Count);
        }
    }
}

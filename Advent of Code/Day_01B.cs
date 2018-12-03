using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_01B
    {
        public void Run(List<string> data)
        {
            int freq = 0;
            int dup = 0;
            bool dupFound = false;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            while (dupFound == false)
            {
                foreach (string instruction in data)
                {
                    freq += Int32.Parse(instruction);
                    if (dict.ContainsKey(freq))
                    {
                        dupFound = true;
                        dup = freq;
                        break;
                    }
                    else
                    {
                        dict.Add(freq, 0);
                    }
                }
            }
            Console.WriteLine("Answer: " + dup);
        }
    }
}

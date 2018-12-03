using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_01A
    {
        public void Run(List<string> data)
        {
            int num = 0;
            foreach (string instruction in data)
            {
                num += Int32.Parse(instruction);
            }
            Console.WriteLine("Answer: " + num);
        }
    }
}

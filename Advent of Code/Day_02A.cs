using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_02A
    {
        public void Run(List<string> data)
        {
            int twice = 0, thrice = 0;
            bool hadTwo = false, hadThree = false;
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            foreach (string instruction in data)
            {
                hadTwo = false;
                hadThree = false;

                foreach (char letter in alphabet)
                {
                    if (instruction.Count(x => x == letter) == 2 && hadTwo == false)
                    {
                        twice++;
                        hadTwo = true;
                    }
                    else if (instruction.Count(x => x == letter) == 3 && hadThree == false)
                    {
                        thrice++;
                        hadThree = true;
                    }
                }
            }
            Console.WriteLine("Answer: " + twice * thrice);
        }
    }
}

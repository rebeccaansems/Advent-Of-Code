using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_06B
    {
        public void Run(List<string> data)
        {
            List<Tuple<int, int, int>> allCoords = new List<Tuple<int, int, int>>();

            for (int i = 0; i < data.Count; i++)
            {
                int x = Int32.Parse(data[i].Substring(0, data[i].IndexOf(',')));
                int y = Int32.Parse(data[i].Substring(data[i].IndexOf(',') + 1));

                allCoords.Add(new Tuple<int, int, int>(x, y, i));
            }

            int closeEnough = 0;
            int[] distances1 = new int[data.Count];
            for (int x = 0; x < 500; x++)
            {
                for (int y = 0; y < 500; y++)
                {
                    int totalDistance = 0;
                    foreach (Tuple<int, int, int> coord in allCoords)
                    {
                        int currDistance = Math.Abs(coord.Item1 - x) + Math.Abs(coord.Item2 - y);
                        totalDistance += currDistance;

                        if (totalDistance > 10000)
                        {
                            break;
                        }
                    }

                    if (totalDistance < 10000)
                    {
                        closeEnough++;
                    }
                }
            }

            Console.WriteLine("Answer: " + closeEnough);
        }
    }
}

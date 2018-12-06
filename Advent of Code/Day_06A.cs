using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_06A
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

            int[] distances1 = new int[data.Count];
            for (int x = -3000; x < 3000; x++)
            {
                for (int y = -3000; y < 3000; y++)
                {
                    int minDistance = int.MaxValue;
                    int minCoord = -1;
                    bool distintDistance = true;
                    foreach (Tuple<int, int, int> coord in allCoords)
                    {
                        int currDistance = Math.Abs(coord.Item1 - x) + Math.Abs(coord.Item2 - y);

                        if (minDistance >= currDistance)
                        {
                            distintDistance = minDistance == currDistance;
                            minDistance = currDistance;
                            minCoord = coord.Item3;
                        }
                    }

                    if (distintDistance == false)
                    {
                        distances1[minCoord]++;
                    }
                }
            }

            int[] distances2 = new int[data.Count];
            for (int x = -1000; x < 1000; x++)
            {
                for (int y = -1000; y < 1000; y++)
                {
                    int minDistance = int.MaxValue;
                    int minCoord = -1;
                    bool distintDistance = true;
                    foreach (Tuple<int, int, int> coord in allCoords)
                    {
                        int currDistance = Math.Abs(coord.Item1 - x) + Math.Abs(coord.Item2 - y);

                        if (minDistance >= currDistance)
                        {
                            distintDistance = minDistance == currDistance;
                            minDistance = currDistance;
                            minCoord = coord.Item3;
                        }
                    }

                    if (distintDistance == false)
                    {
                        distances2[minCoord]++;
                    }
                }
            }


            int[] finalDistances = new int[data.Count];
            for (int i = 0; i < distances1.Length; i++)
            {
                if (distances1[i] == distances2[i])
                {
                    finalDistances[i] = distances2[i];
                }
            }

            Console.WriteLine("Answer: " + finalDistances.Max());
        }
    }
}

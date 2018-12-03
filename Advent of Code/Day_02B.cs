using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class Day_02B
    {
        public void Run(List<string> data)
        {
            int matches = 0;
            string match = "";

            List<string> editedDataList = data;

            for (int i = 0; i < data.Count; i++)
            {
                for (int k = 0; k < data.Count; k++)
                {
                    for (int j = 0; j < data[i].Length; j++)
                    {
                        string a = data[i];
                        string b = data[k];
                        if (a[j] == b[j])
                        {
                            match += a[j];
                            matches++;
                        }
                    }

                    if (matches == data[i].Length - 1)
                    {
                        Console.WriteLine("ANSWER: " + match);
                        i = data.Count;
                        break;
                    }

                    matches = 0;
                    match = "";
                }
            }
        }
    }
}

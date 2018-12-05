using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            CallMethod(line[0].ToString() + line[1].ToString(), line[2].ToString(), "Run");

            Console.ReadKey();
        }

        static void CallMethod(String dayNumber, String dayPart, String methodName)
        {
            Type type = Type.GetType("Advent_of_Code.Day_" + dayNumber + dayPart);
            Object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod(methodName);
            methodInfo.Invoke(obj, new object[1] { ReadData(dayNumber) });
        }

        static List<string> ReadData(String fileName)
        {
            List<string> data = new List<string>();
            using (StreamReader sr = new StreamReader(@"C:\Users\User\Source\Repos\Advent of Code\Advent of Code\DataDay_" + fileName + ".txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }
            return data;
        }
    }
}

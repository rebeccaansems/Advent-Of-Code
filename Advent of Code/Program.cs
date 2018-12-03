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
            CallMethod("Day_" + line, "Run");

            Console.ReadKey();
        }

        static void CallMethod(String fileName, String methodName)
        {
            Type type = Type.GetType("Advent_of_Code." + fileName);
            Object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod(methodName);
            methodInfo.Invoke(obj, new object[1] { ReadData(fileName) });
        }

        static List<string> ReadData(String fileName)
        {
            List<string> data = new List<string>();
            using (StreamReader sr = new StreamReader(@"C:\Users\User\Source\Repos\Advent of Code\Advent of Code\Data" + fileName + ".txt"))
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

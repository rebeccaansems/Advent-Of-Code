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
            ConsoleKeyInfo key1, key2;

            key1 = Console.ReadKey();
            key2 = Console.ReadKey();
            Console.ReadKey();

            CallMethod("Day_" + key1.KeyChar + key2.KeyChar, "Run");

            Console.ReadKey();
        }

        static void CallMethod(String fileName, String methodName)
        {
            Type type = Type.GetType("Advent_of_Code." + fileName);
            Object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod(methodName);
            methodInfo.Invoke(obj, new object[1] { ReadData(fileName) });
        }

        static string ReadData(String fileName)
        {
            string data = "";
            var fileStream = new FileStream(
                @"C:\Users\User\Source\Repos\Advent of Code\Advent of Code\Data"+fileName+".txt", 
                FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fileStream))
            {
                data += sr.ReadToEnd();
            }
            return data;
        }
    }
}

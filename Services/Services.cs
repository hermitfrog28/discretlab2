

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace discretlab.Services
{
    internal class FileReader
    {
        static string file = "C:\\Users\\АНЯ\\Desktop\\discretlab\\discretlab\\input.txt";
        public static (string[] A, List<(string, string)> pairs) ReadFile()
        {
        
            if (!File.Exists(file))
            {
                Console.WriteLine("Ошибка! Не найден файл.");
                return (Array.Empty<string>(), new List<(string, string)>());
            }
            string[] AllData = File.ReadAllLines(file);
            if (AllData.Length == 0)
            {
                Console.WriteLine("Файл пустой.");
                return (Array.Empty<string>(), new List<(string, string)>());
            }
            string[] A = AllData[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

        List<(string, string)> pairs = new List<(string, string)>();

        for (int i = 1; i< AllData.Length; i++)
            {
                string[] elements = AllData[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length == 2)
                {
                    pairs.Add((elements[0], elements[1]));
                }

            }
            Console.WriteLine("Массив:");
            Console.WriteLine(string.Join(", ", A)); 

            Console.WriteLine("Пары отношений:");
            foreach (var el in pairs)
            {
                Console.Write($"({el.Item1},{el.Item2}) ");
            }
            Console.WriteLine();
            Console.WriteLine();
            return (A,pairs);

        }

    

    }


    internal class CreateMatrix
    {
        public bool[,] Matrix;
        public string[] Elements;

        public CreateMatrix(string[] A, List<(string,string)> pairs)
        {
            Elements = A;
            Matrix = new bool[A.Length,A.Length];

            Dictionary<string,int> dic = new Dictionary<string,int>();
            for (int i = 0; i < Elements.Length; i++)
            {
                dic[Elements[i]] = i;
            }
            foreach (var el in pairs)
            {
                if (dic.ContainsKey(el.Item1) &&dic.ContainsKey(el.Item2))
                {
                    int row = dic[el.Item1];
                    int col = dic[el.Item2];
                    Matrix[row, col] = true;
                }
            }
            Console.WriteLine("  "+ string.Join(" ", A) );
            
            for (int i = 0; i < Elements.Length; i++)
            {
                Console.Write(Elements[i] + " ");
                for (int j = 0; j < Elements.Length; j++)
                {
                    Console.Write(Matrix[i, j] ? "1 " : "0 ");
                    
                }
                Console.WriteLine();
            }               
        }

    }

}
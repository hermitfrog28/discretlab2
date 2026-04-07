using System;
using System.Collections.Generic;
using System.Linq;


namespace discretlab.Services
{
    internal class PropertiesService
    {
        //операции
        public bool[,] Or(bool[,] a, bool[,] b)
        {
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);

            bool[,] c = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    c[i, j] = a[i, j] || b[i, j];
                }
            }

            return c;
        }
        public bool[,] And(bool[,] a, bool[,] b)
        {
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);

            bool[,] c = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    c[i, j] = a[i, j] && b[i, j];
                }
            }
            return c;
        }
        public bool IsSubset(bool[,] a, bool[,] b)
        {
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (a[i, j] && !b[i, j])
                        return false;
                }
            }
            return true;
        }

        private bool AreEqual(bool[,] A, bool[,] B)
        {
            int n = A.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (A[i, j] != B[i, j])
                        return false;
            return true;
        }

        //свойства

        public bool IsReflexive(bool[,] a)
        {
            bool[,] I = new bool[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < I.GetLength(0); i++)
            {
                I[i, i] = true;
            }
            if (IsSubset(I, a))
            {
                return true;
            }
            return false;
        }
        public bool IsIrreflexive(bool[,] a)
        {
            bool[,] J = new bool[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < J.GetLength(0); i++)
            {
                for (int j = 0; j < J.GetLength(1); j++)
                {
                    if (i != j) J[i, j] = true;
                    else J[i, j] = false;
                }
            }
            if (IsSubset(a, J)) return true;
            return false;


        }
        public bool IsSymmetric(bool[,] a)
        {
            bool[,] T = new bool[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    if (a[i, j])
                    {
                        T[j, i] = true;
                    }
                }
            }
            if (IsSubset(a, T)) return true;
            return false;
        }

        public bool IsAntisymmetric(bool[,] a)
        {
            //trans matr
            bool[,] T = new bool[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    if (a[i, j])
                    {
                        T[j, i] = true;
                    }
                }
            }
            //1 matr
            bool[,] I = new bool[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < I.GetLength(0); i++)
            {
                I[i, i] = true;
            }
            bool[,] c = And(a, T);

            if (IsSubset(c, I))
            {
                return true;
            }
            return false;

        }

        public bool IsAssymmetric(bool[,] a)
        {
            //trans matr
            bool[,] T = new bool[a.GetLength(0), a.GetLength(1)];
            bool[,] Z = new bool[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    if (a[i, j])
                    {
                        T[j, i] = true;
                    }
                }
            }
            if (IsSubset(And(a, T), Z))
            {
                return true;
            }
            return false;
        }

        public bool IsTransist(bool[,] a)
        {
            bool[,] P = new bool[a.GetLength(0), a.GetLength(1)];
            bool[,] b = a;
            for (int i = 0; i < P.GetLength(0); i++)
            {
                for (int j = 0; j < P.GetLength(1); j++)
                {
                    for (int k = 0; k < P.GetLength(0); k++)
                    {
                        if (a[i, k] && b[k, j])
                        {
                            P[i, j] = true;
                            break;
                        }
                    }
                }
            }
            if (IsSubset(P, a)) return true;
            return false;
        }

        public bool IsConnected(bool[,] a)
        {
            bool[,] T = new bool[a.GetLength(0), a.GetLength(1)];
            bool[,] J = new bool[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    if (a[i, j])
                    {
                        T[j, i] = true;
                    }
                }
            }
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    J[i, j] = true;
                }
            }
            // 1-я
            bool[,] I = new bool[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < I.GetLength(0); i++)
            {
                I[i, i] = true;
            }
            bool[,] G = Or(a, T);
            return AreEqual(Or(Or(a, T), I), J);

        }


        public bool IsEqual(bool[,] a)
        {
            if (IsReflexive(a) && IsSymmetric(a) && IsTransist(a))
            {
                return true;
            }
            return false;
        }
        public List<List<string>> ClassOfEqual(bool[,] a, string[] A)
        {
            var sp = new List<List<string>>();
            bool[] used = new bool[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }
                var Class = new List<string>();
                for (int j = 0; j < A.Length; j++)
                {
                    if (a[i, j] == true)
                    {
                        Class.Add(A[j]);
                        used[j] = true;
                    }
                }
                sp.Add(Class);

            }
            Console.WriteLine("Классы эквивалентности:");
            foreach (List<string> el in sp)
            {
                Console.Write("[ ");
                for (int i = 0; i < el.Count; i++)
                {
                    Console.Write($"{el[i]} ");
                }
                Console.Write("] ");

            }
            Console.WriteLine();
            Console.WriteLine($"\nИндекс разбиения: {sp.Count}\n");

            return sp;

        }

        public bool IsOrderRelated(bool[,] a)
        {
            if (IsAntisymmetric(a) && IsReflexive(a) && IsTransist(a)) return true;
            return false;
        }

        public void MaxMin(bool[,] a, string[] A)
        {
            List<string> min = new List<string>();
            List<string> max = new List<string>();

            for (int i = 0; i < A.Length; i++)
            {
                bool IsMin = true;
                for (int j = 0; j < A.Length; j++)
                {
                    if (a[j, i] && j != i)
                    {
                        IsMin = false;
                        break;
                    }
                }
                if (IsMin)
                {
                    min.Add(A[i]);
                }
            }
            Console.WriteLine($"\nМинимальное значение: {min[0]}");
            for (int i = 0; i < A.Length; i++)
            {
                bool IsMax = true;
                for (int j = 0; j < A.Length; j++)
                {
                    if (a[i, j] && i != j)
                    {
                        IsMax = false;
                        break;
                    }
                }
                if (IsMax)
                {
                    max.Add(A[i]);
                }
            }
            Console.WriteLine($"\nМаксимальное значение: {max[0]}");

            string smallest = null;
            for (int i = 0; i < A.Length; i++)
            {
                bool IsSm = true;
                for (int j = 0; j < A.Length; j++)
                {
                    if (!a[i, j])
                    {
                        IsSm = false;
                        break;
                    }
                }
                if (IsSm)
                {
                    smallest = A[i];
                    break;
                }
            }
            if (smallest != null)
            {
                Console.WriteLine($"\nНаименьшее значение: {smallest}");
            }
            else
            {
                Console.WriteLine("Нет наименьшего значения.");
            }

            string largest = null;
            for (int i = 0; i < A.Length; i++)
            {
                bool IsL = true;
                for (int j = 0; j < A.Length; j++)
                {
                    if (!a[j, i])
                    {
                        IsL = false;
                        break;
                    }
                }
                if (IsL)
                {
                    largest = A[i];
                    break;
                }
            }
            if (largest != null)
            {
                Console.WriteLine($"\nНаибольшее значение: {largest}");
            }
            else
            {
                Console.WriteLine("Нет наибольшего значения.");
            }
        }
    }
}

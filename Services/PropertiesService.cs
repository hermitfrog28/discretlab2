using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discretlab.Services
{
    internal static class PropertiesService
    {
        //опервции
        public static bool[,] Or(bool[,] a, bool[,] b)
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
        public static bool[,] And(bool[,] a, bool[,] b)
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
        public static bool IsSubset(bool[,] a, bool[,] b)
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

        private static bool AreEqual(bool[,] A, bool[,] B)
        {
            int n = A.GetLength(0);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (A[i, j] != B[i, j])
                        return false;
            return true;
        }

        //свойства

        public static bool IsReflexive(bool[,] a)
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
        public static bool IsIrreflexive(bool[,] a)
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
        public static bool IsSymmetric(bool[,] a)
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

        public static bool IsAntisymmetric(bool[,] a)
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

        public static bool IsAssymmetric(bool[,] a)
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

        public static bool IsTransist(bool[,] a)
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

        public static bool IsConnected(bool[,] a)
        {
            bool[,] T = new bool[a.GetLength(0), a.GetLength(1)];
            bool[,] J = new bool[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    if (a[i, j])
                    {
                        T[j, i] =true;
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


    }
}

using discretlab.Services;

class Program
{
    static void Main()
    {
        FileReader K = new FileReader();
        var (A, pairs) = K.ReadFile();

        CreateMatrix relMatrix = new CreateMatrix(A, pairs);

        Console.WriteLine("\nСвойства отношений:\n");

        PropertiesService matr = new PropertiesService();

        Console.WriteLine($"1. Рефлексивность: {(matr.IsReflexive(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"2. Антирефлексивность: {(matr.IsIrreflexive(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"3. Симметричность: {(matr.IsSymmetric(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"4. Антисимметричность: {(matr.IsAntisymmetric(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"5. Ассиметричность: {(matr.IsAssymmetric(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"6. Транзитивность: {(matr.IsTransist(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"7. Связность: {(matr.IsConnected(relMatrix.Matrix) ? "+" : "-")}");


        if (matr.IsEqual(relMatrix.Matrix))
        {
            Console.WriteLine("\nОтношение является отношением эквивалентности.\n");
            matr.ClassOfEqual(relMatrix.Matrix, A);
        }
        else
        {
            Console.WriteLine("\nОтношение не является отношением эквивалениности.\n");
        }
        if (matr.IsOrderRelated(relMatrix.Matrix))
        {
            Console.WriteLine("\nОтношение является отношением порядка.\n");
            matr.MaxMin(relMatrix.Matrix, A);
        }
        else
        {
            Console.WriteLine("\nОтношение не является отношением порядка.\n");
        }
    }
}
using discretlab.Services;

class Program
{
    static void Main()
    {
        var (A,pairs) = FileReader.ReadFile();

        CreateMatrix relMatrix = new CreateMatrix(A,pairs);

        Console.WriteLine("\nСвойства отношений:\n");

        Console.WriteLine($"1. Рефлексивность: {(PropertiesService.IsReflexive(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"2. Антирефлексивность: {(PropertiesService.IsIrreflexive(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"3. Симметричность: {(PropertiesService.IsSymmetric(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"4. Антисимметричность: {(PropertiesService.IsAntisymmetric(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"5. Ассиметричность: {(PropertiesService.IsAssymmetric(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"6. Транзитивность: {(PropertiesService.IsTransist(relMatrix.Matrix) ? "+" : "-")}");
        Console.WriteLine($"7. Связность: {(PropertiesService.IsConnected(relMatrix.Matrix) ? "+" : "-")}");
    }
}
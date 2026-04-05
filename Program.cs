using discretlab.Services;

class Program
{
    static void Main()
    {
        var (A,pairs) = FileReader.ReadFile();

        CreateMatrix relMatrix = new CreateMatrix(A,pairs);
    }
}
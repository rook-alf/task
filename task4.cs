

using System.Text;

internal class Program
{
    public static void Main(string[] args)
    {
        string[] file = File.ReadAllLines(args[0], Encoding.Default);
        int[] mas = file.Select(int.Parse).ToArray();     
        Array.Sort(mas);
        int avgIndex = (mas.Length/2);
        int mediana = mas[avgIndex];
        int sum = 0;
        for (int i = 0; i < mas.Length; i++) 
        {
            sum = Math.Abs(mas[i] - mediana) + sum;
        }
        Console.WriteLine(sum);
    } 
}




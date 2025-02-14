internal class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        if (n < m || m <= 0)
        {
            Console.WriteLine("Введите корректные значения");
            return;
        }

        string a = "1";
        int count = 0;
        
        for (int i = 1; i < n + 1; i++)
        {
            count++;

            if (count == m)
            {
                if (i == 1)
                    break;
                else
                    a += i;
                count = 1;
            }

            if (i == n) 
                i = 0;
        }

        Console.WriteLine(a);      
    }
}

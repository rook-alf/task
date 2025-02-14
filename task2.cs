
record Circle(float X, float Y, float Radius);
record Point(float X, float Y);

internal class Program
{
    public static void Main(string[] args)
    {
        string filePathCircle;
        string filePathDot;

        if (args.Length == 0)
        {
            Console.WriteLine("Введите путь до файла с окружностью: ");
            filePathCircle = Console.ReadLine();
            Console.WriteLine("Введите путь до файла с точками: ");
            filePathDot = Console.ReadLine();
        }
        else
        {
            filePathCircle = args[0];
            filePathDot = args[1];
        }

        Circle circle = GetCircle(filePathCircle);
        List<Point> points = GetPoints(filePathDot);

        for (int i = 0; i < points.Count; i++)
        {

            float x = (circle.X - points[i].X) * (circle.X - points[i].X) + (circle.Y - points[i].Y) * (circle.Y - points[i].Y);

            if (x < circle.Radius * circle.Radius)
            {
                Console.WriteLine('1');
            }
            else if (x == circle.Radius * circle.Radius)
            {
                Console.WriteLine('0');
            }
            else
            {
                Console.WriteLine('2');
            }
        }
    }

    public static Circle ParseCircle(IReadOnlyList<string> lines)
    {
        string[] circleString = lines[0].Split(' ');
        float x = float.Parse(circleString[0]);
        float y = float.Parse(circleString[1]);
        float radius = float.Parse(lines[1]);
        return new Circle(x, y, radius);
    }

    public static List<Point> ParsePoints(IReadOnlyList<string> lines)
    {
        List<Point> point = new List<Point>();
        foreach (string line in lines)
        {
            string[] pointString = line.Split(' ');
            float x = float.Parse(pointString[0]);
            float y = float.Parse(pointString[1]);
            point.Add(new Point(x, y));
        }
        return point;
    }

    public static Circle GetCircle(string filePathCircle)
    {
        if (!File.Exists(filePathCircle))
        {
            Console.WriteLine("Файла с координатами центра окружности не существует");
            Environment.Exit(-1);
        }
        return ParseCircle(File.ReadAllLines(filePathCircle));
    }

    public static List<Point> GetPoints(string filePathDot)
    {
        if (!File.Exists(filePathDot))
        {
            Console.WriteLine("Файла с координатами точек  не существует");
            Environment.Exit(-1);
        }
        List<Point> points = ParsePoints(File.ReadAllLines(filePathDot));
        if (points.Count == 0)
        {
            Console.WriteLine("Файл с координатами точек пустой");
            Environment.Exit(-1);
        }
        if (points.Count > 100)
        {
            Console.WriteLine("Файл координатами точек содержит больше ста точек");
            Environment.Exit(-1);
        }
        return points;
    }
}


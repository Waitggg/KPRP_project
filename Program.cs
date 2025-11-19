using projectKPRP;

try
{
    int nrow, ncolumn;
    Console.WriteLine("Введите количество строк и столбцов двумерного массива(Разделители: | /): ");
    string s = Console.ReadLine();
    string[] ans = s.Split('|').Length>s.Split('/').Length?s.Split('|'):s.Split('/');
    nrow = Convert.ToInt32(ans[0]);
    ncolumn = Convert.ToInt32(ans[1]);
    Random random = new Random();

    int startTime = Environment.TickCount;
    Person[] mass1 = new Person[nrow * ncolumn];
    for(int i = 0; i < nrow*ncolumn; i++)
    {

        mass1[i] = new Person($"P{i}", $"Surname{i}", (new DateTime(random.Next(1900,DateTime.Today.Year), random.Next(1,12), random.Next(1,28))));
        Console.WriteLine(mass1[i]);
    }
    Console.WriteLine($"Время одномерного массива: {Environment.TickCount - startTime}");

    startTime = Environment.TickCount;
    Person[,] mass2 = new Person[nrow, ncolumn];
    for(int i = 0; i < nrow; i++)
    {
        for (int j = 0; j < ncolumn; j++)
        {
            mass2[i,j] = new Person($"P{i}", $"Surname{i}", (new DateTime(random.Next(1900, DateTime.Today.Year), random.Next(1, 12), random.Next(1, 28))));
            Console.WriteLine(mass2[i, j]);
        }
    }
    Console.WriteLine($"Время двумерного массива: {Environment.TickCount - startTime}");

    Person[][] mass3 = new Person[nrow][];
    for (int i = 0; i < nrow; i++)
    {
        Console.WriteLine($"Введите количество столбцов в {i} строке jagged массива: ");
        mass3[i] = new Person[Convert.ToInt32(Console.ReadLine())];
        startTime = Environment.TickCount;
        for (int j = 0; j < mass3[i].Length; j++)
        {
            mass3[i][j] = new Person($"P{i}", $"Surname{i}", (new DateTime(random.Next(1900, DateTime.Today.Year), random.Next(1, 12), random.Next(1, 28))));
            Console.WriteLine(mass3[i][j]);
        }
        Console.WriteLine($"Время jagged массива: {Environment.TickCount - startTime}");
    }
}
catch (Exception e) { Console.WriteLine($"Ошибка {e.Message}"); }
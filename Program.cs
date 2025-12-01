using ConsoleApp1;
using System;
using System.Drawing;
using System.Linq;

ResearchTeam team = new ResearchTeam();
   Console.WriteLine(team.ToShortString());

            Console.WriteLine($"Year: {team[TimeFrame.Year]}");
            Console.WriteLine($"TwoYears: {team[TimeFrame.TwoYears]}");
            Console.WriteLine($"Long: {team[TimeFrame.Long]}");
            
            team.title = "Research";
            team.name = "MIT";
            team.RegNumber = 223;
            team.Info = TimeFrame.TwoYears;
            Console.WriteLine(team);

            Console.WriteLine(team);
            team.AddPapers(new Paper("Paper1", new Person(), DateTime.Now));
            Console.WriteLine(team);
            Console.WriteLine(team.LatestPaper);

            const int SIZE = 100;

    int startTime = Environment.TickCount;
    Paper[] oneDimensionalArray = new Paper[SIZE];
            for (int i = 0; i<SIZE; i++)
            {
                oneDimensionalArray[i] = new Paper($"Paper{i}", new Person(), DateTime.Now.AddDays(i));
            }
Console.WriteLine($"одномерный массив: {Environment.TickCount - startTime} мс");

int startTime2 = Environment.TickCount;
const int ROWS = 10;
const int COLS = 10;
Paper[,] twoDimensionalRectArray = new Paper[ROWS, COLS];
for (int i = 0; i < ROWS; i++)
{
    for (int j = 0; j < COLS; j++)
    {
        twoDimensionalRectArray[i, j] = new Paper($"Paper{i}_{j}", new Person(), DateTime.Now.AddDays(i + j));
    }
}
Console.WriteLine($"прямоугольный 2D массив: {Environment.TickCount - startTime2} мс");

int startTime3 = Environment.TickCount;
Paper[][] jaggedArray = new Paper[ROWS][];
for (int i = 0; i < ROWS; i++)
{
    jaggedArray[i] = new Paper[COLS];
    for (int j = 0; j < COLS; j++)
    {
        jaggedArray[i][j] = new Paper($"Paper{i}_{j}", new Person(), DateTime.Now.AddDays(i * j));
    }
}
Console.WriteLine($"ступенчатый 2D массив: {Environment.TickCount - startTime3} мс");
try
{
    int nrow, ncolumn;
    Console.WriteLine("Введите количество строк и столбцов двумерного массива(Разделители: | /): ");
    string s = Console.ReadLine();
    string[] ans = s.Split('|').Length > s.Split('/').Length ? s.Split('|') : s.Split('/');
    nrow = Convert.ToInt32(ans[0]);
    ncolumn = Convert.ToInt32(ans[1]);
    Random random = new Random();

    startTime = Environment.TickCount;
    Person[] mass1 = new Person[nrow * ncolumn];
    for (int i = 0; i < nrow * ncolumn; i++)
    {

        mass1[i] = new Person($"P{i}", $"Surname{i}", (new DateTime(random.Next(1900, DateTime.Today.Year), random.Next(1, 12), random.Next(1, 28))));
        Console.WriteLine(mass1[i]);
    }
    Console.WriteLine($"Время одномерного массива: {Environment.TickCount - startTime}");

    startTime = Environment.TickCount;
    Person[,] mass2 = new Person[nrow, ncolumn];
    for (int i = 0; i < nrow; i++)
    {
        for (int j = 0; j < ncolumn; j++)
        {
            mass2[i, j] = new Person($"P{i}", $"Surname{i}", (new DateTime(random.Next(1900, DateTime.Today.Year), random.Next(1, 12), random.Next(1, 28))));
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
catch (Exception e)
{
    Console.WriteLine($"Ошибка {e.Message}");
}

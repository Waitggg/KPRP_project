class Program
    {
        static void Main()
        {
            ResearchTeam team = new ResearchTeam();
            Console.WriteLine(team.ToShortString());

            Console.WriteLine($"Year: {team[TimeFrame.Year]}");
            Console.WriteLine($"TwoYears: {team[TimeFrame.TwoYears]}");
            Console.WriteLine($"Long: {team[TimeFrame.Long]}");
            
            team.title = "Research";
            team.name = "MIT";
            team.RegNumber = 223;
            team.Info = TimeFrame.TwoYears;
            Console.WriteLine(team.ToString());

            Console.WriteLine(team.ToString());
            team.AddPapers(new Paper("Paper1", new Person(), DateTime.Now));
            Console.WriteLine(team.ToString());
            Console.WriteLine(team.LatestPaper);

            const int SIZE = 100;

            int startTime = Environment.TickCount;
            Paper[] oneDimensionalArray = new Paper[SIZE];
            for (int i = 0; i < SIZE; i++)
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
        }
    }
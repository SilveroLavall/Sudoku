﻿if (args.Length > 0)
{
    List<string> puzzles = [];
    for (int i = 0; i < args.Length; i++)
    {
        Console.WriteLine($"args[{i}]={args[i]}");
        puzzles.Add(args[i]);
    }
    Start(puzzles);
}
else 
{
    Console.WriteLine("No arguments found.");
    Console.WriteLine("Try executing:");
    Console.WriteLine("DreamOn.SudokuSolver.Console.exe 000309000000000068070000000800040000000700100206000000000970000000086000030000500");
}

static void Start(List<string> puzzles)
{
    foreach (var puzzle in puzzles)
    {
        Console.WriteLine("******************");
        Console.WriteLine(puzzle);
        Console.WriteLine($"{DateTime.Now} Stopwatch word gestart.");
        var response = SudokuEngine.SolveSudoku(puzzle);
        Console.WriteLine($"{DateTime.Now} Stopwatch is gestopt.");
        response.DisplayPuzzle();
        response.DisplaySolutions();
        response.RenderPuzzleAndSolutions();
        response.DisplayInvalid();
        Console.WriteLine($"Solved in {response.CalculationCycle} cycles.");
        Console.WriteLine($"Execution Time: {response.ElapsedMilliseconds} ms");
        Console.WriteLine("******************");
    }
}

using System.Diagnostics;
using DreamOn.SudokuSolver.Library;
using DreamOn.SudokuSolver.Library.Extensions;

string[] puzzles = [
    "000309000000000068070000000800040000000700100206000000000970000000086000030000500",
    "000309000000000068070000000800040000000700100206000000000970000000086000030000500",
    "000309000000000068070000000800040000000700100206000000000970000000086000030000500",
    "000309000000000068070000000800040000000700100206000000000970000000086000030000500",
    "000309000000000068070000000800040000000700100206000000000970000000086000030000500"
];

foreach (var puzzle in puzzles)
{
    var watch = new Stopwatch();
    Console.WriteLine($"{DateTime.Now} Stopwatch word gestart.");
    watch.Start();
    var response = SudokuEngine.SolveSudoku(puzzle);
    watch.Stop();
    Console.WriteLine($"{DateTime.Now} Stopwatch is gestopt.");
    response.DisplayPuzzle();
    response.DisplaySolutions();
    response.DisplayInvalid();
    Console.WriteLine($"Solved in {response.CalculationCycle} cycles.");
    Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
}

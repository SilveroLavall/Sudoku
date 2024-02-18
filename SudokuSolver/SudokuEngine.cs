namespace SudokuSolver;

internal class SudokuEngine(string sudokuPuzzle)
{
    public SudokuData Data { get; set; } = new(new Sudoku(sudokuPuzzle));

    public void SolveSudoku()
    {
        var watch = new System.Diagnostics.Stopwatch();
        Console.WriteLine($"{DateTime.Now} Stopwatch word gestart.");
        watch.Start();
        SolveSudoku(Data.Puzzle);
        watch.Stop();
        Console.WriteLine($"{DateTime.Now} Stopwatch is gestopt.");
        DisplayPuzzle();
        DisplaySolutions();
        Console.WriteLine($"Solved in {Data.CalculationCycle} cycles.");
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }

    private void SolveSudoku(Sudoku sudoku)
    {
        ++Data.CalculationCycle;
        if (Data.Solutions.Count > 99)
        {
            return;
        }
        if (sudoku.State == Sudoku.SudokuStates.__Solved)
        {
            Data.Solutions.Add(sudoku);
            return;
        }
        if (sudoku.State == Sudoku.SudokuStates.Unsolved)
        {
            var index = sudoku.IndexFirstZero();
            foreach (int guess in sudoku.GetOptions(index)) 
            {
                SolveSudoku(sudoku.UpdateNewSudoku(index, guess));
            }
        }
    }

    public void DisplayPuzzle()
    {
        Console.WriteLine($"0 {Data.Puzzle.State} {Data.Puzzle}");
    }

    public void DisplaySolutions()
    {
        int i = 0;
        foreach (var solution in Data.Solutions)
        {
            Console.WriteLine($"{i++} {solution.State} {solution}");
        }
    }
}

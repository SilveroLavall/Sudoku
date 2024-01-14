namespace SudokuSolver;

internal class SudokuEngine(string sudokuPuzzle)
{
    public SudokuData Data { get; set; } = new(new Sudoku(sudokuPuzzle));

    public void SolveSudoku()
    {
        SolveSudoku(Data.Puzzle);
    }

    private void SolveSudoku(Sudoku sudoku)
    {
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
            foreach (int guess in new int[] { 1,2,3,4,5,6,7,8,9}) 
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

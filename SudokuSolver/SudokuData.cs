namespace SudokuSolver;

internal class SudokuData(Sudoku puzzle)
{
    public Sudoku Puzzle { get; set; } = puzzle;
    public List<Sudoku> Solutions { get; set; } = [];
}

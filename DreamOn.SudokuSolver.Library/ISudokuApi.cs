namespace DreamOn.SudokuSolver.Library;

public interface ISudokuApi
{
    public SudokuResponse SolveSudoku(SudokuRequest request);
    public SudokuResponse SolveSudoku(string sudokuString);
}

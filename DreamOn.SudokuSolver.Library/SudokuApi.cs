namespace DreamOn.SudokuSolver.Library;

public class SudokuApi : ISudokuApi
{
    public SudokuResponse SolveSudoku(SudokuRequest sudokuRequest)
    {
        SudokuSolutions sudokuSolutions = new SudokuEngine20240706(sudokuRequest.SudokuPuzzle).SolveSudokuPuzzle();
        return new(sudokuRequest, sudokuSolutions);
    }

    public SudokuResponse SolveSudoku(string sudokuString)
    {
        SudokuRequest sudokuRequest = new(sudokuString);
        SudokuSolutions sudokuSolutions = new SudokuEngine20240706(sudokuRequest.SudokuPuzzle).SolveSudokuPuzzle();
        return new(sudokuRequest, sudokuSolutions);
    }
}

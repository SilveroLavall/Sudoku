namespace DreamOn.SudokuSolver.Library;

public class SudokuEngine
{
    internal static readonly int[][] SudokuNumberPositionsMapping = InitProvider.GetSudokuNumberPositionsMapping();

    public static SudokuResponse SolveSudoku(string sudokuPuzzle)
    {
        var sudokuValidator = new SudokuValidator(sudokuPuzzle);
        var response = new SudokuResponse(sudokuValidator.Puzzle);

        return sudokuValidator.IsValid 
            ? new SudokuSolver(response).SolveSudokuParallel()
            : response.AddInvalidPuzzle(sudokuValidator.Puzzle);
    }
}

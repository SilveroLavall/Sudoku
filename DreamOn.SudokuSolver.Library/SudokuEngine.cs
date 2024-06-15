namespace DreamOn.SudokuSolver.Library;

public class SudokuEngine
{
    internal static readonly int[][] SudokuNumberPositionsMapping = InitProvider.GetSudokuNumberPositionsMapping();

    public static SudokuResponse SolveSudoku(string sudokuPuzzle)
    {
        var sudokuRequest = new SudokuRequest(sudokuPuzzle);
        var response = new SudokuResponse(sudokuRequest.Puzzle);

        return sudokuRequest.IsValid 
            ? new SudokuSolver(response).SolveSudokuParallel()
            : response.AddInvalidPuzzle(sudokuRequest.Puzzle);
    }
}

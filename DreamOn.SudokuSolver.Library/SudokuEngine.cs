namespace DreamOn.SudokuSolver.Library;

public class SudokuEngine
{
    internal static readonly Dictionary<int, int[]> SudokuNumberPositionsMapping = InitProvider.GetSudokuNumberPositionsMapping();

    public static SudokuResponse SolveSudoku(string sudokuPuzzle)
    {
        var response = new SudokuSolver(new SudokuResponse(sudokuPuzzle.ConvertToNumbers())).SolveSudokuParallel();
        return response;
    }
}

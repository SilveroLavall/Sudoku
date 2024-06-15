namespace DreamOn.SudokuSolver.Library;

public class SudokuEngine
{
    internal static readonly int[][] SudokuNumberPositionsMapping = InitProvider.GetSudokuNumberPositionsMapping();

    public static SudokuResponse SolveSudoku(string sudokuPuzzleString)
    {
        var response = new SudokuResponse(new SudokuRequest(sudokuPuzzleString))
        {
            BeginDateTime = DateTime.Now
        };
        if (response.SudokuRequest.IsValid)
        {
            var stopWatch = Stopwatch.StartNew();
            new SudokuSolver(response).SolveSudokuParallel();
            stopWatch.Stop();
            response.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
        }
        else
        {
            response.AddInvalidPuzzle(response.SudokuRequest.Puzzle);
        }
        response.EndDateTime = DateTime.Now;
        return response;
    }
}

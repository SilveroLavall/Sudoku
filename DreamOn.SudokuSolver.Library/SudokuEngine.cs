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
    public static SudokuSolutions SolveSudoku202406(string sudokuPuzzleString)
    {
        SudokuPuzzle sudokuPuzzle = new() { Puzzle = sudokuPuzzleString.ConvertToSudokuPuzzle() };
        var beginDateTime = DateTime.Now;
        var stopWatch = Stopwatch.StartNew();
        SudokuEngine202406 engine202406 = new(sudokuPuzzle);
        SudokuSolutions sudokuSolutions = engine202406.SolveSudokuPuzzle();
        stopWatch.Stop();
        var endDateTime = DateTime.Now;
        sudokuSolutions.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
        sudokuSolutions.BeginDateTime = beginDateTime;
        sudokuSolutions.EndDateTime = endDateTime;
        return sudokuSolutions;
    }
}

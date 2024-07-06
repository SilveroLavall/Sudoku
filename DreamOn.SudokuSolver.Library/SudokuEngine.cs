namespace DreamOn.SudokuSolver.Library;

public class SudokuEngine
{
    internal static readonly int[][] SudokuNumberPositionsMapping = InitProvider.GetSudokuNumberPositionsMapping();

    public static SudokuResponse SolveSudoku(string sudokuPuzzleString)
    {
        var stopWatch = Stopwatch.StartNew();
        var response = new SudokuResponse(new SudokuRequest(sudokuPuzzleString))
        {
            BeginDateTime = DateTime.Now
        };
        if (response.SudokuRequest.IsValid)
        {
            new SudokuSolver(response).SolveSudokuParallel();
            response.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
        }
        else
        {
            response.AddInvalidPuzzle(response.SudokuRequest.Puzzle);
        }
        stopWatch.Stop();
        response.EndDateTime = DateTime.Now;
        return response;
    }
    public static SudokuSolutions SolveSudoku202406(string sudokuPuzzleString)
    {
        SudokuPuzzle sudokuPuzzle = new() { Puzzle = sudokuPuzzleString.ConvertToSudokuPuzzle() };
        var beginDateTime = DateTime.Now;
        var stopWatch = Stopwatch.StartNew();
        //SudokuEngine202406 engine202406 = new(sudokuPuzzle);
        SudokuSolutions sudokuSolutions = new SudokuEngine202406(sudokuPuzzle).SolveSudokuPuzzleParallel();
        stopWatch.Stop();
        var endDateTime = DateTime.Now;
        sudokuSolutions.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
        sudokuSolutions.BeginDateTime = beginDateTime;
        sudokuSolutions.EndDateTime = endDateTime;
        return sudokuSolutions;
    }
    public static SudokuSolutions SolveSudoku202407(string sudokuPuzzleString)
    {
        SudokuPuzzle sudokuPuzzle = new() { Puzzle = sudokuPuzzleString.ConvertToSudokuPuzzle() };
        var beginDateTime = DateTime.Now;
        var stopWatch = Stopwatch.StartNew();
        SudokuSolutions sudokuSolutions = new SudokuEngine202407(sudokuPuzzle).SolveSudokuPuzzle();
        stopWatch.Stop();
        var endDateTime = DateTime.Now;
        sudokuSolutions.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
        sudokuSolutions.BeginDateTime = beginDateTime;
        sudokuSolutions.EndDateTime = endDateTime;
        return sudokuSolutions;
    }
    public static SudokuSolutions SolveSudoku20240706(string sudokuPuzzleString)
    {
        SudokuPuzzle sudokuPuzzle = new() { Puzzle = sudokuPuzzleString.ConvertToSudokuPuzzle() };
        var beginDateTime = DateTime.Now;
        var stopWatch = Stopwatch.StartNew();
        SudokuSolutions sudokuSolutions = new SudokuEngine20240706(sudokuPuzzle).SolveSudokuPuzzle();
        stopWatch.Stop();
        var endDateTime = DateTime.Now;
        sudokuSolutions.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
        sudokuSolutions.BeginDateTime = beginDateTime;
        sudokuSolutions.EndDateTime = endDateTime;
        return sudokuSolutions;
    }
}

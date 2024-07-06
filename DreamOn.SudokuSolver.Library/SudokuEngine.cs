namespace DreamOn.SudokuSolver.Library;

public class SudokuEngine
{
    internal static readonly int[][] SudokuNumberPositionsMapping = InitProvider.GetSudokuNumberPositionsMapping();

    //public static SudokuResponse SolveSudoku(string sudokuPuzzleString)
    //{
    //    var response = new SudokuResponse(new SudokuRequest(sudokuPuzzleString));
    //    if (!response.SudokuRequest.IsValid)
    //    {
    //        response.BeginDateTime = DateTime.Now;
    //        response.AddInvalidPuzzle(response.SudokuRequest.Puzzle);
    //        response.EndDateTime = DateTime.Now;
    //        return response;
    //    }
    //    response.BeginDateTime = DateTime.Now;
    //    var stopWatch = Stopwatch.StartNew();
    //    new SudokuEngine202405(response).SolveSudokuParallel();
    //    stopWatch.Stop();
    //    response.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
    //    response.EndDateTime = DateTime.Now;
    //    return response;
    //}
    public static SudokuSolutions SolveSudoku202406(string sudokuPuzzleString)
    {
        SudokuPuzzle sudokuPuzzle = new(sudokuPuzzleString.ConvertToSudokuPuzzle());
        var beginDateTime = DateTime.Now;
        var stopWatch = Stopwatch.StartNew();
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
        SudokuPuzzle sudokuPuzzle = new(sudokuPuzzleString.ConvertToSudokuPuzzle());
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
    public static SudokuResponse SolveSudoku20240706(string sudokuPuzzleString)
    {
        SudokuRequest sudokuRequest = new(sudokuPuzzleString);
        SudokuPuzzle sudokuPuzzle = new(sudokuPuzzleString.ConvertToSudokuPuzzle());
        var beginDateTime = DateTime.Now;
        var stopWatch = Stopwatch.StartNew();
        SudokuSolutions sudokuSolutions = new SudokuEngine20240706(sudokuPuzzle).SolveSudokuPuzzle();
        stopWatch.Stop();
        var endDateTime = DateTime.Now;
        sudokuSolutions.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
        sudokuSolutions.BeginDateTime = beginDateTime;
        sudokuSolutions.EndDateTime = endDateTime;
        return new(sudokuRequest, sudokuSolutions);
    }
}

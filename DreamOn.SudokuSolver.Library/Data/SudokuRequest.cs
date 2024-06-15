namespace DreamOn.SudokuSolver.Library.Data;

public class SudokuRequest
{
    public string Input { get; set; } = string.Empty;
    public int[] Puzzle { get; set; } = [];
    public bool IsValid { get; set; }

    public SudokuRequest()
    {
    }

    public SudokuRequest(string sudokuString)
    {
        Input = sudokuString ?? string.Empty;
        Puzzle = ConvertToSudokuPuzzle(Input);
        IsValid = Puzzle.Length == 81;
    }

    private static int[] ConvertToSudokuPuzzle(string sudokuString)
    {
        return sudokuString
            .Select(s => Convert.ToInt32(s) - 48)
            .Where(w => w >= 0 && w <= 9)
            .ToArray();
    }
}

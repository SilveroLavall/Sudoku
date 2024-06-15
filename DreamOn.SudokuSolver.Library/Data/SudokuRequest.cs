namespace DreamOn.SudokuSolver.Library.Data;

internal class SudokuRequest
{
    public int[] Puzzle { get; set; }
    public bool IsValid { get; set; }

    public SudokuRequest(string sudokuString)
    {
        Puzzle = ConvertSudokuString(sudokuString ?? string.Empty);
        IsValid = Puzzle.Length == 81;
    }

    private static int[] ConvertSudokuString(string sudokuString)
    {
        return sudokuString
            .Select(s => Convert.ToInt32(s) - 48)
            .Where(w => w >= 0 && w <= 9)
            .ToArray();
    }
}

namespace DreamOn.SudokuSolver.Library.Providers;

internal class SudokuValidator
{
    public bool IsValid { get; set; }
    public int[] Puzzle { get; set; }

    public SudokuValidator(string sudokuString)
    {
        Puzzle = ConvertSudokuString(sudokuString);
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

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
        Puzzle = Input.ConvertToSudokuPuzzle();
        IsValid = Puzzle.Length == 81;
    }
}

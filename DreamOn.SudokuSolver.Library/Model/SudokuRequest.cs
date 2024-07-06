namespace DreamOn.SudokuSolver.Library.Model;

public class SudokuRequest
{
    public string Input { get; set; } = string.Empty;
    public SudokuPuzzle SudokuPuzzle { get; set; } = new();
    public bool IsValid { get; set; }

    public SudokuRequest() { }
    public SudokuRequest(string sudokuString)
    {
        Input = sudokuString ?? string.Empty;
        SudokuPuzzle = new(Input.ConvertToSudokuPuzzle());
        IsValid = SudokuPuzzle.Puzzle.Length == 81;
    }
}

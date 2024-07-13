namespace DreamOn.SudokuSolver.Library.Model;

public class SudokuRequest
{
    public string Input { get; } = string.Empty;
    public SudokuPuzzle SudokuPuzzle { get; } = new();
    public bool IsValid { get; }

    public SudokuRequest() { }
    public SudokuRequest(string sudokuString)
    {
        Input = sudokuString ?? string.Empty;
        SudokuPuzzle = new(Input.ConvertToSudokuPuzzle());
        IsValid = SudokuPuzzle.Puzzle.Length == 81;
    }
}

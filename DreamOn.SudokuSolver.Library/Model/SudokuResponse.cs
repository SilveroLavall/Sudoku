namespace DreamOn.SudokuSolver.Library.Model;

public class SudokuResponse
{
    public SudokuRequest SudokuRequest { get; } = new();
    public SudokuSolutions SudokuSolutions { get; } = new();

    public SudokuResponse() { }
    public SudokuResponse(SudokuRequest sudokuRequest, SudokuSolutions sudokuSolutions)
    {
        SudokuRequest = sudokuRequest;
        SudokuSolutions = sudokuSolutions;
    }
}

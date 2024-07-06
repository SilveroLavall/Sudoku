namespace DreamOn.SudokuSolver.Library.Model;

public class SudokuResponse
{
    public SudokuRequest SudokuRequest { get; set; } = new();
    public SudokuSolutions SudokuSolutions { get; set; } = new();

    public SudokuResponse() { }
    public SudokuResponse(SudokuRequest request, SudokuSolutions sudokuSolutions)
    {
        SudokuRequest = request;
        SudokuSolutions = sudokuSolutions;
    }
}

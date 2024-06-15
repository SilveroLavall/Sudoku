namespace DreamOn.SudokuSolver.Library.Data;

public class SudokuResponse
{
    public SudokuRequest SudokuRequest { get; set; } = new();
    public List<int[]> Solutions { get; set; } = [];
    public List<int[]> InvalidPuzzles { get; set; } = [];
    public int CalculationCycle { get; set; } = 0;
    public DateTime BeginDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public long ElapsedMilliseconds { get; set; } = 0;

    public SudokuResponse()
    {
    }
    public SudokuResponse(SudokuRequest request)
    {
        SudokuRequest = request;
    }

    public SudokuResponse AddInvalidPuzzle(int[] puzzle)
    {
        InvalidPuzzles.Add(puzzle);
        return this;
    }
}

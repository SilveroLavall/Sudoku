namespace DreamOn.SudokuSolver.Library.Data;

public class SudokuSolutions
{
    public List<int[]> InvalidPuzzles { get; set; } = [];
    public List<int[]> Solutions { get; set; } = [];
    public int CalculationCycle { get; set; } = 0;
    public DateTime BeginDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public long ElapsedMilliseconds { get; set; } = 0;

    public SudokuSolutions AddInvalidPuzzle(int[] puzzle)
    {
        InvalidPuzzles.Add(puzzle);
        return this;
    }
    public SudokuSolutions AddSolution(int[] puzzle)
    {
        Solutions.Add(puzzle);
        return this;
    }
}

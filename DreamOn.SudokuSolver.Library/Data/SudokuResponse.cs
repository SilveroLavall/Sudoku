namespace DreamOn.SudokuSolver.Library.Data;

public class SudokuResponse(int[] puzzle)
{
    public int[] Puzzle { get; set; } = puzzle;
    public List<int[]> Solutions { get; set; } = [];
    public List<int[]> InvalidPuzzles { get; set; } = [];
    public int CalculationCycle { get; set; } = 0;

    public SudokuResponse AddInvalidPuzzle(int[] puzzle)
    {
        InvalidPuzzles.Add(puzzle);
        return this;
    }
}

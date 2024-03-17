namespace SudokuSolver;

internal class SudokuData(int[] puzzle)
{
    public int[] Puzzle { get; set; } = puzzle;
    public List<int[]> Solutions { get; set; } = [];
    public int CalculationCycle { get; set; } = 0;
}

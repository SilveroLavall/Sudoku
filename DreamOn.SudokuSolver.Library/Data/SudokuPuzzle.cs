namespace DreamOn.SudokuSolver.Library.Data;

public class SudokuPuzzle
{
    public int[] Puzzle { get; set; } = [];

    public SudokuPuzzle() { }
    public SudokuPuzzle(int[] puzzle) 
    { 
        Puzzle = puzzle;
    }
}

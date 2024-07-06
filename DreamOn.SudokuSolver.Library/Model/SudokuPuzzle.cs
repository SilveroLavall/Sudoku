namespace DreamOn.SudokuSolver.Library.Model;

public class SudokuPuzzle
{
    public int[] Puzzle { get; set; } = [];

    public SudokuPuzzle() { }
    public SudokuPuzzle(int[] puzzle) 
    { 
        Puzzle = puzzle;
    }
}

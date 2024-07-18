namespace DreamOn.SudokuSolver.Library.Model;

public class SudokuPuzzle
{
    public int[] Puzzle { get; set; } = [];
    public int[] PuzzleBinary { get; set; } = new int[81];

    public SudokuPuzzle() { }
    public SudokuPuzzle(int[] puzzle) 
    { 
        Puzzle = puzzle;
    }
}

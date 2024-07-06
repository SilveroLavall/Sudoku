namespace DreamOn.SudokuSolver.Console.Renders;

public static class RenderToConsole
{
    public static void RenderPuzzleAndSolutions(this SudokuResponse sudokuResponse)
    {
        List<string> sudokus = [sudokuResponse.SudokuRequest.SudokuPuzzle.Puzzle.ConvertToString()];
        sudokus.AddRange(sudokuResponse.SudokuSolutions.Solutions.Select(s => s.ConvertToString()));

        System.Console.WriteLine();
        for (int x = 0; x < 9; x++)
        {
            for (int y= 0; y < sudokus.Count; y++)
            {
                System.Console.Write(" ");
                System.Console.Write(sudokus[y].Substring(9 * x, 9));
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }
}

namespace DreamOn.SudokuSolver.Library.Renders;

public static class RenderToConsole
{
    public static void RenderPuzzleAndSolutions(this SudokuResponse sudokuResponse)
    {
        List<string> sudokus = [sudokuResponse.SudokuRequest.SudokuPuzzle.Puzzle.ConvertToString()];
        sudokus.AddRange(sudokuResponse.SudokuSolutions.Solutions.Select(s => s.ConvertToString()));

        Console.WriteLine();
        for (int x = 0; x < 9; x++)
        {
            for (int y= 0; y < sudokus.Count; y++)
            {
                Console.Write(" ");
                Console.Write(sudokus[y].Substring(9 * x, 9));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

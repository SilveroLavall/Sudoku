namespace DreamOn.SudokuSolver.Console.Extensions
{
    public  static class SudokuExtensions
    {
        #region Display
        public static void DisplaySolutions(this List<int[]> solutions)
        {
            int i = 0;
            foreach (var solution in solutions)
            {
                System.Console.WriteLine($"{i++} {SudokuState.__Solved} {solution.ConvertToString()}");
            }
        }
        #endregion




        public static void DisplayPuzzle(this SudokuResponse response)
        {
            System.Console.WriteLine($"0 {SudokuState.Unsolved} {response.SudokuRequest.SudokuPuzzle.Puzzle.ConvertToString()}");
        }
        public static void DisplaySolutions(this SudokuResponse response)
        {
            int i = 0;
            foreach (var solution in response.SudokuSolutions.Solutions)
            {
                System.Console.WriteLine($"{i++} {SudokuState.__Solved} {solution.ConvertToString()}");
            }
        }
        public static void DisplayInvalid(this SudokuResponse response)
        {
            int i = 0;
            foreach (var invalid in response.SudokuSolutions.InvalidPuzzles)
            {
                System.Console.WriteLine($"{i++} {SudokuState._Invalid} {invalid.ConvertToString()}");
            }
        }
        public static void RenderToConsole(this int[] numbers)
        {
            var sudokuString = string.Concat(numbers.Select(s => s.ToString()));
            for (int i = 0; i < 9; i++) 
            {
                System.Console.WriteLine(sudokuString.Substring(9*i,9));
            }
            System.Console.WriteLine();
        }
    }
}

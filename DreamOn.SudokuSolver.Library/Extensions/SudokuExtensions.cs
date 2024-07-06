namespace DreamOn.SudokuSolver.Library.Extensions
{
    public  static class SudokuExtensions
    {
        #region Convert
        public static string ConvertToString(this int[] numbers)
        {
            return string.Concat(numbers.Select(s => s.ToString()));
        }

        public static int[] ConvertToSudokuPuzzle(this string sudokuString)
        {
            return sudokuString
                .Select(s => Convert.ToInt32(s) - 48)
                .Where(w => w >= 0 && w <= 9)
                .ToArray();
        }
        #endregion

        #region Display
        public static void DisplaySolutions(this List<int[]> solutions)
        {
            int i = 0;
            foreach (var solution in solutions)
            {
                Console.WriteLine($"{i++} {SudokuState.__Solved} {solution.ConvertToString()}");
            }
        }
        #endregion




        public static void DisplayPuzzle(this SudokuResponse response)
        {
            Console.WriteLine($"0 {SudokuState.Unsolved} {response.SudokuRequest.SudokuPuzzle.Puzzle.ConvertToString()}");
        }
        public static void DisplaySolutions(this SudokuResponse response)
        {
            int i = 0;
            foreach (var solution in response.SudokuSolutions.Solutions)
            {
                Console.WriteLine($"{i++} {SudokuState.__Solved} {solution.ConvertToString()}");
            }
        }
        public static void DisplayInvalid(this SudokuResponse response)
        {
            int i = 0;
            foreach (var invalid in response.SudokuSolutions.InvalidPuzzles)
            {
                Console.WriteLine($"{i++} {SudokuState._Invalid} {invalid.ConvertToString()}");
            }
        }
        public static void RenderToConsole(this int[] numbers)
        {
            var sudokuString = string.Concat(numbers.Select(s => s.ToString()));
            for (int i = 0; i < 9; i++) 
            {
                Console.WriteLine(sudokuString.Substring(9*i,9));
            }
            Console.WriteLine();
        }
    }
}

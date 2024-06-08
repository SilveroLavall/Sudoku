namespace DreamOn.SudokuSolver.Library.Extensions
{
    public  static class SudokuExtensions
    {
        public static string ConvertToString(this int[] numbers)
        {
            return string.Concat(numbers.Select(s => s.ToString()));
        }
        public static void DisplayPuzzle(this SudokuResponse response)
        {
            Console.WriteLine($"0 {SudokuStates.Unsolved} {response.Puzzle.ConvertToString()}");
        }
        public static void DisplaySolutions(this SudokuResponse response)
        {
            int i = 0;
            foreach (var solution in response.Solutions)
            {
                Console.WriteLine($"{i++} {SudokuStates.__Solved} {solution.ConvertToString()}");
            }
        }
        public static void DisplayInvalid(this SudokuResponse response)
        {
            int i = 0;
            foreach (var invalid in response.InvalidPuzzles)
            {
                Console.WriteLine($"{i++} {SudokuStates._Invalid} {invalid.ConvertToString()}");
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

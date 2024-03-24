namespace DreamOn.SudokuSolver.Library.Extensions
{
    public  static class SudokuExtensions
    {
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
        public static string ConvertToString(this int[] numbers)
        {
            return string.Concat(numbers.Select(s => s.ToString()));
        }
        public static int[] ConvertToNumbers(this string sudokuString)
        {
            return sudokuString.Select(s => Convert.ToInt32(s) - 48).ToArray();
        }
    }
}

﻿namespace DreamOn.SudokuSolver.Library.Extensions
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
                Console.WriteLine($"{i++} {SudokuStates.__Solved} {solution.ConvertToString()}");
            }
        }
        #endregion




        public static void DisplayPuzzle(this SudokuResponse response)
        {
            Console.WriteLine($"0 {SudokuStates.Unsolved} {response.SudokuRequest.Puzzle.ConvertToString()}");
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

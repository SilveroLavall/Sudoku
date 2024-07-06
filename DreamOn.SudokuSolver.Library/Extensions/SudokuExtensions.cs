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
    }
}

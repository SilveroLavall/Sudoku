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

        public static string ConvertBinariesToString(this int[] binaries)
        {
            return string.Concat(binaries.Select(s => s == 0 ? "0" : s == 1 ? "1" : s == 2 ? "2" : s == 4 ? "3" : s == 8 ? "4" : s == 16 ? "5" : s == 32 ? "6" : s == 64 ? "7" : s == 128 ? "8" : s == 256 ? "9" : "X"));
        }
        #endregion
    }
}

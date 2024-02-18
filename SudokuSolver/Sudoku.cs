namespace SudokuSolver;

internal class Sudoku
{
    public int[] SudokuNumbers { get; set; }
    public SudokuStates State { get; set; }
    public enum SudokuStates
    {
        Unsolved,
        __Solved,
        _Invalid
    }

    public Sudoku(string sudokuString)
    {
        SudokuNumbers = ToNumbers(sudokuString);
        State = CheckSudokuState();
    }

    public Sudoku(int[] sudokuNumbers)
    {
        SudokuNumbers = sudokuNumbers;
        State = CheckSudokuState();
    }

    public static int[] ToNumbers(string sudokuString) 
    {
        return sudokuString.Select(s => Convert.ToInt32(s) - 48).ToArray();
    }

    public override string ToString()
    {
        return string.Concat(SudokuNumbers.Select(s => s.ToString()));
    }

    private SudokuStates CheckSudokuState()
    {
        if (IsInvalid())
        {
            return SudokuStates._Invalid;
        }
        if (SudokuNumbers.Contains(0))
        {
            return SudokuStates.Unsolved;
        }
        return SudokuStates.__Solved;
    }
    public int IndexFirstZero()
    {
        return Array.IndexOf(SudokuNumbers, 0);
    }

    public IEnumerable<int> GetOptions(int indexSudokuNumber)
    {
        int position = indexSudokuNumber%9;
        int startRow = indexSudokuNumber-position;
        int[] indexedRow = new int[9]; 
        for (int i = 0; i < 9; i++)
        {
            indexedRow[i] = SudokuNumbers[startRow+i];
        }
        int[] AllOptions = [1,2,3,4,5,6,7,8,9];
        return AllOptions.Except(indexedRow);
    }
    public Sudoku UpdateNewSudoku(int index, int value)
    {
        List<int> newSudoku = [.. SudokuNumbers];
        newSudoku[index] = value;
        return new(newSudoku.ToArray());
    }

    private bool IsInvalid()
    {
        return IsRowsInvalid();
    }

    private bool IsRowsInvalid()
    {
        foreach (var rownr in new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })
        {
            var row = SudokuNumbers.Skip(rownr * 9).Take(9);
            var dic = row
                .Where(x => x != 0)
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());
            if (dic.Values.Any(a => a > 1))
            {
                return true;
            }
        }
        foreach (var colnr in new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })
        {
            List<int> col = [];
            for (var i = 0; i < 9; i++)
            {
                col.Add(SudokuNumbers[colnr + (i * 9)]);
            }
            var dic = col
                .Where(x => x != 0)
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());
            if (dic.Values.Any(a => a > 1))
            {
                return true;
            }
        }
        foreach (var squarenr in new int[] { 0, 3, 6, 27, 30, 33, 54, 57, 60 })
        {
            List<int> square = [];
            for (int i = 0; i < 3; i++)
            {
                square.Add(SudokuNumbers[squarenr + (i * 9)]);
                square.Add(SudokuNumbers[squarenr + (i * 9) + 1]);
                square.Add(SudokuNumbers[squarenr + (i * 9) + 2]);
            }
            var dic = square
                .Where(x => x != 0)
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());
            if (dic.Values.Any(a => a > 1))
            {
                return true;
            }
        }

        return false;
    }
}

namespace DreamOn.SudokuSolver.Library;

internal class SudokuSolver(SudokuResponse Response)
{
    private bool Continue = true;
    internal enum SudokuStates
    {
        Unsolved,
        __Solved,
        _Invalid
    }

    public SudokuResponse SolveSudokuParallel()
    {
        ++Response.CalculationCycle;
        switch (CheckSudokuState(Response.Puzzle))
        {
            case SudokuStates.Unsolved:
                var index = Array.IndexOf(Response.Puzzle, 0);
                Parallel.ForEach(GetOptions(index, Response.Puzzle), option =>
                {
                    SolveSudoku(UpdateNewSudokuNumber(index, option, Response.Puzzle));
                });
                break;
            case SudokuStates._Invalid:
                Response.InvalidPuzzles.Add(Response.Puzzle);
                break;
            case SudokuStates.__Solved:
                Response.Solutions.Add(Response.Puzzle);
                if (Response.Solutions.Count > 0) Continue = false;
                break;
            default:
                break;
        }
        return Response;
    }
    private void SolveSudoku(int[] sudokuNumbers)
    {
        if (!Continue) return;
        ++Response.CalculationCycle;

        var index = Array.IndexOf(sudokuNumbers, 0);
        if (index > -1)
        {
            foreach (int option in GetOptions(index, sudokuNumbers))
            {
                SolveSudoku(UpdateNewSudokuNumber(index, option, sudokuNumbers));
            }
        }
        else if (IsRowsInvalid(sudokuNumbers))
        {
            Response.InvalidPuzzles.Add(Response.Puzzle);
        }
        else
        {
            Response.Solutions.Add(sudokuNumbers);
            if (Response.Solutions.Count > 0) Continue = false;
        }
    }
    private static SudokuStates CheckSudokuState(int[] numbers)
    {
        if (numbers.Contains(0))
        {
            return SudokuStates.Unsolved;
        }
        if (IsRowsInvalid(numbers))
        {
            return SudokuStates._Invalid;
        }
        return SudokuStates.__Solved;
    }
    private static bool IsRowsInvalid(int[] numbers)
    {
        foreach (var rownr in new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })
        {
            var row = numbers.Skip(rownr * 9).Take(9);
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
                col.Add(numbers[colnr + (i * 9)]);
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
                square.Add(numbers[squarenr + (i * 9)]);
                square.Add(numbers[squarenr + (i * 9) + 1]);
                square.Add(numbers[squarenr + (i * 9) + 2]);
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
    private static List<int> GetOptions(int indexSudokuNumber, int[] numbers)
    {
        var combinedNumbers = SudokuEngine.SudokuNumberPositionsMapping[indexSudokuNumber];
        var used = new bool[10];
        for (int i = 0; i < 27; i++)
        {
            used[numbers[combinedNumbers[i]]] = true;
        }
        List<int> options = [];
        for (int i = 1; i < 10; i++)
        {
            if (!used[i]) options.Add(i);
        }
        return options;
    }
    private static int[] UpdateNewSudokuNumber(int index, int value, int[] numbers)
    {
        int[] newSudoku = numbers[..];
        newSudoku[index] = value;
        return newSudoku;
    }
}

//namespace DreamOn.SudokuSolver.Library.Remove;

//internal class SudokuEngine202405(SudokuResponse Response)
//{
//    private bool Continue = true;
//    internal enum SudokuState
//    {
//        Unsolved,
//        __Solved,
//        _Invalid
//    }

//    public SudokuResponse SolveSudokuParallel()
//    {
//        ++Response.CalculationCycle;
//        switch (CheckSudokuState(Response.SudokuRequest.Puzzle))
//        {
//            case SudokuState.Unsolved:
//                var index = Array.IndexOf(Response.SudokuRequest.Puzzle, 0);
//                Parallel.ForEach(GetOptions(index, Response.SudokuRequest.Puzzle), option =>
//                {
//                    SolveSudoku(UpdateNewSudokuNumber(index, option, Response.SudokuRequest.Puzzle));
//                });
//                break;
//            case SudokuState._Invalid:
//                Response.InvalidPuzzles.Add(Response.SudokuRequest.Puzzle);
//                break;
//            case SudokuState.__Solved:
//                Response.Solutions.Add(Response.SudokuRequest.Puzzle);
//                if (Response.Solutions.Count > 0) Continue = false;
//                break;
//            default:
//                break;
//        }
//        return Response;
//    }
//    private void SolveSudoku(int[] sudokuNumbers)
//    {
//        if (!Continue) return;
//        ++Response.CalculationCycle;
//        var index = Array.IndexOf(sudokuNumbers, 0);
//        if (index > -1)
//        {
//            var used = GetOptionsUsage(index, sudokuNumbers);
//            for (int i = 1; i < 10; i++)
//            {
//                if (!used[i]) SolveSudoku(UpdateNewSudokuNumber(index, i, sudokuNumbers));
//            }
//        }
//        else if (IsRowsInvalid(sudokuNumbers))
//        {
//            Response.InvalidPuzzles.Add(Response.SudokuRequest.Puzzle);
//        }
//        else
//        {
//            Response.Solutions.Add(sudokuNumbers);
//            if (Response.Solutions.Count > 0) Continue = false;
//        }
//    }
//    private static SudokuState CheckSudokuState(int[] numbers)
//    {
//        if (numbers.Contains(0))
//        {
//            return SudokuState.Unsolved;
//        }
//        if (IsRowsInvalid(numbers))
//        {
//            return SudokuState._Invalid;
//        }
//        return SudokuState.__Solved;
//    }
//    private static bool IsRowsInvalid(int[] numbers)
//    {
//        foreach (var rownr in new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })
//        {
//            var row = numbers.Skip(rownr * 9).Take(9);
//            var dic = row
//                .Where(x => x != 0)
//                .GroupBy(x => x)
//                .ToDictionary(g => g.Key, g => g.Count());
//            if (dic.Values.Any(a => a > 1))
//            {
//                return true;
//            }
//        }
//        foreach (var colnr in new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })
//        {
//            List<int> col = [];
//            for (var i = 0; i < 9; i++)
//            {
//                col.Add(numbers[colnr + i * 9]);
//            }
//            var dic = col
//                .Where(x => x != 0)
//                .GroupBy(x => x)
//                .ToDictionary(g => g.Key, g => g.Count());
//            if (dic.Values.Any(a => a > 1))
//            {
//                return true;
//            }
//        }
//        foreach (var squarenr in new int[] { 0, 3, 6, 27, 30, 33, 54, 57, 60 })
//        {
//            List<int> square = [];
//            for (int i = 0; i < 3; i++)
//            {
//                square.Add(numbers[squarenr + i * 9]);
//                square.Add(numbers[squarenr + i * 9 + 1]);
//                square.Add(numbers[squarenr + i * 9 + 2]);
//            }
//            var dic = square
//                .Where(x => x != 0)
//                .GroupBy(x => x)
//                .ToDictionary(g => g.Key, g => g.Count());
//            if (dic.Values.Any(a => a > 1))
//            {
//                return true;
//            }
//        }
//        return false;
//    }
//    private static List<int> GetOptions(int indexSudokuNumber, int[] numbers)
//    {
//        var combinedNumbers = SudokuEngine.SudokuNumberPositionsMapping[indexSudokuNumber];
//        var used = new bool[10];
//        for (int i = 0; i < 21; i++)
//        {
//            used[numbers[combinedNumbers[i]]] = true;
//        }
//        List<int> options = [];
//        for (int i = 1; i < 10; i++)
//        {
//            if (!used[i]) options.Add(i);
//        }
//        return options;
//    }
//    private static bool[] GetOptionsUsage(int indexSudokuNumber, int[] numbers)
//    {
//        var combinedNumbers = SudokuEngine.SudokuNumberPositionsMapping[indexSudokuNumber];
//        var used = new bool[10];
//        for (int i = 0; i < 21; i++)
//        {
//            used[numbers[combinedNumbers[i]]] = true;
//        }
//        return used;
//    }
//    private static int[] UpdateNewSudokuNumber(int index, int value, int[] numbers)
//    {
//        //int[] newSudoku = numbers[..];
//        //int[] newSudoku = (int[]) numbers.Clone();
//        int[] newSudoku = new int[81];
//        Array.Copy(numbers, newSudoku, 81);
//        newSudoku[index] = value;
//        return newSudoku;
//    }
//}

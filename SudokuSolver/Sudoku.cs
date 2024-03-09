namespace SudokuSolver;

internal class Sudoku
{
    private static readonly Dictionary<int,int[]> SudokuCollectionMapping = new()
    {
        { 0,[0,0,0]},
        { 1,[0,1,0]},
        { 2,[0,2,0]},
        { 3,[0,3,1]},
        { 4,[0,4,1]},
        { 5,[0,5,1]},
        { 6,[0,6,2]},
        { 7,[0,7,2]},
        { 8,[0,8,2]},
        { 9,[1,0,0]},
        {10,[1,1,0]},
        {11,[1,2,0]},
        {12,[1,3,1]},
        {13,[1,4,1]},
        {14,[1,5,1]},
        {15,[1,6,2]},
        {16,[1,7,2]},
        {17,[1,8,2]},
        {18,[2,0,0]},
        {19,[2,1,0]},
        {20,[2,2,0]},
        {21,[2,3,1]},
        {22,[2,4,1]},
        {23,[2,5,1]},
        {24,[2,6,2]},
        {25,[2,7,2]},
        {26,[2,8,2]},
        {27,[3,0,3]},
        {28,[3,1,3]},
        {29,[3,2,3]},
        {30,[3,3,4]},
        {31,[3,4,4]},
        {32,[3,5,4]},
        {33,[3,6,5]},
        {34,[3,7,5]},
        {35,[3,8,5]},
        {36,[4,0,3]},
        {37,[4,1,3]},
        {38,[4,2,3]},
        {39,[4,3,4]},
        {40,[4,4,4]},
        {41,[4,5,4]},
        {42,[4,6,5]},
        {43,[4,7,5]},
        {44,[4,8,5]},
        {45,[5,0,3]},
        {46,[5,1,3]},
        {47,[5,2,3]},
        {48,[5,3,4]},
        {49,[5,4,4]},
        {50,[5,5,4]},
        {51,[5,6,5]},
        {52,[5,7,5]},
        {53,[5,8,5]},
        {54,[6,0,6]},
        {55,[6,1,6]},
        {56,[6,2,6]},
        {57,[6,3,7]},
        {58,[6,4,7]},
        {59,[6,5,7]},
        {60,[6,6,8]},
        {61,[6,7,8]},
        {62,[6,8,8]},
        {63,[7,0,6]},
        {64,[7,1,6]},
        {65,[7,2,6]},
        {66,[7,3,7]},
        {67,[7,4,7]},
        {68,[7,5,7]},
        {69,[7,6,8]},
        {70,[7,7,8]},
        {71,[7,8,8]},
        {72,[8,0,6]},
        {73,[8,1,6]},
        {74,[8,2,6]},
        {75,[8,3,7]},
        {76,[8,4,7]},
        {77,[8,5,7]},
        {78,[8,6,8]},
        {79,[8,7,8]},
        {80,[8,8,8]},
    };
    private static readonly Dictionary<int,int[]> HorizontalLines = new()
    {
        {0, [0, 1, 2, 3, 4, 5, 6, 7, 8]},
        {1, [9, 10, 11, 12, 13, 14, 15, 16, 17]},
        {2, [18, 19, 20, 21, 22, 23, 24, 25, 26]},
        {3, [27, 28, 29, 30, 31, 32, 33, 34, 35]},
        {4, [36, 37, 38, 39, 40, 41, 42, 43, 44]},
        {5, [45, 46, 47, 48, 49, 50, 51, 52, 53]},
        {6, [54, 55, 56, 57, 58, 59, 60, 61, 62]},
        {7, [63, 64, 65, 66, 67, 68, 69, 70, 71]},
        {8, [72, 73, 74, 75, 76, 77, 78, 79, 80]}
    };
    private static readonly Dictionary<int,int[]> VerticalLines = new()
    {
        {0, [0, 9, 18, 27, 36, 45, 54, 63, 72]},
        {1, [1, 10, 19, 28, 37, 46, 55, 64, 73]},
        {2, [2, 11, 20, 29, 38, 47, 56, 65, 74]},
        {3, [3, 12, 21, 30, 39, 48, 57, 66, 75]},
        {4, [4, 13, 22, 31, 40, 49, 58, 67, 76]},
        {5, [5, 14, 23, 32, 41, 50, 59, 68, 77]},
        {6, [6, 15, 24, 33, 42, 51, 60, 69, 78]},
        {7, [7, 16, 25, 34, 43, 52, 61, 70, 79]},
        {8, [8, 17, 26, 35, 44, 53, 62, 71, 80]}
    };
    private static readonly Dictionary<int,int[]> Square = new()
    {
        {0, [0, 1, 2, 9, 10, 11, 18, 19, 20]},
        {1, [3, 4, 5, 12, 13, 14, 21, 22, 23]},
        {2, [6, 7, 8, 15, 16, 17, 24, 25, 26]},
        {3, [27, 28, 29, 36, 37, 38, 45, 46, 47]},
        {4, [30, 31, 32, 39, 40, 41, 48, 49, 50]},
        {5, [33, 34, 35, 42, 43, 44, 51, 52, 53]},
        {6, [54, 55, 56, 63, 64, 65, 72, 73, 74]},
        {7, [57, 58, 59, 66, 67, 68, 75, 76, 77]},
        {8, [60, 61, 62, 69, 70, 71, 78, 79, 80]}
    };
    private static readonly int[] AllOptions = [1,2,3,4,5,6,7,8,9];


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
    private SudokuStates CheckSudokuState()
    {
        if (SudokuNumbers.Contains(0))
        {
            return SudokuStates.Unsolved;
        }
        if (IsInvalid())
        {
            return SudokuStates._Invalid;
        }
        return SudokuStates.__Solved;
    }
    public override string ToString()
    {
        return string.Concat(SudokuNumbers.Select(s => s.ToString()));
    }
    public int IndexFirstZero()
    {
        return Array.IndexOf(SudokuNumbers, 0);
    }
    public IEnumerable<int> GetOptions1(int indexSudokuNumber)
    {
        int position = indexSudokuNumber % 9;
        int startRow = indexSudokuNumber-position;
        int[] indexedRow = new int[27]; 
        for (int i = 0; i < 9; i++)
        {
            indexedRow[i] = SudokuNumbers[startRow+i];
        }
        for (int i = 0; i < 9; i++)
        {
            indexedRow[9 + i] = SudokuNumbers[position + (i * 9)];
        }

        int vectorVertical = indexSudokuNumber / 9 % 3 * 9;
        int vectorHorizontal = indexSudokuNumber % 3;
        int startSquare = indexSudokuNumber - vectorVertical - vectorHorizontal;
        indexedRow[18] = SudokuNumbers[startSquare];
        indexedRow[19] = SudokuNumbers[startSquare+1];
        indexedRow[20] = SudokuNumbers[startSquare+2];
        indexedRow[21] = SudokuNumbers[startSquare+9];
        indexedRow[22] = SudokuNumbers[startSquare+10];
        indexedRow[23] = SudokuNumbers[startSquare+11];
        indexedRow[24] = SudokuNumbers[startSquare+18];
        indexedRow[25] = SudokuNumbers[startSquare+19];
        indexedRow[26] = SudokuNumbers[startSquare+20];

        int[] AllOptions = [1,2,3,4,5,6,7,8,9];
        return AllOptions.Except(indexedRow);
    }
    public IEnumerable<int> GetOptions2(int indexSudokuNumber)
    {
        var groups = SudokuCollectionMapping[indexSudokuNumber];
        var hline = HorizontalLines[groups[0]];
        var vline = VerticalLines[groups[1]];
        var square = Square[groups[2]];
        int[] used = new int[27];
        int index = 0;
        for (int i = 0; i < 9; i++)
        {
            used[index++] = SudokuNumbers[hline[i]];
        }
        for (int i = 0; i < 9; i++)
        {
            used[index++] = SudokuNumbers[vline[i]];
        }
        for (int i = 0; i < 9; i++)
        {
            used[index++] = SudokuNumbers[square[i]];
        }

        return AllOptions.Except(used);
    }
    public Sudoku UpdateNewSudoku(int index, int value)
    {
        // int[] newSudoku = [.. SudokuNumbers];
        int[] newSudoku = SudokuNumbers[..];
        newSudoku[index] = value;
        return new(newSudoku);
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
    private static int[] ToNumbers(string sudokuString) 
    {
        return sudokuString.Select(s => Convert.ToInt32(s) - 48).ToArray();
    }
}

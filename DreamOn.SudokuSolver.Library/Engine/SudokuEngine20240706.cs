﻿namespace DreamOn.SudokuSolver.Library.Engine;

internal class SudokuEngine20240706(SudokuPuzzle sudokuPuzzle)
{
    private static readonly int[][] SudokuDependencyMapping =
    [
        [1, 2, 3, 4, 5, 6, 7, 8, 9, 18, 27, 36, 45, 54, 63, 72, 10, 11, 19, 20],
        [0, 2, 3, 4, 5, 6, 7, 8, 10, 19, 28, 37, 46, 55, 64, 73, 9, 11, 18, 20],
        [0, 1, 3, 4, 5, 6, 7, 8, 11, 20, 29, 38, 47, 56, 65, 74, 9, 10, 18, 19],
        [0, 1, 2, 4, 5, 6, 7, 8, 12, 21, 30, 39, 48, 57, 66, 75, 13, 14, 22, 23],
        [0, 1, 2, 3, 5, 6, 7, 8, 13, 22, 31, 40, 49, 58, 67, 76, 12, 14, 21, 23],
        [0, 1, 2, 3, 4, 6, 7, 8, 14, 23, 32, 41, 50, 59, 68, 77, 12, 13, 21, 22],
        [0, 1, 2, 3, 4, 5, 7, 8, 15, 24, 33, 42, 51, 60, 69, 78, 16, 17, 25, 26],
        [0, 1, 2, 3, 4, 5, 6, 8, 16, 25, 34, 43, 52, 61, 70, 79, 15, 17, 24, 26],
        [0, 1, 2, 3, 4, 5, 6, 7, 17, 26, 35, 44, 53, 62, 71, 80, 15, 16, 24, 25],

        [10, 11, 12, 13, 14, 15, 16, 17, 0, 18, 27, 36, 45, 54, 63, 72, 1, 2, 19, 20],
        [9, 11, 12, 13, 14, 15, 16, 17, 1, 19, 28, 37, 46, 55, 64, 73, 0, 2, 18, 20],
        [9, 10, 12, 13, 14, 15, 16, 17, 2, 20, 29, 38, 47, 56, 65, 74, 0, 1, 18, 19],
        [9, 10, 11, 13, 14, 15, 16, 17, 3, 21, 30, 39, 48, 57, 66, 75, 4, 5, 22, 23],
        [9, 10, 11, 12, 14, 15, 16, 17, 4, 22, 31, 40, 49, 58, 67, 76, 3, 5, 21, 23],
        [9, 10, 11, 12, 13, 15, 16, 17, 5, 23, 32, 41, 50, 59, 68, 77, 3, 4, 21, 22],
        [9, 10, 11, 12, 13, 14, 16, 17, 6, 24, 33, 42, 51, 60, 69, 78, 7, 8, 25, 26],
        [9, 10, 11, 12, 13, 14, 15, 17, 7, 25, 34, 43, 52, 61, 70, 79, 6, 8, 24, 26],
        [9, 10, 11, 12, 13, 14, 15, 16, 8, 26, 35, 44, 53, 62, 71, 80, 6, 7, 24, 25],

        [19, 20, 21, 22, 23, 24, 25, 26, 0, 9, 27, 36, 45, 54, 63, 72, 1, 2, 10, 11],
        [18, 20, 21, 22, 23, 24, 25, 26, 1, 10, 28, 37, 46, 55, 64, 73, 0, 2, 9, 11],
        [18, 19, 21, 22, 23, 24, 25, 26, 2, 11, 29, 38, 47, 56, 65, 74, 0, 1, 9, 10],
        [18, 19, 20, 22, 23, 24, 25, 26, 3, 12, 30, 39, 48, 57, 66, 75, 4, 5, 13, 14],
        [18, 19, 20, 21, 23, 24, 25, 26, 4, 13, 31, 40, 49, 58, 67, 76, 3, 5, 12, 14],
        [18, 19, 20, 21, 22, 24, 25, 26, 5, 14, 32, 41, 50, 59, 68, 77, 3, 4, 12, 13],
        [18, 19, 20, 21, 22, 23, 25, 26, 6, 15, 33, 42, 51, 60, 69, 78, 7, 8, 16, 17],
        [18, 19, 20, 21, 22, 23, 24, 26, 7, 16, 34, 43, 52, 61, 70, 79, 6, 8, 15, 17],
        [18, 19, 20, 21, 22, 23, 24, 25, 8, 17, 35, 44, 53, 62, 71, 80, 6, 7, 15, 16],

        [28, 29, 30, 31, 32, 33, 34, 35, 0, 9, 18, 36, 45, 54, 63, 72, 37, 38, 46, 47],
        [27, 29, 30, 31, 32, 33, 34, 35, 1, 10, 19, 37, 46, 55, 64, 73, 36, 38, 45, 47],
        [27, 28, 30, 31, 32, 33, 34, 35, 2, 11, 20, 38, 47, 56, 65, 74, 36, 37, 45, 46],
        [27, 28, 29, 31, 32, 33, 34, 35, 3, 12, 21, 39, 48, 57, 66, 75, 40, 41, 49, 50],
        [27, 28, 29, 30, 32, 33, 34, 35, 4, 13, 22, 40, 49, 58, 67, 76, 39, 41, 48, 50],
        [27, 28, 29, 30, 31, 33, 34, 35, 5, 14, 23, 41, 50, 59, 68, 77, 39, 40, 48, 49],
        [27, 28, 29, 30, 31, 32, 34, 35, 6, 15, 24, 42, 51, 60, 69, 78, 43, 44, 52, 53],
        [27, 28, 29, 30, 31, 32, 33, 35, 7, 16, 25, 43, 52, 61, 70, 79, 42, 44, 51, 53],
        [27, 28, 29, 30, 31, 32, 33, 34, 8, 17, 26, 44, 53, 62, 71, 80, 42, 43, 51, 52],

        [37, 38, 39, 40, 41, 42, 43, 44, 0, 9, 18, 27, 45, 54, 63, 72, 28, 29, 46, 47],
        [36, 38, 39, 40, 41, 42, 43, 44, 1, 10, 19, 28, 46, 55, 64, 73, 27, 29, 45, 47],
        [36, 37, 39, 40, 41, 42, 43, 44, 2, 11, 20, 29, 47, 56, 65, 74, 27, 28, 45, 46],
        [36, 37, 38, 40, 41, 42, 43, 44, 3, 12, 21, 30, 48, 57, 66, 75, 31, 32, 49, 50],
        [36, 37, 38, 39, 41, 42, 43, 44, 4, 13, 22, 31, 49, 58, 67, 76, 30, 32, 48, 50],
        [36, 37, 38, 39, 40, 42, 43, 44, 5, 14, 23, 32, 50, 59, 68, 77, 30, 31, 48, 49],
        [36, 37, 38, 39, 40, 41, 43, 44, 6, 15, 24, 33, 51, 60, 69, 78, 34, 35, 52, 53],
        [36, 37, 38, 39, 40, 41, 42, 44, 7, 16, 25, 34, 52, 61, 70, 79, 33, 35, 51, 53],
        [36, 37, 38, 39, 40, 41, 42, 43, 8, 17, 26, 35, 53, 62, 71, 80, 33, 34, 51, 52],

        [46, 47, 48, 49, 50, 51, 52, 53, 0, 9, 18, 27, 36, 54, 63, 72, 28, 29, 37, 38],
        [45, 47, 48, 49, 50, 51, 52, 53, 1, 10, 19, 28, 37, 55, 64, 73, 27, 29, 36, 38],
        [45, 46, 48, 49, 50, 51, 52, 53, 2, 11, 20, 29, 38, 56, 65, 74, 27, 28, 36, 37],
        [45, 46, 47, 49, 50, 51, 52, 53, 3, 12, 21, 30, 39, 57, 66, 75, 31, 32, 40, 41],
        [45, 46, 47, 48, 50, 51, 52, 53, 4, 13, 22, 31, 40, 58, 67, 76, 30, 32, 39, 41],
        [45, 46, 47, 48, 49, 51, 52, 53, 5, 14, 23, 32, 41, 59, 68, 77, 30, 31, 39, 40],
        [45, 46, 47, 48, 49, 50, 52, 53, 6, 15, 24, 33, 42, 60, 69, 78, 34, 35, 43, 44],
        [45, 46, 47, 48, 49, 50, 51, 53, 7, 16, 25, 34, 43, 61, 70, 79, 33, 35, 42, 44],
        [45, 46, 47, 48, 49, 50, 51, 52, 8, 17, 26, 35, 44, 62, 71, 80, 33, 34, 42, 43],

        [55, 56, 57, 58, 59, 60, 61, 62, 0, 9, 18, 27, 36, 45, 63, 72, 64, 65, 73, 74],
        [54, 56, 57, 58, 59, 60, 61, 62, 1, 10, 19, 28, 37, 46, 64, 73, 63, 65, 72, 74],
        [54, 55, 57, 58, 59, 60, 61, 62, 2, 11, 20, 29, 38, 47, 65, 74, 63, 64, 72, 73],
        [54, 55, 56, 58, 59, 60, 61, 62, 3, 12, 21, 30, 39, 48, 66, 75, 67, 68, 76, 77],
        [54, 55, 56, 57, 59, 60, 61, 62, 4, 13, 22, 31, 40, 49, 67, 76, 66, 68, 75, 77],
        [54, 55, 56, 57, 58, 60, 61, 62, 5, 14, 23, 32, 41, 50, 68, 77, 66, 67, 75, 76],
        [54, 55, 56, 57, 58, 59, 61, 62, 6, 15, 24, 33, 42, 51, 69, 78, 70, 71, 79, 80],
        [54, 55, 56, 57, 58, 59, 60, 62, 7, 16, 25, 34, 43, 52, 70, 79, 69, 71, 78, 80],
        [54, 55, 56, 57, 58, 59, 60, 61, 8, 17, 26, 35, 44, 53, 71, 80, 69, 70, 78, 79],

        [64, 65, 66, 67, 68, 69, 70, 71, 0, 9, 18, 27, 36, 45, 54, 72, 55, 56, 73, 74],
        [63, 65, 66, 67, 68, 69, 70, 71, 1, 10, 19, 28, 37, 46, 55, 73, 54, 56, 72, 74],
        [63, 64, 66, 67, 68, 69, 70, 71, 2, 11, 20, 29, 38, 47, 56, 74, 54, 55, 72, 73],
        [63, 64, 65, 67, 68, 69, 70, 71, 3, 12, 21, 30, 39, 48, 57, 75, 58, 59, 76, 77],
        [63, 64, 65, 66, 68, 69, 70, 71, 4, 13, 22, 31, 40, 49, 58, 76, 57, 59, 75, 77],
        [63, 64, 65, 66, 67, 69, 70, 71, 5, 14, 23, 32, 41, 50, 59, 77, 57, 58, 75, 76],
        [63, 64, 65, 66, 67, 68, 70, 71, 6, 15, 24, 33, 42, 51, 60, 78, 61, 62, 79, 80],
        [63, 64, 65, 66, 67, 68, 69, 71, 7, 16, 25, 34, 43, 52, 61, 79, 60, 62, 78, 80],
        [63, 64, 65, 66, 67, 68, 69, 70, 8, 17, 26, 35, 44, 53, 62, 80, 60, 61, 78, 79],

        [73, 74, 75, 76, 77, 78, 79, 80, 0, 9, 18, 27, 36, 45, 54, 63, 55, 56, 64, 65],
        [72, 74, 75, 76, 77, 78, 79, 80, 1, 10, 19, 28, 37, 46, 55, 64, 54, 56, 63, 65],
        [72, 73, 75, 76, 77, 78, 79, 80, 2, 11, 20, 29, 38, 47, 56, 65, 54, 55, 63, 64],
        [72, 73, 74, 76, 77, 78, 79, 80, 3, 12, 21, 30, 39, 48, 57, 66, 58, 59, 67, 68],
        [72, 73, 74, 75, 77, 78, 79, 80, 4, 13, 22, 31, 40, 49, 58, 67, 57, 59, 66, 68],
        [72, 73, 74, 75, 76, 78, 79, 80, 5, 14, 23, 32, 41, 50, 59, 68, 57, 58, 66, 67],
        [72, 73, 74, 75, 76, 77, 79, 80, 6, 15, 24, 33, 42, 51, 60, 69, 61, 62, 70, 71],
        [72, 73, 74, 75, 76, 77, 78, 80, 7, 16, 25, 34, 43, 52, 61, 70, 60, 62, 69, 71],
        [72, 73, 74, 75, 76, 77, 78, 79, 8, 17, 26, 35, 44, 53, 62, 71, 60, 61, 69, 70]
    ];

    private bool Continue = true;
    public SudokuPuzzle SudokuPuzzle { get; set; } = sudokuPuzzle;
    public SudokuSolutions SudokuSolutions { get; set; } = new();

    public SudokuSolutions SolveSudokuPuzzle()
    {
        SudokuSolutions.BeginDateTime = DateTime.Now;
        var stopWatch = Stopwatch.StartNew();
        SolveSudokuPuzzleParallel();
        stopWatch.Stop();
        SudokuSolutions.EndDateTime = DateTime.Now;
        SudokuSolutions.ElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
        return SudokuSolutions;
    }
    private void SolveSudokuPuzzleParallel()
    {
        ++SudokuSolutions.CalculationCycle;
        switch (CheckSudokuState(SudokuPuzzle.Puzzle))
        {
            case SudokuState.Unsolved:
                var index = Array.IndexOf(SudokuPuzzle.Puzzle, 0);
                var used = GetOptionsUsage(index, SudokuPuzzle.Puzzle);
                List<int> options = [];
                for (int i = 1; i < 10; i++) { if(!used[i]) options.Add(i); }
                Parallel.ForEach(options, option => { SolveSudokuPuzzle(UpdateNewSudokuNumber(index, option, SudokuPuzzle.Puzzle)); });
                break;
            case SudokuState._Invalid:
                SudokuSolutions.AddInvalidPuzzle(SudokuPuzzle.Puzzle);
                break;
            case SudokuState.__Solved:
                SudokuSolutions.AddSolution(SudokuPuzzle.Puzzle);
                if (SudokuSolutions.Solutions.Count > 0) Continue = false;
                break;
            default:
                break;
        }
    }
    private void SolveSudokuPuzzle(int[] puzzle)
    {
        if (!Continue) return;
        ++SudokuSolutions.CalculationCycle;
        var index = Array.IndexOf(puzzle, 0);
        if (index > -1)
        {
            var used = GetOptionsUsage(index, puzzle);
            if (!used[1]) SolveSudokuPuzzle(UpdateNewSudokuNumber(index, 1, puzzle));
            if (!used[2]) SolveSudokuPuzzle(UpdateNewSudokuNumber(index, 2, puzzle));
            if (!used[3]) SolveSudokuPuzzle(UpdateNewSudokuNumber(index, 3, puzzle));
            if (!used[4]) SolveSudokuPuzzle(UpdateNewSudokuNumber(index, 4, puzzle));
            if (!used[5]) SolveSudokuPuzzle(UpdateNewSudokuNumber(index, 5, puzzle));
            if (!used[6]) SolveSudokuPuzzle(UpdateNewSudokuNumber(index, 6, puzzle));
            if (!used[7]) SolveSudokuPuzzle(UpdateNewSudokuNumber(index, 7, puzzle));
            if (!used[8]) SolveSudokuPuzzle(UpdateNewSudokuNumber(index, 8, puzzle));
            if (!used[9]) SolveSudokuPuzzle(UpdateNewSudokuNumber(index, 9, puzzle));
        }
        else if (IsSudokuValid(puzzle))
        {
            SudokuSolutions.AddSolution(puzzle);
            if (SudokuSolutions.Solutions.Count > 0) Continue = false;
        }
    }
    private static bool[] GetOptionsUsage(int indexSudokuNumber, int[] puzzle)
    {
        var used = new bool[10];
        var mapping = SudokuDependencyMapping[indexSudokuNumber];
        used[puzzle[mapping[0]]] = true;
        used[puzzle[mapping[1]]] = true;
        used[puzzle[mapping[2]]] = true;
        used[puzzle[mapping[3]]] = true;
        used[puzzle[mapping[4]]] = true;
        used[puzzle[mapping[5]]] = true;
        used[puzzle[mapping[6]]] = true;
        used[puzzle[mapping[7]]] = true;
        used[puzzle[mapping[8]]] = true;
        used[puzzle[mapping[9]]] = true;
        used[puzzle[mapping[10]]] = true;
        used[puzzle[mapping[11]]] = true;
        used[puzzle[mapping[12]]] = true;
        used[puzzle[mapping[13]]] = true;
        used[puzzle[mapping[14]]] = true;
        used[puzzle[mapping[15]]] = true;
        used[puzzle[mapping[16]]] = true;
        used[puzzle[mapping[17]]] = true;
        used[puzzle[mapping[18]]] = true;
        used[puzzle[mapping[19]]] = true;
        return used;
    }
    private static int[] UpdateNewSudokuNumber(int index, int value, int[] numbers)
    {
        int[] newSudoku = new int[81];
        Array.Copy(numbers, newSudoku, 81);
        newSudoku[index] = value;
        return newSudoku;
    }
    private static SudokuState CheckSudokuState(int[] puzzle)
    {
        if (puzzle.Contains(0))
        {
            return SudokuState.Unsolved;
        }
        if (!IsSudokuValid(puzzle))
        {
            return SudokuState._Invalid;
        }
        return SudokuState.__Solved;
    }
    private static bool IsSudokuValid(int[] puzzle)
    {
        for (int indexCurrent = 0; indexCurrent < 81; indexCurrent++)
        {
            var currentNumber = puzzle[indexCurrent];
            if (currentNumber == 0) continue;
            for (int j = 0; j < 20; j++)
            {
                if (puzzle[SudokuDependencyMapping[indexCurrent][j]] == currentNumber) return false;
            }
        }
        return true;
    }
}

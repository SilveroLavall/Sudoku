﻿using SudokuSolver;

// Valid
//string puzzle = "400309000000000068070000000800040000000700100206000000000970000000086000030000500";
// string puzzle = "100008020008700140000045300003080060589207000207000009950004070000000000000000034";
// string puzzle = "034070010600190348098002567850761023426853791013924850901030284007409635005286079";
// string puzzle = "000309000000000068070000000800040000000700100206000000000970000000086000030000500";
// Invalid
//string puzzle = "175498623698723145726945318413589267589217436247136589951364872834672951362851794";

string[] puzzles = {
    "000309000000000068070000000800040000000700100206000000000970000000086000030000500",
    // "400309000000000068070000000800040000000700100206000000000970000000086000030000500",
    // "468329700000000068070000000800040000000700100206000000000970000000086000030000500",
    // "034070010600190348098002567850761023426853791013924850901030284007409635005286079",
    // "000000000008700140000045300003080060509207000207000009950004070000000000000000034"
    // "200000005070039800030000000000000000008062470006047000050600904007900032010400007"
    // "370000150080060000060000007000500060031002400009000005000004009000150280000300000"
};

foreach (var puzzle in puzzles)
{
    // var watch = new System.Diagnostics.Stopwatch();
    // Console.WriteLine("Stopwatch word gestart");
    // watch.Start();
    // var engine = new SudokuEngine(puzzle);
    // engine.SolveSudoku();
    // watch.Stop();
    // Console.WriteLine("Stopwatch is gestopt");
    // engine.DisplayPuzzle();
    // engine.DisplaySolutions();
    // Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

    var engine = new SudokuEngine(puzzle);
    engine.SolveSudoku();
}


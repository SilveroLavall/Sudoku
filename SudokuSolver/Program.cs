using SudokuSolver;

// Valid
string puzzle = "100008020008700140000045300003080060589207000207000009950004072800070901002000004";
// Valid
// string puzzle = "100008020008700140000045300003080060589207000207000009950004070000000000000000034";
// Invalid
//string puzzle = "175498623698723145726945318413589267589217436247136589951364872834672951362851794";

var watch = new System.Diagnostics.Stopwatch();
watch.Start();

var engine = new SudokuEngine(puzzle);
engine.SolveSudoku();

watch.Stop();
engine.DisplayPuzzle();
engine.DisplaySolutions();
Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

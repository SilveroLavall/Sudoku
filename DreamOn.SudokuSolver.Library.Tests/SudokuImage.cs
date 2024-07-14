using DreamOn.SudokuSolver.Scanner;

namespace DreamOn.SudokuSolver.Library.Tests;

public class SudokuImage
{
    [Fact]
    public void ScanSudokuImage()
    {
        var result = SudokuScanner.ScanAspose();
        Assert.NotNull(result);
    }
}

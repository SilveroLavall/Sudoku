﻿using DreamOn.SudokuSolver.Library.Extensions;

namespace DreamOn.SudokuSolver.Library.Tests;

public class ValidPuzzles
{
    [Theory]
    [InlineData("000309000-000000068-070000000-800040000-000700100-206000000-000970000-000086000-030000500-Benchmark", "468329715123457968975861432817642359354798126296135874582973641741586293639214587")]
    [InlineData("060080420-015060378-000400060-100604830-306010705-080350000-830940000-072130900-009020610-Easy", "763581429415269378928473561157694832396812745284357196831946257672135984549728613")]
    [InlineData("301080500-000007020-920000860-000120050-010000300-602705000-463290085-250873041-000006039-Medium", "371682594846957123925314867734128956518469372692735418463291785259873641187546239")]
    [InlineData("900000178-000700900-000090052-060013720-042080000-000050086-080000001-700102090-210500060-Hard", "926345178851726943473891652568913724342687519197254386685479231734162895219538467")]
    [InlineData("000000080-046000002-708450010-069005000-001070004-470000060-810906540-090000030-050004601-Expert", "135762489946381752728459316269145873581673924473298165812936547694517238357824691")]
    [InlineData("700010306-000000050-106703000-000000040-080000070-050609000-300000015-500070920-400005003-Master", "745218396832496157196753284613827549984531672257649831378962415561374928429185763")]
    [InlineData("400000003-008070450-090006000-000030008-001000002-600007130-004050710-800400000-000000200-Extreme-A", "417825963268973451593146827759231648381694572642587139924358716876412395135769284")]
    [InlineData("060400000-300001000-107030005-920000030-000004600-000005009-005020000-704000010-000006800-Extreme-B", "568472391342951768197638425926817534851394672473265189685123947734589216219746853")]
    [InlineData("000000000-000000000-000000000-000000000-000000000-000000000-000000000-000000000-000000000-Blanco", "123456789456789123789123456214365897365897214897214365531642978642978531978531642")]
    public void TestSudokuPuzzle(string puzzle, string expected)
    {
        var sut = new SudokuApi();
        var result = sut.SolveSudoku(puzzle);
        var actual = result.SudokuSolutions.Solutions.First().ConvertToString();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("111111111-111111111-111111111-111111111-111111111-111111111-111111111-111111111-111111111-Invalid")]
    [InlineData("111111111-111111111-111111111-111111111-111111111-111111111-111111111-111111111-111111110-Invalid")]
    [InlineData("111111111-111111111-111111111-111111111-111111111-111111111-111111111-111111111-111111100-Invalid")]
    [InlineData("000309000-000000068-070000000-800040000-000700100-206000000-000970000-000086000-03000050-Invalid")]
    [InlineData("000309000-000000068-070000000-800040000-000700100-206000000-000970000-000086000-0300005000-Invalid")]
    public void TestInvalidSudokuPuzzle(string puzzle)
    {
        var sut = new SudokuApi();
        var result = sut.SolveSudoku(puzzle);
        Assert.Empty(result.SudokuSolutions.Solutions);
    }
}

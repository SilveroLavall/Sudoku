using DreamOn.SudokuSolver.Library.Data;

namespace DreamOn.SudokuSolver.RazorSudoku.Pages;

public class SudokuModel(ILogger<SudokuModel> logger) : PageModel
{
    public class PageModelValues
    {
        public string SudokuPuzzle { get; set; } = string.Empty;
        public string SudokuSolution { get; set; } = string.Empty;
    }

    [BindProperty]
    public PageModelValues PageValues { get; set; } = new PageModelValues();

    public void OnGet()
    {
        logger.LogInformation("OnGet");
    }
    public IActionResult OnPost()
    {
        logger.LogInformation("OnPost");
        logger.LogInformation("{SudokuString}", PageValues.SudokuPuzzle);
        var response = SudokuEngine.SolveSudoku(PageValues.SudokuPuzzle);
        PageValues.SudokuPuzzle = response.Puzzle.ConvertToString();
        PageValues.SudokuSolution = response.Solutions.Count > 0
            ? response.Solutions.First().ConvertToString()
            : string.Empty;
        return Page();
    }
}

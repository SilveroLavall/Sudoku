using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DreamOn.SudokuSolver.Library;
using DreamOn.SudokuSolver.Library.Extensions;

namespace DreamOn.SudokuSolver.RazorSudoku.Pages;

public class SudokuModel : PageModel
{
    public class PageModelValues
    {
        public string SudokuPuzzle { get; set; }
        public string SudokuSolution { get; set; }

        public PageModelValues()
        {
            SudokuPuzzle = string.Empty;
            SudokuSolution = string.Empty;
        }
    }

    [BindProperty]
    public PageModelValues PageValues { get; set; }
    private readonly ILogger<SudokuModel> Logger;

    public SudokuModel(ILogger<SudokuModel> logger)
    {
        PageValues = new PageModelValues();
        Logger = logger;
    }
    public void OnGet()
    {
        Logger.LogInformation("OnGet");
    }
    public IActionResult OnPost()
    {
        Logger.LogInformation("OnGet");
        Logger.LogInformation("{SudokuString}", PageValues.SudokuPuzzle);
        var response = SudokuEngine.SolveSudoku(PageValues.SudokuPuzzle);
        PageValues.SudokuSolution = response.Solutions.First().ConvertToString();
        return Page();
    }
}

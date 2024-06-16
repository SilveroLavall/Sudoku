namespace DreamOn.SudokuSolver.RazorSudoku.Pages;

public class SudokuModel(ILogger<SudokuModel> logger) : PageModel
{
    public class PageModelValues
    {
        public string Input { get; set; } = string.Empty;
        public string SudokuPuzzle { get; set; } = string.Empty;
        public string SudokuSolution { get; set; } = string.Empty;
    }
    public class PageModelData
    {
        public SudokuResponse SudokuResponse { get; set; } = new();
    }

    [BindProperty]
    public PageModelValues PageValues { get; set; } = new PageModelValues();
    public PageModelData PageData { get; set; } = new PageModelData();

    public void OnGet()
    {
        logger.LogInformation("OnGet");
    }
    public IActionResult OnPost()
    {
        logger.LogInformation("OnPost");
        logger.LogInformation("{SudokuString}", PageValues.SudokuPuzzle);
        PageData.SudokuResponse = SudokuEngine.SolveSudoku(PageValues.Input);
        PageValues.Input = PageData.SudokuResponse.SudokuRequest.Input;
        PageValues.SudokuPuzzle = PageData.SudokuResponse.SudokuRequest.Puzzle.ConvertToString();
        PageValues.SudokuSolution = PageData.SudokuResponse.Solutions.Count > 0
            ? PageData.SudokuResponse.Solutions[0].ConvertToString()
            : string.Empty;
        return Page();
    }
}

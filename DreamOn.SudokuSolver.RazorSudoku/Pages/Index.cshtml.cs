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
        public string[] SudokuPuzzleOptions { get; set; } =
        [
            "000000000-000000000-000000000-000000000-000000000-000000000-000000000-000000000-000000000-Blanco",
            "111111111-111111111-111111111-111111111-111111111-111111111-111111111-111111111-111111111-Invalid",
            "060080420-015060378-000400060-100604830-306010705-080350000-830940000-072130900-009020610-Easy",
            "060400000-300001000-107030005-920000030-000004600-000005009-005020000-704000010-000006800-Extreme-B",
            "000309000-000000068-070000000-800040000-000700100-206000000-000970000-000086000-030000500-Benchmark"
        ];
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

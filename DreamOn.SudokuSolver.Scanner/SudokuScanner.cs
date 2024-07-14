//using IronOcr;
using Aspose.OCR;

namespace DreamOn.SudokuSolver.Scanner;

public class SudokuScanner
{
    //public static string ScanSudokuImage()
    //{
    //    IronOcr.License.LicenseKey = "IRONSUITE.S.VAN.HENNINGEN.QUANTIX.NL.24440-1AE9C47FF8-GLP3W-PBCU2HFAWQ3G-3MS6DTQTEBDK-XL3BMAE2TY62-FMG3SNOBWQD3-CYBA6GAZDFOV-O2RDARNZXQC3-CXDHAW-T5PVHRU3IK2NEA-DEPLOYMENT.TRIAL-TIKT3K.TRIAL.EXPIRES.12.AUG.2024";

    //    var scanner = new IronTesseract();
    //    scanner.Language = OcrLanguage.Financial;
    //    scanner.Configuration.WhiteListCharacters = " 0123456789";

    //    using var ocrInput = new OcrImageInput(@"Images\Sudoku_20240713155045.png");
    //    //ocrInput.DeNoise();
    //    //ocrInput.Deskew();
    //    ocrInput.Erode();
    //    ocrInput.Binarize();
    //    ocrInput.Close();
    //    //ocrInput.Invert();
    //    //ocrInput.ToGrayScale();

    //    var ocrResult = scanner.Read(ocrInput);
    //    return ocrResult.Text;

    //    //string codeToRun = OcrInputFilterWizard.Run(@"Images\Sudoku_20240713155045.png", out double confidence, scanner);
    //    //return codeToRun;
    //}

    public static string ScanAspose()
    {
        AsposeOcr api = new AsposeOcr();
        OcrInput input = new OcrInput(InputType.SingleImage);
        input.Add(@"Images\Sudoku_20240713155045.png");
        List<RecognitionResult> result = api.Recognize(input);
            //, new RecognitionSettings
        //{
        //    RecognizeSingleLine = true,
        //    AllowedSymbols = "0123456789"
        //});
        return result[0].RecognitionText;
    }
}

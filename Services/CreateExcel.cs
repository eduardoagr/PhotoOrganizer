namespace PhotoOrganizer.Services;

public class CreateExcel : ICreateExcel {
    //public async Task<string> CreateExcelSheet(IEnumerable<Photo> notes) {

    //    var fileName = $"PhotoOrganizer_Notes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
    //    var filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

    //    using var workbook = new XLWorkbook();
    //    var worksheet = workbook.Worksheets.Add("Photo Notes");

    //    // Headers
    //    worksheet.Cell(1, 1).Value = "Id";
    //    worksheet.Cell(1, 2).Value = "Title";
    //    worksheet.Cell(1, 3).Value = "Description";
    //    worksheet.Cell(1, 4).Value = "Location";
    //    worksheet.Cell(1, 5).Value = "Tag Name";
    //    worksheet.Cell(1, 6).Value = "Created At";

    //    // Header style
    //    var header = worksheet.Range(1, 1, 1, 6);
    //    header.Style.Font.Bold = true;
    //    header.Style.Font.FontColor = XLColor.White;
    //    header.Style.Fill.BackgroundColor = XLColor.FromHtml("#5865D9");

    //    int row = 2;

    //    //foreach(var note in notes) {
    //    //    worksheet.Cell(row, 1).Value = note.Id;
    //    //    worksheet.Cell(row, 2).Value = note.Title;
    //    //    worksheet.Cell(row, 3).Value = note.Description;
    //    //    worksheet.Cell(row, 4).Value = note.LocationDescription;
    //    //    worksheet.Cell(row, 5).Value =
    //    //        await database.GetTagNameAsync(note.TagId) ?? "Unknown";
    //    //    worksheet.Cell(row, 6).Value = note.CreatedAt;

    //    //    row++;
    //    //}

    //    //worksheet.Columns().AdjustToContents();
    //    //worksheet.SheetView.FreezeRows(1);
    //    //worksheet.RangeUsed()?.SetAutoFilter();

    //    //workbook.SaveAs(filePath);

    //    //return filePath;
    public Task<string> CreateExcelSheet(IEnumerable<Photo> notes) {
        throw new NotImplementedException();
    }
}

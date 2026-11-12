namespace PhotoOrganizer.Interfaces;

public interface ICreateExcel {

    Task<string> CreateExcelSheet(IEnumerable<Photo> notes);
}

using ClosedXML.Excel;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Services;


namespace RanjaKen.Infrastructure.Persistences.Services
{
    public class ExcelService : IExcelService
    {
        public byte[] ExportPlayerExcel(IEnumerable<Player> players)
        {
            XLWorkbook workbook = new ();
            var worksheet = workbook.Worksheets.Add("Players");

            // Header
            worksheet.Cell(1, 1).Value = "FirstName";
            worksheet.Cell(1, 2).Value = "LastName";
            worksheet.Cell(1, 3).Value = "Age";
            worksheet.Cell(1, 4).Value = "Pseudo";
            worksheet.Cell(1, 5).Value = "Idole";
            worksheet.Cell(1, 6).Value = "Size";
            worksheet.Cell(1, 7).Value = "Created At";

            int row = 2;
            foreach (var p in players)
            {
                worksheet.Cell(row, 1).Value = p.LastName;
                worksheet.Cell(row, 2).Value = p.FirstName;
                worksheet.Cell(row, 3).Value = p.Age;
                worksheet.Cell(row, 4).Value = p.Pseudo;
                worksheet.Cell(row, 5).Value = p.Idole;
                worksheet.Cell(row, 6).Value = p.Size;    
                row++;
            }

            using MemoryStream stream = new();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}

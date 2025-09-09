using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Ranjaken.Domain.Entities;
using Ranjaken.Domain.Interfaces.Services;


namespace RanjaKen.Infrastructure.Persistences.Services
{
    public class ExcelService : IExcelService
    {
        public byte[] ExportPlayerExcel(IEnumerable<Player> players)
        {
            XLWorkbook workbook = new ();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Players");

            // Header
            string[] headers = { "FirstName", "LastName", "Age", "Idole","Pseudo", "Size", "Created At" };
            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = headers[i];
                worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightBlue;
            }
            int row = 2;
            foreach (Player p in players)
            {
                worksheet.Cell(row, 1).Value = p.LastName;
                worksheet.Cell(row, 2).Value = p.FirstName;
                worksheet.Cell(row, 3).Value = p.Age;
                worksheet.Cell(row, 4).Value = p.Idole;
                worksheet.Cell(row, 5).Value = p.Pseudo;
                worksheet.Cell(row, 6).Value = p.Size;
                worksheet.Cell(row, 7).Value = p.CreatedAt;
                worksheet.Cell(row, 7).Style.DateFormat.Format = "yyyy-MM-dd HH:mm:ss";
                row++;
            }
            worksheet.Columns().AdjustToContents();

            using MemoryStream stream = new();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}

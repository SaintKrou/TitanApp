using System;
using System.Windows.Forms;
using ClosedXML.Excel;

public static class ExportHelper
{
    /// <summary>
    /// Exports visible (filtered) data from a DataGridView to an Excel file using ClosedXML.
    /// </summary>
    /// <param name="dgv">The DataGridView containing data to export.</param>
    public static void ExportDataGridViewToExcel(DataGridView dgv)
    {
        try
        {
            // Create a new Excel workbook
            using (var workbook = new XLWorkbook())
            {
                // Add a worksheet
                var ws = workbook.Worksheets.Add("Sheet1");

                int rowIndex = 1;
                int colIndex;

                // Write column headers (bold font)
                colIndex = 1;
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (!column.Visible) continue; // skip hidden columns
                    ws.Cell(rowIndex, colIndex).Value = column.HeaderText;
                    ws.Cell(rowIndex, colIndex).Style.Font.Bold = true; // Жирный шрифт заголовков:contentReference[oaicite:0]{index=0}
                    colIndex++;
                }

                // Write row data for each visible row
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.Visible || row.IsNewRow) continue; // skip hidden or new rows
                    rowIndex++;
                    colIndex = 1;
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (!column.Visible) continue;
                        var cellValue = row.Cells[column.Index].Value;
                        if (cellValue != null)
                        {
                            if (cellValue is DateTime dateVal)
                            {
                                // Write date and format as dd.MM.yyyy
                                ws.Cell(rowIndex, colIndex).Value = dateVal;
                                ws.Cell(rowIndex, colIndex).Style.DateFormat.Format = "dd.MM.yyyy"; // Формат даты dd.MM.yyyy:contentReference[oaicite:1]{index=1}
                            }
                            else
                            {
                                // Try to write numeric or text
                                if (double.TryParse(cellValue.ToString(), out double d))
                                {
                                    ws.Cell(rowIndex, colIndex).Value = d; // числовые (выравниваются вправо по умолчанию):contentReference[oaicite:2]{index=2}
                                }
                                else
                                {
                                    ws.Cell(rowIndex, colIndex).Value = cellValue.ToString();
                                }
                            }
                        }
                        colIndex++;
                    }
                }

                // Auto-adjust column widths to fit content:contentReference[oaicite:3]{index=3}
                ws.Columns().AdjustToContents();

                // Prompt user to save the file (.xlsx)
                var sfd = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Save as Excel File"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName); // Save workbook to selected path:contentReference[oaicite:4]{index=4}
                }
            }
        }
        catch (Exception ex)
        {
            // Show error message if something goes wrong
            MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

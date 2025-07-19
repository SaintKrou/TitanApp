using System;
using System.Windows.Forms;
using ClosedXML.Excel;

public static class ExportHelper
{
    public static void ExportDataGridViewToExcel(DataGridView dgv)
    {
        try
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Sheet1");

                int rowIndex = 1;
                int colIndex;

                colIndex = 1;
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (!column.Visible) continue;
                    ws.Cell(rowIndex, colIndex).Value = column.HeaderText;
                    ws.Cell(rowIndex, colIndex).Style.Font.Bold = true; 
                    colIndex++;
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.Visible || row.IsNewRow) continue;
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
                                ws.Cell(rowIndex, colIndex).Value = dateVal;
                                ws.Cell(rowIndex, colIndex).Style.DateFormat.Format = "dd.MM.yyyy";
                            }
                            else
                            {
                                if (double.TryParse(cellValue.ToString(), out double d))
                                {
                                    ws.Cell(rowIndex, colIndex).Value = d; 
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

                ws.Columns().AdjustToContents();

                var sfd = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Save as Excel File"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName); 
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

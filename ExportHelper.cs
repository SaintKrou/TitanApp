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
        if (dgv == null || dgv.Rows.Count == 0)
        {
            MessageBox.Show("Нет данных для экспорта.", "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Sheet1");

                int rowIndex = 1;
                int colIndex = 1;

                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (!column.Visible) continue;
                    ws.Cell(rowIndex, colIndex).Value = column.HeaderText;
                    ws.Cell(rowIndex, colIndex).Style.Font.Bold = true;
                    colIndex++;
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow || !row.Visible) continue;

                    rowIndex++;
                    colIndex = 1;

                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (!column.Visible) continue;

                        var value = row.Cells[column.Index].Value;

                        if (value == null || value == DBNull.Value)
                        {
                            colIndex++;
                            continue;
                        }

                        var cell = ws.Cell(rowIndex, colIndex);

                        switch (value)
                        {
                            case DateTime dateVal:
                                cell.Value = dateVal;
                                cell.Style.DateFormat.Format = "dd.MM.yyyy";
                                break;
                            case int or long or double or float or decimal:
                                cell.Value = Convert.ToDouble(value);
                                break;
                            default:
                                cell.Value = value.ToString();
                                break;
                        }

                        colIndex++;
                    }
                }

                ws.Columns().AdjustToContents();

                using (var sfd = new SaveFileDialog
                {
                    Filter = "Excel файлы (*.xlsx)|*.xlsx",
                    Title = "Сохранить как Excel",
                    FileName = "Экспорт.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Экспорт завершён успешно.", "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при экспорте:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

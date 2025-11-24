using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace HayvanBarınma.Repositories
{
    public static class DataExportHelperXlsx
    {
        public static void ExportDataGridViewToXlsx(DataGridView dgv)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Export yapılacak veri bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
            sfd.Title = "Verileri Kaydet";
            sfd.FileName = "Islem_Raporu_" + DateTime.Now.ToString("yyyy_MM_dd_HH.mm");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("İşlemler Raporu");
                        int currentRow = 1;

                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            worksheet.Cell(currentRow, i + 1).Value = dgv.Columns[i].HeaderText;
                        }

                        worksheet.Row(currentRow).Style.Font.Bold = true;
                        worksheet.Row(currentRow).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;


                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;

                            currentRow++;
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                object cellValue = row.Cells[i].Value;

                                if (cellValue is DateTime dt)
                                {
                                    worksheet.Cell(currentRow, i + 1).Value = dt;
                                    worksheet.Cell(currentRow, i + 1).Style.DateFormat.SetFormat("dd.MM.yyyy hh:mm:ss");
                                }
                                else
                                {
                                    worksheet.Cell(currentRow, i + 1).Value = cellValue?.ToString() ?? string.Empty;
                                }
                            }
                        }

                        worksheet.Cells().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                        worksheet.Columns().AdjustToContents();



                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Veriler Excel (XLSX) formatında başarıyla dışa aktarıldı. Biçimlendirme ve sütun genişlikleri ayarlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dışa aktarma sırasında bir hata oluştu." + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

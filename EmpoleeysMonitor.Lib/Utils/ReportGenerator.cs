using EmployeesMonitor.Lib.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace EmpoleeysMonitor.Lib
{
    public static class ReportGenerator
    {
        public static void GenerateReport(string filename, IEnumerable<UserAction> actions, GroupingType groupType, User user, Project project, DateTime start, DateTime end)
        {
            DataTable table = CreateData(actions, groupType, start, end);
            PdfPTable pdfTable = ConvertToPdfTable(table);

            using (FileStream output = new FileStream(filename, FileMode.Create))
            {
                Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(doc, output);
                doc.Open();
                doc.Add(new Paragraph("Employee: " + user.Name + " " + user.Surname));
                doc.Add(new Paragraph("Project: " + project.Name));
                doc.Add(new Paragraph("Time period: " + start.ToString() + "-" + end.ToString()));
                doc.Add(new Paragraph(Environment.NewLine));
                doc.Add(pdfTable);
                doc.Close();
                writer.Close();
            }
        }

        public static DateTime GetGroupEndDate(DateTime start, GroupingType groupType)
        {
            switch (groupType)
            {
                case GroupingType.Quarter: return start.AddMinutes(15);
                case GroupingType.Day: return start.AddDays(1);
                case GroupingType.Hour: return start.AddHours(1);
                case GroupingType.Month: return start.AddMonths(1);
                case GroupingType.Week: return start.AddDays(7);
            }

            return DateTime.UtcNow;
        }

        private static DataTable CreateData(IEnumerable<UserAction> actions, GroupingType groupType, DateTime start, DateTime end)
        {
            DataTable dataTable = new DataTable();

            if (groupType != GroupingType.None)
            {
                dataTable.Columns.Add("Action", typeof(string));
                dataTable.Columns.Add("Period", typeof(string));
                dataTable.Columns.Add("Count", typeof(int));

                DateTime groupStartDate = start;
                DateTime groupEndDate = GetGroupEndDate(start, groupType);

                do
                {
                    var periodActions = actions.Where(action => action.Date > groupStartDate && action.Date < groupEndDate).GroupBy(action => action.ActionType);
                    foreach (var groupedActions in periodActions)
                    {
                        dataTable.Rows.Add(Enum.GetName(typeof(ActionType), groupedActions.Key), groupStartDate.ToString() + "-" + groupEndDate.ToString(), groupedActions.Count());
                    }
                    groupStartDate = groupEndDate;
                    groupEndDate = GetGroupEndDate(groupEndDate, groupType);
                }
                while (groupEndDate < end);
            }
            else
            {
                dataTable.Columns.Add("Action", typeof(string));
                dataTable.Columns.Add("Time", typeof(DateTime));
                dataTable.Columns.Add("Information", typeof(string));

                foreach (var action in actions)
                {
                    dataTable.Rows.Add(Enum.GetName(typeof(ActionType), action.ActionType), action.Date, action.Info ?? string.Empty);
                }
            }

            return dataTable;
        }

        private static PdfPTable ConvertToPdfTable(DataTable dataTable)
        {
            PdfPTable table = new PdfPTable(dataTable.Columns.Count);

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                string cellText = dataTable.Columns[i].ColumnName;
                PdfPCell cell = new PdfPCell();
                cell.Phrase = new Phrase(cellText, new Font(Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"))));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#990000"));

                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingBottom = 5;
                table.AddCell(cell);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    string cellText = dataTable.Rows[i].ItemArray[j].ToString();
                    PdfPCell cell = new PdfPCell();
                    cell.Phrase = new Phrase(cellText, new Font(Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 5;
                    table.AddCell(cell);
                }
            }

            return table;
        }
    }
}

using EmployeesMonitor.Lib.Model;
using EmpoleeysMonitor.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeesMonitor
{
    public partial class ReportForm : Form
    {
        private User user;
        private Project project;
        private GroupingType groupType;
        private DateTime start;
        private DateTime end;

        public ReportForm(User user, Project project, GroupingType groupType, DateTime start, DateTime end)
        {
            InitializeComponent();
            this.user = user;
            this.project = project;
            this.groupType = groupType;
            this.start = start;
            this.end = end;

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Enum.GetValues(typeof(ActionType)).Cast<ActionType>().Select(x => (object)x).ToArray());
            this.chart1.Series["Counts"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
        }

        public void RefreshReportData(List<DateTime> xAxisData, List<int> yAxisData)
        {
            this.chart1.Series["Counts"].Points.Clear();

            int i = -1;
            xAxisData.ForEach( x => {
                i++;
                this.chart1.Series["Counts"].Points.AddXY(x, yAxisData[i]);
            });
            
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex <0)
            {
                return;
            }

            List<DateTime> xData = new List<DateTime>();
            List<int> yData = new List<int>();
            ActionType type = (ActionType) this.comboBox1.SelectedItem;
            IList<UserAction> actions = await Controller.Instance.Connector.GetDataToReport(user.UserId, project.ProjectId, start, end, type);
            DateTime groupStartDate = start;
            DateTime groupEndDate = ReportGenerator.GetGroupEndDate(start, groupType);

            do
            {
                var periodActions = actions.Where(action => action.Date > groupStartDate && action.Date < groupEndDate).ToList();
                xData.Add(groupStartDate);
                yData.Add(periodActions.Count);

                groupStartDate = groupEndDate;
                groupEndDate = ReportGenerator.GetGroupEndDate(groupEndDate, groupType);
            }
            while (groupEndDate < end);

            RemoveEmptyEntries(ref xData, ref yData);
            this.RefreshReportData(xData, yData);
        }

        private static void RemoveEmptyEntries(ref List<DateTime> xData, ref List<int> yData)
        {
            for (int i = 0; i < yData.Count; ++i)
            {
                if (yData[i] != 0)
                {
                    xData = xData.GetRange(i, xData.Count - i);
                    yData = yData.GetRange(i, yData.Count - i);
                    break;
                }
            }

            for (int i = yData.Count - 1; i >= 0; --i)
            {
                if (yData[i] != 0)
                {
                    xData = xData.GetRange(0, i + 1);
                    yData = yData.GetRange(0, i + 1);
                    break;
                }
            }
        }
    }
}

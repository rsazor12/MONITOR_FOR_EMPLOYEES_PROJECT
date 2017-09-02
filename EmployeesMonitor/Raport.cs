using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpoleeysMonitor.Lib.Model;

namespace EmployeesMonitor
{
    public partial class Raport : Form
    {
        public MonitorType selectedMonitorType;

        public Raport()
        {
            InitializeComponent();
        }

        public void refreshRaportData(List<int> xAxisData, List<int> yAxisData)
        {
            //first clean old Raport Data
            this.chart1.Series["Series6"].Points.Clear();


            int i = -1;

            xAxisData.ForEach( x => {
                i++;
                this.chart1.Series["Series6"].Points.AddXY(x, yAxisData[i]);
            });
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedMonitorType = (MonitorType)this.comboBox1.SelectedIndex;

            this.refreshRaportData(Controller.Instance.Connector.getDataToChart(this.selectedMonitorType).Keys.ToList<int>(), Controller.Instance.Connector.getDataToChart(this.selectedMonitorType).Values.ToList<int>());

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot.WinForms;
using DecisionSystemForRealEastateInvestment.Application.DataManagement;
using System.Security;
using ScottPlot.Plottables;

namespace DecisionSystemForRealEastateInvestment.Presentation
{
    public partial class VisualizationView : Form
    {
        public VisualizationView()
        {
            InitializeComponent();

        }

        public void FillChart(List<DataModel> results)
        {
            FormsPlot plot = new FormsPlot() { Dock = DockStyle.Fill };
            for (int i = 0; i < results.Count; i++)
            {
                plot.Plot.Add.Marker(results[i].Area ?? 0, results[i].Price ?? 0, size: 5);
            }
                       
            plot.Plot.XLabel("Area");
            plot.Plot.YLabel("Price");
            plot.Plot.Title("Price vs Area");
            chartPanel.Controls.Add(plot);

            FormsPlot plot2 = new FormsPlot() { Dock = DockStyle.Fill };
            
            for (int i = 0; i < results.Count; i++)
            {
                plot2.Plot.Add.Marker(results[i].Price ?? 0, results[i].RoomsCount ?? 0, size: 5);
            }
            plot2.Plot.XLabel("Price");
            plot2.Plot.YLabel("Number of Rooms");
            plot2.Plot.Title("Price Histogram");
            priceHistPanel.Controls.Add(plot2);

            FormsPlot plot3 = new FormsPlot() { Dock = DockStyle.Fill };
            for (int i = 0; i < results.Count; i++)
            {
                plot3.Plot.Add.Marker(results[i].Area ?? 0, results[i].RoomsCount ?? 0, size: 5);
            }
            plot3.Plot.XLabel("Area");
            plot3.Plot.YLabel("Number of Rooms");
            plot3.Plot.Title("Area Histogram");
            AreaHistPanel.Controls.Add(plot3);

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VisualizationView_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;

namespace COSI1
{
    public partial class GraphBuilder : Window
    {
        public GraphBuilder()
        {
            InitializeComponent();
            this.Loaded += WindowLoaded;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Chart.ChartAreas.Add(new ChartArea("Default"));

            Chart.Series.Add(new Series("Series1"));
            Chart.Series["Series1"].ChartArea = "Default";
            Chart.Series["Series1"].ChartType = SeriesChartType.Line;

            List<double> xData = new List<double>();
            List<double> yData = new List<double>();
            for (double i = 0; i < 2000; i++)
            {
                xData.Add(i/100);
                yData.Add(Math.Cos(3 * i/100) + Math.Sin(2 * i/100));
            }
            Chart.Series["Series1"].Points.DataBindXY(xData, yData);
        }
    }
}

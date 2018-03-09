using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fourier.ViewModels
{
    public class GraphViewModel 
    {
        private PlotModel plotModel;

        public PlotModel PlotModel
        {
            get { return plotModel; }
        }

        public GraphViewModel()
        {
            plotModel = new PlotModel();
            plotModel.Series.Add(new LineSeries());
        }

        public void UpdateGraph(int N)
        {
            Complex x = 0;
            DataPoint point;
            double step = 2 * Math.PI / N;
            (plotModel.Series[0] as LineSeries).Points.Clear();

            for (int i = 0; i < N; i++)
            {
                point = new DataPoint(x.Real, Signal.GetValue(x).Real);
                (plotModel.Series[0] as LineSeries).Points.Add(point);
                x += step;
            }
            plotModel.InvalidatePlot(true);
        }
    }
}

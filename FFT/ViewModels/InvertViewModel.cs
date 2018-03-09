using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fourier.ViewModels
{
    public class InvertViewModel
    {
        private PlotModel plotModelFFT, plotModelDFT;

        public PlotModel PlotModelFFT
        {
            get { return plotModelFFT; }
        }

        public PlotModel PlotModelDFT
        {
            get { return plotModelDFT; }
        }

        public InvertViewModel()
        {
            plotModelFFT = new PlotModel();
            plotModelDFT = new PlotModel();
            plotModelFFT.Series.Add(new LineSeries());
            plotModelDFT.Series.Add(new LineSeries());
        }

        public void UpdateFFT(int N)
        {
            FFT fft = new FFT();
            List<Complex> input = new List<Complex>(Signal.GetArray(N));
            List<Complex> fftResult = new List<Complex>(fft.GetResult(input.ToArray(), true));
            List<Complex> fftInvert = new List<Complex>(fft.GetResult(fftResult.ToArray(), false));
            double step = 2 * Math.PI / N;
            Complex x = 0;
            (plotModelFFT.Series[0] as LineSeries).Points.Clear();
            for (int i = 0; i < N; i++)
            {
                (plotModelFFT.Series[0] as LineSeries).Points.Add(new DataPoint(x.Real, fftInvert[i].Real));
                x += step;
            }
            plotModelFFT.InvalidatePlot(true);
        }

        public void UpdateDFT(int N)
        {
            DFT dft = new DFT();
            List<Complex> input = new List<Complex>(Signal.GetArray(N));
            List<Complex> dftResult = new List<Complex>(dft.GetResult(input.ToArray(), true));
            List<Complex> dftInvert = new List<Complex>(dft.GetResult(dftResult.ToArray(), false));
            double step = 2 * Math.PI / N;
            Complex x = 0;
            (plotModelDFT.Series[0] as LineSeries).Points.Clear();
            for (int i = 0; i < N; i++)
            {
                (plotModelDFT.Series[0] as LineSeries).Points.Add(new DataPoint(x.Real, dftInvert[i].Real));
                x += step;
            }
            plotModelDFT.InvalidatePlot(true);
        }
    }
}

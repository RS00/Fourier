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
    public class AmplitudeFrequencyViewModel
    {
        private PlotModel plotModelFFTA, plotModelFFTF, plotModelDFTA, plotModelDFTF;

        public PlotModel PlotModelFFTA
        {
            get
            {
                return plotModelFFTA;
            }
        }
        public PlotModel PlotModelFFTF
        {
            get
            {
                return plotModelFFTF;
            }
        }
        public PlotModel PlotModelDFTA
        {
            get
            {
                return plotModelDFTA;
            }
        }
        public PlotModel PlotModelDFTF
        {
            get
            {
                return plotModelDFTF;
            }
        }

        public AmplitudeFrequencyViewModel()
        {
            plotModelFFTA = new PlotModel();
            plotModelFFTF = new PlotModel();
            plotModelDFTA = new PlotModel();
            plotModelDFTF = new PlotModel();

            plotModelFFTA.Series.Add(new LineSeries());
            plotModelFFTF.Series.Add(new LineSeries());
            plotModelDFTA.Series.Add(new LineSeries());
            plotModelDFTF.Series.Add(new LineSeries());
        }

        public int UpdateFFT(int N)
        {
            FFT fft = new FFT();
            List<Complex> fftResult = new List<Complex>();
            Complex x = 0;
            fftResult = new List<Complex>(fft.GetResult(Signal.GetArray(N), true));
            double step = 2 * Math.PI / N;

            (plotModelFFTA.Series[0] as LineSeries).Points.Clear();
            (plotModelFFTF.Series[0] as LineSeries).Points.Clear();
            for (int i = 0; i < N; i++)
            {
                (plotModelFFTA.Series[0] as LineSeries).Points.Add(new DataPoint(x.Real, fftResult[i].Magnitude));
                (plotModelFFTF.Series[0] as LineSeries).Points.Add(new DataPoint(x.Real, fftResult[i].Phase));
                x += step;
            }
            plotModelFFTA.InvalidatePlot(true);
            plotModelFFTF.InvalidatePlot(true);
            return fft.Count;
        }

        public int UpdateDFT(int N)
        {
            DFT dft = new DFT();
            List<Complex> dftResult = new List<Complex>();
            Complex x = 0;
            dftResult = new List<Complex>(dft.GetResult(Signal.GetArray(N), true));
            double step = 2 * Math.PI / N;

            (plotModelDFTA.Series[0] as LineSeries).Points.Clear();
            (plotModelDFTF.Series[0] as LineSeries).Points.Clear();
            for (int i = 0; i < N; i++)
            {
                (plotModelDFTA.Series[0] as LineSeries).Points.Add(new DataPoint(x.Real, dftResult[i].Magnitude));
                (plotModelDFTF.Series[0] as LineSeries).Points.Add(new DataPoint(x.Real, dftResult[i].Phase));
                x += step;
            }
            plotModelDFTA.InvalidatePlot(true);
            plotModelDFTF.InvalidatePlot(true);
            return dft.Count;
        }
    }
}

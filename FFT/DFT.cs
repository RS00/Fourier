using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fourier
{
    class DFT
    {
        public Int32 Count { get; private set; }
        public Complex[] GetResult(Complex[] inputValues, bool dir)
        {
            Count = 0;
            int N = inputValues.Length;
            Complex[] outputValues = new Complex[N];
            int ang = dir ? 1 : -1;
            for (int k = 0; k < N; k++)
            {
                for (int m = 0; m < N; m++)
                {
                    outputValues[k] += (inputValues[m] * Complex.Exp(ang * 2 * Math.PI * Complex.ImaginaryOne * k * m / N));
                    /////////////
                    Count++;
                    ////////////
                }
                if (dir)
                    outputValues[k] /= N;
            }
            return outputValues;
        }
    }
}

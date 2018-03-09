using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fourier
{
    class Signal
    {
        public static Complex GetValue(Complex X)
        {
            return Complex.Cos(3 * X) + Complex.Sin(2 * X);
        }

        public static Complex[] GetArray(int N)
        {
            List<Complex> functionResult = new List<Complex>();
            double step = 2 * Math.PI / N;
            Complex x = 0;
            for (int i = 0; i < N; i++)
            {
                functionResult.Add(Signal.GetValue(x));
                x += step;
            }
            return functionResult.ToArray<Complex>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Fourier
{
    class FFT
    {
        public Int32 Count { get; private set; }

        public Complex[] GetResult(Complex[] ar, bool dir)
        {
            Count = 0;
            return Calculate(ar, dir);
        }

        private Complex[] Calculate(Complex[] ar, bool dir)
        {
            int size = ar.Length;
            if (ar.Length == 1)
                return ar;
            else
            {
                Complex[] x_even = new Complex[size / 2];
                Complex[] x_odd = new Complex[size / 2];
                for (int i = 0; i < size / 2; i++)
                {
                    x_even[i] = ar[2 * i];
                    x_odd[i] = ar[2 * i + 1];
                }
                Complex[] X_even = Calculate(x_even, dir);
                Complex[] X_odd = Calculate(x_odd, dir);

                Complex[] result = new Complex[size];
                int ang = dir ? 1 : -1;
                Complex wn = new Complex(Math.Cos(ang * 2 * Math.PI / size), Math.Sin(ang * 2 * Math.PI / size));
                Complex w = 1;
                for (int i = 0; i < size / 2; i++)
                {
                    result[i] = X_even[i] + w * X_odd[i];
                    result[i + size / 2] = X_even[i] - w * X_odd[i];
                    if (!dir)
                    {
                        result[i] /= 2;
                        result[i + size / 2] /= 2;
                    }
                    w = w * wn;
                    Count++;
                }
                return result;
            }            
        }
    }
}

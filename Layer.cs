using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Layer
    {
        public int DimIn { get { return _W.GetLength(0); } }
        public int DimOut { get { return _W.GetLength(1); } }
        public double[,] W { get { return _W; } set { _W = value; } }
        public double[] b { get { return _b; } set { _b = value; } }

        private double[,] _W;
        private double[] _b;
        private Activation _activation;

        public Layer(int dimIn, int dimOut, Activation activation = null)
        {
            _W = new double[dimIn, dimOut];
            _b = new double[dimOut];
            _activation = activation;
        }

        public List<double[]> Forward(List<double[]> X)
        {
            List<double[]> output = new List<double[]>();
            int dimIn = DimIn;
            int dimOut = DimOut;
            for (int i = 0; i < X.Count; i++)
            {
                double[] o = new double[dimOut];
                for (int k = 0; k < dimOut; k++)
                {
                    for (int j = 0; j < dimIn; j++)
                    {
                        o[k] += X[i][j] * _W[j, k];
                    }
                    o[k] += _b[k];
                    if (_activation != null)
                        o[k] = _activation.Activate(o[k]);
                }
                output.Add(o);
            }
            return output;
        }
    }
}

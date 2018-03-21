using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    abstract class Activation
    {
        public abstract List<double[]> Forward(List<double[]> X);
        public abstract double Activate(double x);
    }

    class Sigmoid : Activation
    {
        public override List<double[]> Forward(List<double[]> X)
        {
            List<double[]> output = new List<double[]>();
            int dim = X.First().Length;
            for (int i = 0; i < X.Count; i++)
            {
                double[] x = new double[dim];
                for (int j = 0; j < dim; j++)
                {
                    x[j] = 1.0 / (1.0 + Math.Exp(-X[i][j]));
                }
                output.Add(x);
            }
            return output;
        }

        public override double Activate(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }
    }
}

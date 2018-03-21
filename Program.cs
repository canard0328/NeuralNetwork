using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test()
        {
            NeuralNetwork nw = new NeuralNetwork();

            // 1st layer with sigmoid activation function
            Layer l = new Layer(3, 2, new Sigmoid());
            l.W = new double[,] { { 1.0, 2.0 }, { 2.0, 3.0 }, { 3.0, 1.0 } };
            l.b = new double[] { 2.0, 1.0 };
            nw.AddLayer(l);
            
            // 2nd layer without activation function
            l = new Layer(2, 2);
            l.W = new double[,] { { -2.0, -1.0 }, { -1.0, -2.0 } };
            l.b = new double[] { -1.0, -2.0 };
            nw.AddLayer(l);

            List<double[]> input = new List<double[]>();
            double[] x = new double[] { 1.0, 2.0, 3.0 };
            input.Add(x);
            x = new double[] { -3.0, -2.0, -1.0 };
            input.Add(x);

            // Forward propagation
            List<double[]> output = nw.Predict(input);

            foreach (var o in output)
            {
                foreach (var y in o)
                    Console.Write("{0} ", y);
                Console.WriteLine();
            }
            Console.ReadKey();
            // -4 -5
            // -1 -2
        }
    }
}

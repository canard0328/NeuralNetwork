using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class NeuralNetwork
    {
        private List<Layer> _layers;

        public NeuralNetwork()
        {
            _layers = new List<Layer>();
        }

        public void AddLayer(Layer layer)
        {
            _layers.Add(layer);
        }

        public List<double[]> Predict(List<double[]> X)
        {
            List<double[]> input = X;
            for (int i = 0; i < _layers.Count; i++)
            {
                input = _layers[i].Forward(input);
            }
            return input;
        }
    }
}

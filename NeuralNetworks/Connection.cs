using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    class Connection
    {
        public Connection(Neuron neuron, double weight)
        {
            Neuron = neuron;
            Weight = weight;
        }

        private Neuron Neuron { get; }

        private double Weight { get; set; }

        public void AddWeight(double weightDelta) => Weight += weightDelta;

        public double Value => Neuron.Value * Weight;
    }
}

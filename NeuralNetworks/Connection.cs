using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    class Connection
    {
        private double weight;

        public Connection(Neuron neuron, double weight)
        {
            Neuron = neuron;
            this.weight = weight;
        }

        public void AddWeight(double weightDelta) => weight += weightDelta;

        public double Value => Neuron.Value * weight;

        public Neuron Neuron { get; }
    }
}

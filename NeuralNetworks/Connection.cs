using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    class Connection
    {
        private Neuron neuron;
        private double weight;

        public Connection(Neuron neuron, double weight)
        {
            this.neuron = neuron;
            this.weight = weight;
        }

        public double GetValue()
        {
            return neuron.GetValue() * weight;
        }
    }
}

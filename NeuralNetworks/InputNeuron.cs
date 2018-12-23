using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    class InputNeuron : Neuron
    {
        private double value = 0;

        public override double Value => value;

        public void SetValue(double value) => this.value = value;
    }
}

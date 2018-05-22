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

        public double Value { get => value; set => this.value = value; }

        public override double GetValue()
        {
            return Value;
        }

        public void SetValue(double value)
        {
            this.Value = value;
        }
    }
}

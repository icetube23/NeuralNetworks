using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.ActivationFunctions
{
    class Sigmoid : IActivationFunction
    {
        public double Activation(double input)
        {
            return 1 / (1 + Math.Exp(-input));
        }
    }
}

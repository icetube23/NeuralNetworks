using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.ActivationFunctions
{
    class Binary : IActivationFunction
    {
        public double Activation(double input)
        {
            return input < 0 ? 0 : 1;
        }

        public double ActivationPrime(double input)
        {
            return 1;
        }
    }
}

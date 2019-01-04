using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.ActivationFunctions
{
    class HyperbolicTangent : IActivationFunction
    {
        public double Activation(double input)
        {
            return Math.Tanh(input);
        }

        public double ActivationPrime(double input)
        {
            return 1 - Math.Pow(Math.Tanh(input), 2);
        }
    }
}

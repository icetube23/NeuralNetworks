using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.ActivationFunctions
{
    interface IActivationFunction
    {
        double Activation(double input);

        double ActivationPrime(double input);
    }
}

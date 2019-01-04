﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.ActivationFunctions
{
    class Identity : IActivationFunction
    {
        public double Activation(double input)
        {
            return input;
        }

        public double ActivationPrime(double input)
        {
            return 1;
        }
    }
}

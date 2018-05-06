﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.NeuralNetworkTest
{
    class SingleLayerPerceptronTest
    {
        public static void Main(String[] args)
        {
            NeuralNetwork nn = new NeuralNetwork();

            InputNeuron i1 = nn.CreateNewInput();
            InputNeuron i2 = nn.CreateNewInput();
            InputNeuron i3 = nn.CreateNewInput();
            InputNeuron i4 = nn.CreateNewInput();

            WorkingNeuron o1 = nn.CreateNewOutput();

            nn.CreateHiddenNeurons(2);

            nn.CreateFullMesh(1, 2, 3, 4, 5, 6, 7, 8, 9, 1);

            i1.SetValue(1);
            i2.SetValue(2);
            i3.SetValue(3);
            i4.SetValue(4);

            Console.WriteLine(o1.GetValue());
            Console.Read();
        }
    }
}

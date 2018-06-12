using System;
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

            nn.CreateFullMesh(0.2, 0.9, 0.3, 0.65);

            i1.SetValue(1);
            i2.SetValue(2);
            i3.SetValue(3);
            i4.SetValue(4);

            double[] should = new double[1];
            should[0] = 42;

            Console.WriteLine(o1.GetValue());

            for (int i = 0; i < 200; i++)
            {
                nn.DeltaLearning(should, epsilon: 0.01);
                Console.WriteLine(o1.GetValue());
            }

            Console.Read();
        }
    }
}

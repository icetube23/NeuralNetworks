using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NeuralNetworks.MNISTDatabase;

namespace NeuralNetworks.NeuralNetworkTest
{
    class SingleLayerPerceptronTest
    {
        public static void Main(string[] args)
        {
            // Load training data
            List<Digit> digits = MNISTDecoder.LoadData("D:\\MNIST\\train-labels.idx1-ubyte",
                                                       "D:\\MNIST\\train-images.idx3-ubyte");

            // Create the network
            NeuralNetwork nn = new NeuralNetwork();
            InputNeuron[,] inputs = new InputNeuron[28, 28];
            WorkingNeuron[] outputs = new WorkingNeuron[10];

            for (int i = 0; i < inputs.GetLength(0); i++)
            {
                for (int j = 0; j < inputs.GetLength(1); j++)
                {
                    inputs[i, j] = nn.CreateNewInput();
                }
            }

            for (int i = 0; i < outputs.Length; i++)
            {
                outputs[i] = nn.CreateNewOutput();
            }

            nn.CreateRandomFullMesh();

            Console.Read();
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NeuralNetworks.MNISTDatabase;
using NeuralNetworks.ActivationFunctions;

namespace NeuralNetworks.NeuralNetworkTest
{
    class SingleLayerPerceptronTest
    {
        // Load training data
        public static readonly List<Digit> digits = MNISTDecoder.LoadData("D:\\MNIST\\train-labels.idx1-ubyte",
                                                                          "D:\\MNIST\\train-images.idx3-ubyte");
        // Load test data
        public static readonly List<Digit> testDigits = MNISTDecoder.LoadData("D:\\MNIST\\t10k-labels.idx1-ubyte",
                                                                              "D:\\MNIST\\t10k-images.idx3-ubyte");

        // Create the network
        public static NeuralNetwork nn = new NeuralNetwork();
        public static InputNeuron[,] inputs = new InputNeuron[28, 28];
        public static WorkingNeuron[] outputs = new WorkingNeuron[10];

        public static void Main(string[] args)
        {
            // Initialize input and output
            for (int i = 0; i < inputs.GetLength(0); i++)
            {
                for (int j = 0; j < inputs.GetLength(1); j++)
                {
                    inputs[i, j] = nn.CreateNewInput();
                }
            }

            for (int i = 0; i < outputs.Length; i++)
            {
                outputs[i] = nn.CreateNewOutput(new Sigmoid());
            }

            // Create connections with random weights
            nn.CreateRandomFullMesh();
            
            // Learn in an endless loop and display results
            double epsilon = 0.01;
            int epoch = 0;
            while (true)
            {
                Test(epoch++);
                Learn(epsilon);
                epsilon *= 0.9;
            }

            Console.Read();
        }

        public static void Test(int epoch)
        {
            // Compare networks output for the test dataset with expect results
            int correct = 0;

            foreach (var digit in testDigits)
            {
                for (int i = 0; i < digit.Data.GetLength(0); i++)
                {
                    for (int j = 0; j < digit.Data.GetLength(1); j++)
                    {
                        inputs[i, j].SetValue(MNISTDecoder.ToUnsignedByte(digit.Data[i, j]) / 255f);
                    }
                }
                double[] outputValues = outputs.Select(n => n.Value).ToArray();
                correct += Array.IndexOf(outputValues, outputValues.Max()) == digit.Label ? 1 : 0;
            }

            Console.WriteLine("Percentage of correct guesses in epoch " + epoch + ": " + (double)correct / testDigits.Count * 100 + "%");
        }

        public static void Learn(double epsilon)
        {
            // Conduct delta learning for every instance in the training dataset with specified learning parameter
            foreach (var digit in digits)
            {
                for (int i = 0; i < digit.Data.GetLength(0); i++)
                {
                    for (int j = 0; j < digit.Data.GetLength(1); j++)
                    {
                        inputs[i, j].SetValue(MNISTDecoder.ToUnsignedByte(digit.Data[i, j]) / 255f);
                    }
                }
                double[] shoulds = new double[10];
                shoulds[digit.Label] = 1;
                nn.DeltaLearning(epsilon, shoulds);
            }
        }
    }
}

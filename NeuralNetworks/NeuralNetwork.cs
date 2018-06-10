using NeuralNetworks.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    class NeuralNetwork
    {
        private List<InputNeuron> inputNeurons = new List<InputNeuron>();
        private List<WorkingNeuron> hiddenNeurons = new List<WorkingNeuron>();
        private List<WorkingNeuron> outputNeurons = new List<WorkingNeuron>();

        public InputNeuron CreateNewInput()
        {
            InputNeuron inputNeuron = new InputNeuron();
            inputNeurons.Add(inputNeuron);
            return inputNeuron;
        }

        public void CreateHiddenNeurons(int amount, IActivationFunction activationFunction = null)
        {
            if (amount < 0)
            {
                throw new SystemException("Amount has to be greater or equal to zero.");
            }
      
            for (int i = 0; i < amount; i++)
            {
                hiddenNeurons.Add(new WorkingNeuron(activationFunction));
            }
        }

        public WorkingNeuron CreateNewOutput(IActivationFunction activationFunction = null)
        {
            WorkingNeuron workingNeuron = new WorkingNeuron(activationFunction);
            outputNeurons.Add(workingNeuron);
            return workingNeuron;
        }

        public void CreateFullMesh()
        {
            if (hiddenNeurons.Count == 0)
            {
                foreach (WorkingNeuron outputNeuron in outputNeurons)
                {
                    foreach (InputNeuron inputNeuron in inputNeurons)
                    { 
                        outputNeuron.AddConnection(new Connection(inputNeuron, 1));
                    }
                }
            }
            else
            {
                foreach (WorkingNeuron hiddenNeuron in hiddenNeurons)
                {
                    foreach (InputNeuron inputNeuron in inputNeurons)
                    {
                        hiddenNeuron.AddConnection(new Connection(inputNeuron, 1));
                    }
                }

                foreach (WorkingNeuron outputNeuron in outputNeurons)
                {
                    foreach (WorkingNeuron hiddenNeuron in hiddenNeurons)
                    {
                        outputNeuron.AddConnection(new Connection(hiddenNeuron, 1));
                    }
                }
            }
            
        }

        public void CreateFullMesh(params double[] weights)
        {
            if (hiddenNeurons.Count == 0)
            {
                if (weights.Length != inputNeurons.Count * outputNeurons.Count)
                {
                    throw new SystemException("Wrong number of arguments given to create a Full Mesh.");
                }

                int index = 0;

                foreach (WorkingNeuron working in outputNeurons)
                {
                    foreach (InputNeuron input in inputNeurons)
                    {
                        working.AddConnection(new Connection(input, weights[index++]));
                    }
                }
            } 
            else
            {
                if (weights.Length != (inputNeurons.Count + outputNeurons.Count) * hiddenNeurons.Count)
                {
                    throw new SystemException("Wrong number of arguments given to create a Full Mesh.");
                }

                int index = 0;

                foreach (WorkingNeuron hiddenNeuron in hiddenNeurons)
                {
                    foreach (InputNeuron inputNeuron in inputNeurons)
                    {
                        hiddenNeuron.AddConnection(new Connection(inputNeuron, weights[index++]));
                    }
                }

                foreach (WorkingNeuron outputNeuron in outputNeurons)
                {
                    foreach (WorkingNeuron hiddenNeuron in hiddenNeurons)
                    {
                        outputNeuron.AddConnection(new Connection(hiddenNeuron, weights[index++]));
                    }
                }
            }
        }

        public void DeltaLearning(double[] shoulds, double epsilon)
        {
            if (shoulds.Length != outputNeurons.Count)
            {
                throw new ArgumentException();
            }

            if (hiddenNeurons.Count != 0)
            {
                throw new InvalidOperationException();
            }

            for (int i = 0; i < shoulds.Length; i++)
            {
                double smallDelta = shoulds[i] - outputNeurons[i].GetValue();
                outputNeurons[i].DeltaLearning(epsilon, smallDelta);
            }
        }
    }
}

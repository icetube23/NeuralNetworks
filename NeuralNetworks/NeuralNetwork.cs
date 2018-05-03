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
        private List<WorkingNeuron> outputNeurons = new List<WorkingNeuron>();

        public WorkingNeuron CreateNewOutput()
        {
            WorkingNeuron working = new WorkingNeuron();
            outputNeurons.Add(working);
            return working;
        }

        public InputNeuron CreateNewInput()
        {
            InputNeuron input = new InputNeuron();
            inputNeurons.Add(input);
            return input;
        }

        public void CreateFullMesh()
        {
            foreach (WorkingNeuron working in outputNeurons)
            {
                foreach (InputNeuron input in inputNeurons)
                {
                    working.AddConnection(new Connection(input, 1));
                }
            }
        }

        public void CreateFullMesh(params double[] weights)
        {
            if (weights.Length != inputNeurons.Count * outputNeurons.Count)
            {
                throw new SystemException();
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
    }
}

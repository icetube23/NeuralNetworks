using NeuralNetworks.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    class WorkingNeuron : Neuron
    {
        private List<Connection> connections = new List<Connection>();
        private IActivationFunction activationFunction;

        public WorkingNeuron(IActivationFunction activationFunction = null)
        {
            if (activationFunction is null)
            {
                this.activationFunction = new Identity();
            }
            else
            {
                this.activationFunction = activationFunction;
            }
        }

        public void SetActivationFunction(IActivationFunction activationFunction)
        {
            this.activationFunction = activationFunction;
        }

        public override double Value
        {
            get
            {
                double sum = 0;
                foreach (Connection c in connections)
                {
                    sum += c.Value;
                }
                return activationFunction.Activation(sum);
            }
        }

        public void AddConnection(Connection c) => connections.Add(c);

        public void DeltaLearning(double epsilon, double smallDelta)
        {
            foreach (Connection connection in connections)
            {
                double bigDelta = epsilon * smallDelta * connection.Value;
                connection.AddWeight(bigDelta);
            }
        }
    }
}

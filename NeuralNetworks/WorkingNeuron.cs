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

        public override double GetValue()
        {
            double sum = 0;
            foreach (Connection c in connections)
            {
                sum += c.GetValue();
            }
            return sum;
        }

        public void AddConnection(Connection c)
        {
            connections.Add(c);
        }
    }
}

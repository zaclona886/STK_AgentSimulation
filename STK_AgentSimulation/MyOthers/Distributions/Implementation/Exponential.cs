using STK_AgentSimulation.MyOthers.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions.Implementation
{
    public class Exponential : BaseDistribution
    {
        private Random random;
        private double lambda;

        public Exponential(double p_mean)
        {
            lambda = 1 / p_mean;
            random = new Random(SeedGenerator.GetNextInt());
        }

        public override double getNextValue()
        {
            double y = random.NextDouble();
            return -Math.Log(1 - y) / lambda;
        }
    }
}

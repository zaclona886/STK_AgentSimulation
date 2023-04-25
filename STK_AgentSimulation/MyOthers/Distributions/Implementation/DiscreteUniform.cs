using STK_AgentSimulation.MyOthers.Distributions;
using STK_AgentSimulation.MyOthers.Distributions.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions.Implementation
{
    public class DiscreteUniform : BaseDistribution
    {
        private Random rangeRandom;
        public DiscreteUniform(List<DistributionRange> p_range)
        {
            range = p_range;
            checkRangeValidation(range);
            rangeRandom = new Random(SeedGenerator.GetNextInt());
        }

        public override double getNextValue()
        {
            return rangeRandom.Next(range[0].tMin, range[0].tMax + 1);
        }
    }
}

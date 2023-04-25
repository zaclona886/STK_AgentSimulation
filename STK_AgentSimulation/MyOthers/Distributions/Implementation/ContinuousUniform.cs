using STK_AgentSimulation.MyOthers.Distributions.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions.Implementation
{

    public class ContinuousUniform : BaseDistribution
    {
        private Random rangeRandom;

        public ContinuousUniform(List<DistributionRange> p_range)
        {
            range = p_range;
            checkRangeValidation(range);
            rangeRandom = new Random(SeedGenerator.GetNextInt());
        }
        public override double getNextValue()
        {
            return rangeRandom.NextDouble() * (range[0].tMax - range[0].tMin) + range[0].tMin;
        }
    }
}

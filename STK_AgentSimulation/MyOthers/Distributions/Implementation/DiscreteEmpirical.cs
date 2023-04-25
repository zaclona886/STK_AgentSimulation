using STK_AgentSimulation.MyOthers.Distributions;
using STK_AgentSimulation.MyOthers.Distributions.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions.Implementation
{
    public class DiscreteEmpirical : BaseDistribution
    {
        private Random probabilityRandom;
        private List<DiscreteUniform> rangeRandom;
        public DiscreteEmpirical(List<DistributionRange> p_range)
        {
            range = p_range;
            checkRangeValidation(range);
            probabilityRandom = new Random(SeedGenerator.GetNextInt());
            rangeRandom = new List<DiscreteUniform>();
            for (int i = 0; i < range.Count; i++)
            {
                List<DistributionRange> new_range = new List<DistributionRange>
                {
                    new DistributionRange(range[i].tMin,range[i].tMax,1)
                };
                rangeRandom.Add(new DiscreteUniform(new_range));
            }
        }
        public override double getNextValue()
        {
            double probability = probabilityRandom.NextDouble();
            double forCompare = 0;

            for (int i = 0; i < range.Count; i++)
            {
                forCompare += range[i].probability;
                if (probability < forCompare)
                {
                    return rangeRandom[i].getNextValue();
                }
            }
            throw new ArgumentException("Fatal Error in Discrete Empirical Distribution");
        }
    }
}

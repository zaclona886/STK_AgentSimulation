using STK_AgentSimulation.MyOthers.Distributions;
using STK_AgentSimulation.MyOthers.Distributions.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions.Implementation
{
    public class Deterministic : BaseDistribution
    {
        public Deterministic(List<DistributionRange> p_range)
        {
            range = p_range;
            checkRangeValidation(range);
        }

        public override double getNextValue()
        {
            return range[0].tMin;
        }
    }
}

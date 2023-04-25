using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions.Others
{
    public class DistributionRange
    {
        public int tMin { get; set; }
        public int tMax { get; set; }
        public double probability { get; set; }

        public DistributionRange(int p_tMin, int p_tMax, double p_probability)
        {
            tMax = p_tMax;
            tMin = p_tMin;
            probability = p_probability;
        }
    }
}

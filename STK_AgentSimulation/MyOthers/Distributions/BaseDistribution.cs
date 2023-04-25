using STK_AgentSimulation.MyOthers.Distributions.Others;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions
{
    public abstract class BaseDistribution
    {
        public List<DistributionRange> range { get; set; }
        public abstract double getNextValue();

        protected bool checkRangeValidation(List<DistributionRange> range)
        {
            for (int i = 0; i < range.Count - 1; i++)
            {
                for (int j = 0; j < range.Count - i - 1; j++)
                {
                    if (range[j].probability < range[j + 1].probability)
                    {
                        DistributionRange temp = range[j];
                        range[j] = range[j + 1];
                        range[j + 1] = temp;
                    }
                }
            }

            double prob_summary = 0;
            for (int i = 0; i < range.Count; i++)
            {
                prob_summary += range[i].probability;
            }
            if (prob_summary < 0.99)
            {
                throw new ArgumentException("The probability summary of the time ranges in the path must be equal to 1.");
            }
            return true;
        }
    }
}

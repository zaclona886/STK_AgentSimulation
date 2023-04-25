using STK_AgentSimulation.MyOthers.Distributions;
using STK_AgentSimulation.MyOthers.Distributions.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions.Implementation
{
    public class Triangular : BaseDistribution
    {
        private TriangularRange triangularRange;
        private Random random;
        public Triangular(TriangularRange p_triangularRange)
        {
            triangularRange = p_triangularRange;
            random = new Random(SeedGenerator.GetNextInt());
        }
        public override double getNextValue()
        {
            var tmp = random.NextDouble();
            if (tmp < (triangularRange.mode - triangularRange.min) / (triangularRange.max - triangularRange.min))
            {
                return triangularRange.min + Math.Sqrt(tmp
                    * (triangularRange.max - triangularRange.min)
                    * (triangularRange.mode - triangularRange.min));
            }
            else
            {
                return triangularRange.max - Math.Sqrt((1 - tmp)
                    * (triangularRange.max - triangularRange.min)
                    * (triangularRange.max - triangularRange.mode));
            }
        }
    }
}

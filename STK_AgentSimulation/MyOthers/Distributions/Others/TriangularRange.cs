using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions.Others
{
    public class TriangularRange
    {
        public double min;
        public double max;
        public double mode;
        public TriangularRange(double min, double max, double mode)
        {
            this.min = min;
            this.max = max;
            this.mode = mode;
        }
    }
}

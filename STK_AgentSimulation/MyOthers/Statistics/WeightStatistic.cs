using OSPABA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Statistics
{
    public class WeightStatistic : Statistic
    {
        private double lastUpdate;

        public WeightStatistic(Simulation core) : base(core)
        {
            lastUpdate = 0;
        }

        public override void AddValue(double p_value)
        {
            var weight = _core.CurrentTime - lastUpdate;
            lastUpdate = _core.CurrentTime;

            sum += p_value * weight;
            sum2 += Math.Pow(p_value, 2) * weight;
            count += weight;
        }
    }
}

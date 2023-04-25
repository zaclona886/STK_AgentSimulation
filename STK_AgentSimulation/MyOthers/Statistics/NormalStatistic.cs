using OSPABA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Statistics
{
    public class NormalStatistic : Statistic
    {

        public NormalStatistic(Simulation core) : base(core)
        {

        }
        public override void AddValue(double p_value)
        {
            sum += p_value;
            sum2 += Math.Pow(p_value, 2);
            count += 1;
        }
    }
}

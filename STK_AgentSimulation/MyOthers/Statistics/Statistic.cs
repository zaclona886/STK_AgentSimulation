using OSPABA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Statistics
{
    public abstract class Statistic
    {
        protected readonly double ta_95 = 1.96;
        protected readonly double ta_90 = 1.645;
        protected double sum { get; set; }
        protected double sum2 { get; set; }
        protected double count { get; set; }
        protected Simulation _core { get; set; }

        public Statistic(Simulation core)
        {
            _core = core;
            sum = 0;
            sum2 = 0;
            count = 0;
        }
        public abstract void AddValue(double p_value);
        public double GetResult()
        {
            return sum / count;
        }
        public List<double> getConfidenceInterval(int p_ci)
        {
            if (p_ci != 90 && p_ci != 95 || count < 30)
            {
                return new List<double>() { 0, 0 }; ;
            }
            double ta = 0;
            if (p_ci == 90) ta = ta_90;
            if (p_ci == 95) ta = ta_95;


            var average = sum / count;
            var s = Math.Sqrt((sum2 - Math.Pow(sum, 2) / count) / (count - 1));

            List<double> confidence = new List<double>();
            confidence.Add(average - s * ta / Math.Sqrt(average));
            confidence.Add(average + s * ta / Math.Sqrt(average));
            return confidence;
        }
    }
}

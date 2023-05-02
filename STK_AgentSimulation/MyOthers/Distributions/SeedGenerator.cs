using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Distributions
{
    public static class SeedGenerator
    {
        private static readonly Random CustomRNG = new Random();

        public static int GetNextInt()
        {
            return CustomRNG.Next();
        }
    }
}

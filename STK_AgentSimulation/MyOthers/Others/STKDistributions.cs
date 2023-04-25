using STK_AgentSimulation.MyOthers.Distributions.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Others
{
    public static class STKDistributions
    {
        //seconds
        public static double carArrivals = 3600.0 / 23.0;
        //seconds
        public static TriangularRange takingOverCar =
            new TriangularRange(
                180.0,
                695.0,
                431.0);

        public static List<DistributionRange> vehicleType = new List<DistributionRange>()
        {
            new DistributionRange(1,1,0.65),
            new DistributionRange(2,2,0.21),
            new DistributionRange(3,3,0.14),
        };
        //min
        public static List<DistributionRange> carDist = new List<DistributionRange>()
        {
            new DistributionRange(31,45,1)
        };
        //min
        public static List<DistributionRange> vanDist = new List<DistributionRange>()
        {
            new DistributionRange(35,37,0.2),
            new DistributionRange(38,40,0.35),
            new DistributionRange(41,47,0.3),
            new DistributionRange(48,52,0.15)
        };

        public static List<DistributionRange> truckDist = new List<DistributionRange>()
        {
            new DistributionRange(37,42,0.05),
            new DistributionRange(43,45,0.1),
            new DistributionRange(46,47,0.15),
            new DistributionRange(48,51,0.4),
            new DistributionRange(52,55,0.25),
            new DistributionRange(56,65,0.05),
        };

        public static List<DistributionRange> paymentDist = new List<DistributionRange>()
        {
            new DistributionRange(
                65,
                177,1)
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.simulation
{
    public static class Config
    {
        public static int numberOfReplications = 10;
        public const double simulationTime = 480 * 60;
        public const double stopOfArrivingVehicles = 405 * 60;

        public static int numberOfWorkers1 = 2;
        public static int numberOfWorkers2 = 1;

        public const int numberOfParkingSlots = 1;

        public static bool advancedSimulation = false;
        public const double startOfPlanningBreaks = 120 * 60;
        public const double breakDuration = 30 * 60;
    }
}

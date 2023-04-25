using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.simulation
{
    public static class Config
    {
        public static int numberOfReplications = 1;
        public const double simulationTime = 480 * 60;
        public const double stopOfArrivingVehicles = 405 * 60;

        public static int numberOfWorkers1 = 4;
        public static int numberOfWorkers2AllVehicles = 17;
        public const int numberOfParkingSlots = 5;

        public static bool advancedSimulation = false;
        public const double startOfPlanningBreaks = 120 * 60;
        public const double breakDuration = 30 * 60;
        public static int numberOfWorkers2VanCar = 0;
    }
}

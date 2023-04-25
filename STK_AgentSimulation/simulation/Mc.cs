using OSPABA;

namespace STK_AgentSimulation.simulation
{
    public class Mc : IdList
    {
		//meta! userInfo="Generated code: do not modify", tag="begin"
		public const int CheckSpace = 1008;
		public const int VehicleLeave = 1001;
		public const int VehicleArrive = 1002;
		public const int VehicleService = 1003;
		public const int WorkerBreak = 1010;
		public const int VehicleControl = 1006;
		//meta! tag="end"

        // 1..1000 range reserved for user
        public const int NewVehicle = 1;
        public const int CheckEnd = 2;
        public const int ControlEnd = 3;
        public const int PaymentEnd = 4;
        public const int WorkerBreakEnd = 5;

    }
}
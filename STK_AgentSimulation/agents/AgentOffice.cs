using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.managers;
using STK_AgentSimulation.continualAssistants;
using STK_AgentSimulation.MyOthers.Statistics;
using STK_AgentSimulation.MyOthers.Others;

namespace STK_AgentSimulation.agents
{
    //meta! id="5"
    public class AgentOffice : Agent
    {
        public List<STKWorker> workers1 { get; set; }
        public Dictionary<int, STKVehicle> takenVehicles { get; set; }
        public Dictionary<int, STKVehicle> payingVehicles { get; set; }
        public Queue<MyMessage> vehicleArrivalQueue { get; set; }
        public Queue<MyMessage> vehiclePaymentQueue { get; set; }
        public bool breakTime { get; set; }

        public int arrivedVehicles { get; set; }
        public int finishedVehicles { get; set; }
        public WeightStatistic averageCountOfVehiclesInSystem { get; set; }
        public NormalStatistic averageTimeOfVehiclesInSystem { get; set; }

        public WeightStatistic averageCountOfVehiclesInQueue { get; set; }
        public NormalStatistic averageTimeOfVehiclesInQueue { get; set; }

        public WeightStatistic averageCountOfFreeWorkers1 { get; set; }


        public AgentOffice(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            arrivedVehicles = 0;
            finishedVehicles = 0;

            averageCountOfVehiclesInSystem = new WeightStatistic(MySim);
            averageTimeOfVehiclesInSystem = new NormalStatistic(MySim);

            averageCountOfVehiclesInQueue = new WeightStatistic(MySim);
            averageTimeOfVehiclesInQueue = new NormalStatistic(MySim);

            averageCountOfFreeWorkers1 = new WeightStatistic(MySim);

            workers1 = new List<STKWorker>();
            for (int i = 0; i < Config.numberOfWorkers1; i++)
            {
                var newWorker = new STKWorker();
                newWorker.certificate = CertificateType.Basic;
                workers1.Add(newWorker);
            }
            vehicleArrivalQueue = new Queue<MyMessage>();
            vehiclePaymentQueue = new Queue<MyMessage>();
            takenVehicles = new Dictionary<int, STKVehicle>();
            payingVehicles = new Dictionary<int, STKVehicle>();

            breakTime = false;
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerOffice(SimId.ManagerOffice, MySim, this);
			new Worker1BreakProcess(SimId.Worker1BreakProcess, MySim, this);
			new VehicleCheckProcess(SimId.VehicleCheckProcess, MySim, this);
			new VehiclePaymentProcess(SimId.VehiclePaymentProcess, MySim, this);
			AddOwnMessage(Mc.VehicleControl);
			AddOwnMessage(Mc.WorkerBreak);
			AddOwnMessage(Mc.VehicleService);
			AddOwnMessage(Mc.CheckSpace);
		}
		//meta! tag="end"
    }
}
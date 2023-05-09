using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.managers;
using STK_AgentSimulation.continualAssistants;
using STK_AgentSimulation.MyOthers.Statistics;
using STK_AgentSimulation.MyOthers.Others;

namespace STK_AgentSimulation.agents
{
    //meta! id="6"
    public class AgentGarage : Agent
    {
        public Dictionary<int, STKVehicle> controllingVehicles { get; set; }
        public Queue<MyMessage> vehiclesParkingInFrontOfControlBASICQueue { get; set; }
        public Queue<MyMessage> vehiclesParkingInFrontOfControlADVANCEDQueue { get; set; }
        public List<STKWorker> workers2 { get; set; }
        public bool breakTime { get; set; }
        public WeightStatistic averageCountOfFreeWorkers2AllVehicles { get; set; }
        public WeightStatistic averageCountOfFreeWorkers2CarVans { get; set; }
        public AgentGarage(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            averageCountOfFreeWorkers2AllVehicles = new WeightStatistic(MySim);
            averageCountOfFreeWorkers2CarVans = new WeightStatistic(MySim);

            workers2 = new List<STKWorker>();
            for (int i = 0; i < Config.numberOfWorkers2AllVehicles; i++)
            {
                var newWorker = new STKWorker();
                newWorker.certificate = CertificateType.AllVehicles;
                workers2.Add(newWorker);
            }
            if (Config.advancedSimulation)
            {
                for (int i = 0; i < Config.numberOfWorkers2VanCar; i++)
                {
                    var newWorker = new STKWorker();
                    newWorker.certificate = CertificateType.CarVan;
                    workers2.Add(newWorker);
                }
            }
            vehiclesParkingInFrontOfControlBASICQueue = new Queue<MyMessage>();
            vehiclesParkingInFrontOfControlADVANCEDQueue = new Queue<MyMessage>();
            controllingVehicles = new Dictionary<int, STKVehicle>();

            breakTime = false;
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerGarage(SimId.ManagerGarage, MySim, this);
			new VehicleControlProcess(SimId.VehicleControlProcess, MySim, this);
			new Worker2BreakProcess(SimId.Worker2BreakProcess, MySim, this);
			AddOwnMessage(Mc.VehicleControl);
			AddOwnMessage(Mc.WorkerBreak);
			AddOwnMessage(Mc.CheckSpace);
		}
		//meta! tag="end"
    }
}
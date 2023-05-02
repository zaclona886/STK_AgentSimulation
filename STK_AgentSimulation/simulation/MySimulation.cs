using OSPABA;
using STK_AgentSimulation.agents;
using STK_AgentSimulation.MyOthers.Statistics;

namespace STK_AgentSimulation.simulation
{
    public class MySimulation : Simulation
    {
        //Global Statistics
        public NormalStatistic globalAverageFinishedVehicles { get; set; }
        public NormalStatistic globalAverageLeftVehiclesInSystem { get; set; }

        public NormalStatistic globalAverageCountOfVehiclesInSystem { get; set; }
        public NormalStatistic globalAverageTimeOfVehiclesInSystem { get; set; }

        public NormalStatistic globalAverageCountOfVehiclesInQueue { get; set; }
        public NormalStatistic globalAverageTimeOfVehiclesInQueue { get; set; }

        public NormalStatistic globalAverageCountOfFreeWorkers1 { get; set; }
        public NormalStatistic globalAverageCountOfFreeWorkers2AllVehicles { get; set; }
        public NormalStatistic globalAverageCountOfFreeWorkers2CarVans { get; set; }
        public MySimulation()
        {
            Init();
        }

        override protected void PrepareSimulation()
        {
            base.PrepareSimulation();
            // Create global statistcis
            globalAverageFinishedVehicles = new NormalStatistic(this);
            globalAverageLeftVehiclesInSystem = new NormalStatistic(this);

            globalAverageCountOfVehiclesInSystem = new NormalStatistic(this);
            globalAverageTimeOfVehiclesInSystem = new NormalStatistic(this);

            globalAverageCountOfVehiclesInQueue = new NormalStatistic(this);
            globalAverageTimeOfVehiclesInQueue = new NormalStatistic(this);

            globalAverageCountOfFreeWorkers1 = new NormalStatistic(this);
            globalAverageCountOfFreeWorkers2AllVehicles = new NormalStatistic(this);
            globalAverageCountOfFreeWorkers2CarVans = new NormalStatistic(this);
        }

        override protected void PrepareReplication()
        {
            base.PrepareReplication();
            // Reset entities, queues, local statistics, etc...
        }

        override protected void ReplicationFinished()
        {
            // Collect local statistics into global, update UI, etc...
            base.ReplicationFinished();
            globalAverageFinishedVehicles.AddValue(AgentOffice.finishedVehicles);
            globalAverageLeftVehiclesInSystem.AddValue(AgentOffice.arrivedVehicles - AgentOffice.finishedVehicles);

            globalAverageCountOfVehiclesInSystem.AddValue(AgentOffice.averageCountOfVehiclesInSystem.GetResult());
            globalAverageTimeOfVehiclesInSystem.AddValue(AgentOffice.averageTimeOfVehiclesInSystem.GetResult());

            globalAverageCountOfVehiclesInQueue.AddValue(AgentOffice.averageCountOfVehiclesInQueue.GetResult());
            globalAverageTimeOfVehiclesInQueue.AddValue(AgentOffice.averageTimeOfVehiclesInQueue.GetResult());

            globalAverageCountOfFreeWorkers1.AddValue(AgentOffice.averageCountOfFreeWorkers1.GetResult());
            globalAverageCountOfFreeWorkers2AllVehicles.AddValue(AgentGarage.averageCountOfFreeWorkers2AllVehicles.GetResult());
            globalAverageCountOfFreeWorkers2CarVans.AddValue(AgentGarage.averageCountOfFreeWorkers2CarVans.GetResult());
        }

        override protected void SimulationFinished()
        {
            // Dysplay simulation results
            base.SimulationFinished();
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			AgentModel = new AgentModel(SimId.AgentModel, this, null);
			AgentEnvironment = new AgentEnvironment(SimId.AgentEnvironment, this, AgentModel);
			AgentSTK = new AgentSTK(SimId.AgentSTK, this, AgentModel);
			AgentOffice = new AgentOffice(SimId.AgentOffice, this, AgentSTK);
			AgentGarage = new AgentGarage(SimId.AgentGarage, this, AgentSTK);
		}
		public AgentModel AgentModel
		{ get; set; }
		public AgentEnvironment AgentEnvironment
		{ get; set; }
		public AgentSTK AgentSTK
		{ get; set; }
		public AgentOffice AgentOffice
		{ get; set; }
		public AgentGarage AgentGarage
		{ get; set; }
		//meta! tag="end"
    }
}
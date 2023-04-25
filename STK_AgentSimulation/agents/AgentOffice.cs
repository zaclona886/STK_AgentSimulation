using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.managers;
using STK_AgentSimulation.continualAssistants;

namespace STK_AgentSimulation.agents
{
    //meta! id="5"
    public class AgentOffice : Agent
    {
        public int arrivedVehicles { get; set; }
        public int finishedVehicles { get; set; }
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
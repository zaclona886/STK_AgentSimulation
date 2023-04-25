using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.managers;
using STK_AgentSimulation.continualAssistants;

namespace STK_AgentSimulation.agents
{
    //meta! id="6"
    public class AgentGarage : Agent
    {
        public AgentGarage(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
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
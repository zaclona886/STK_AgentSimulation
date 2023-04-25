using OSPABA;
using STK_AgentSimulation.managers;
using STK_AgentSimulation.continualAssistants;
using STK_AgentSimulation.simulation;

namespace STK_AgentSimulation.agents
{
    //meta! id="1"
    public class AgentModel : Agent
    {
        public AgentModel(int id, Simulation mySim, Agent parent) :
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
			new ManagerModel(SimId.ManagerModel, MySim, this);
			AddOwnMessage(Mc.VehicleArrive);
			AddOwnMessage(Mc.VehicleService);
		}
		//meta! tag="end"
    }
}
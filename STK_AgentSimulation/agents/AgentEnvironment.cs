using OSPABA;
using STK_AgentSimulation.managers;
using STK_AgentSimulation.continualAssistants;
using STK_AgentSimulation.simulation;

namespace STK_AgentSimulation.agents
{
    //meta! id="2"
    public class AgentEnvironment : Agent
    {
        public AgentEnvironment(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication

            MyMessage message = new MyMessage(MySim);
            message.Addressee = FindAssistant(SimId.VehicleArriveScheduler);
            MyManager.StartContinualAssistant(message);
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerEnvironment(SimId.ManagerEnvironment, MySim, this);
			new VehicleArriveScheduler(SimId.VehicleArriveScheduler, MySim, this);
			AddOwnMessage(Mc.VehicleLeave);
		}
		//meta! tag="end"
    }
}
using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.managers;
using STK_AgentSimulation.continualAssistants;

namespace STK_AgentSimulation.agents
{
    //meta! id="4"
    public class AgentSTK : Agent
    {
        public AgentSTK(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            if (Config.advancedSimulation)
            {
                MyMessage message = new MyMessage(MySim);
                message.Addressee = FindAssistant(SimId.WorkersBreakScheduler);
                MyManager.StartContinualAssistant(message);
            }
            
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerSTK(SimId.ManagerSTK, MySim, this);
			new WorkersBreakScheduler(SimId.WorkersBreakScheduler, MySim, this);
			AddOwnMessage(Mc.VehicleControl);
			AddOwnMessage(Mc.VehicleService);
			AddOwnMessage(Mc.CheckSpace);
		}
		//meta! tag="end"
    }
}
using OSPABA;
using STK_AgentSimulation.continualAssistants;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.agents;

namespace STK_AgentSimulation.managers
{
    //meta! id="1"
    public class ManagerModel : Manager
    {
        public ManagerModel(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication

            if (PetriNet != null)
            {
                PetriNet.Clear();
            }
        }
		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

		//meta! sender="AgentEnvironment", id="12", type="Notice"
		public void ProcessVehicleArrive(MessageForm message)
		{
            message.Code = Mc.VehicleService;
            message.Addressee = MySim.FindAgent(SimId.AgentSTK);
            Request(message);
        }

		//meta! sender="AgentSTK", id="13", type="Response"
		public void ProcessVehicleService(MessageForm message)
		{
            message.Code = Mc.VehicleLeave;
            message.Addressee = MySim.FindAgent(SimId.AgentEnvironment);
            Notice(message);
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.VehicleService:
				ProcessVehicleService(message);
			break;

			case Mc.VehicleArrive:
				ProcessVehicleArrive(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
        public new AgentModel MyAgent
        {
            get
            {
                return (AgentModel)base.MyAgent;
            }
        }
    }
}
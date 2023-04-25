using OSPABA;
using STK_AgentSimulation.agents;
using STK_AgentSimulation.simulation;

namespace STK_AgentSimulation.managers
{
    //meta! id="2"
    public class ManagerEnvironment : Manager
    {
        private int vehicleId { get; set; }
        public ManagerEnvironment(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="AgentModel", id="11", type="Notice"
		public void ProcessVehicleLeave(MessageForm message)
        {
        }

		//meta! sender="VehicleArriveScheduler", id="27", type="Finish"
		public void ProcessFinish(MessageForm message)
        {
            message.Addressee = MySim.FindAgent(SimId.AgentModel);
            message.Code = Mc.VehicleArrive;
            Notice(new MyMessage((MyMessage)message));
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.VehicleLeave:
				ProcessVehicleLeave(message);
			break;

			case Mc.Finish:
				ProcessFinish(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
        public new AgentEnvironment MyAgent
        {
            get
            {
                return (AgentEnvironment)base.MyAgent;
            }
        }
    }
}
using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.continualAssistants;
using STK_AgentSimulation.agents;

namespace STK_AgentSimulation.managers
{
    //meta! id="4"
    public class ManagerSTK : Manager
    {
        public ManagerSTK(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="AgentOffice", id="20", type="Response"
		public void ProcessVehicleServiceAgentOffice(MessageForm message)
        {
            message.Code = Mc.VehicleService;
            Response(message);
        }

		//meta! sender="AgentGarage", id="21", type="Response"
		public void ProcessVehicleControlAgentGarage(MessageForm message)
        {
            message.Code = Mc.VehicleControl;
            Response(message);
        }

		//meta! sender="AgentModel", id="13", type="Request"
		public void ProcessVehicleServiceAgentModel(MessageForm message)
        {
            message.Code = Mc.VehicleService;
            message.Addressee = MySim.FindAgent(SimId.AgentOffice);
            Request(message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

		//meta! sender="AgentOffice", id="30", type="Request"
		public void ProcessVehicleControlAgentOffice(MessageForm message)
		{
            // Control of Vehicle in Garage
            message.Code = Mc.VehicleControl;
            message.Addressee = MySim.FindAgent(SimId.AgentGarage);
            Request(message);
        }

		//meta! sender="AgentGarage", id="34", type="Response"
		public void ProcessCheckSpaceAgentGarage(MessageForm message)
		{
            message.Code = Mc.CheckSpace;
            Response(message);
        }

		//meta! sender="AgentOffice", id="33", type="Request"
		public void ProcessCheckSpaceAgentOffice(MessageForm message)
		{
            message.Code = Mc.CheckSpace;
            message.Addressee = MySim.FindAgent(SimId.AgentGarage);
            Request(message);
        }

		//meta! sender="WorkersBreakScheduler", id="42", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
            message.Addressee = MySim.FindAgent(SimId.AgentOffice);
            message.Code = Mc.WorkerBreak;
            Notice(new MyMessage((MyMessage)message));

			message.Addressee = MySim.FindAgent(SimId.AgentGarage);
            message.Code = Mc.WorkerBreak;
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
			case Mc.CheckSpace:
				switch (message.Sender.Id)
				{
				case SimId.AgentGarage:
					ProcessCheckSpaceAgentGarage(message);
				break;

				case SimId.AgentOffice:
					ProcessCheckSpaceAgentOffice(message);
				break;
				}
			break;

			case Mc.VehicleService:
				switch (message.Sender.Id)
				{
				case SimId.AgentModel:
					ProcessVehicleServiceAgentModel(message);
				break;

				case SimId.AgentOffice:
					ProcessVehicleServiceAgentOffice(message);
				break;
				}
			break;

			case Mc.VehicleControl:
				switch (message.Sender.Id)
				{
				case SimId.AgentOffice:
					ProcessVehicleControlAgentOffice(message);
				break;

				case SimId.AgentGarage:
					ProcessVehicleControlAgentGarage(message);
				break;
				}
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
        public new AgentSTK MyAgent
        {
            get
            {
                return (AgentSTK)base.MyAgent;
            }
        }
    }
}
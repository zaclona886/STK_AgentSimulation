using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.agents;
using STK_AgentSimulation.MyOthers.Distributions.Implementation;
using STK_AgentSimulation.MyOthers.Others;
using STK_AgentSimulation.MyOthers.Distributions;

namespace STK_AgentSimulation.continualAssistants
{
    //meta! id="15"
    public class VehicleCheckProcess : Process
    {
        public BaseDistribution trianTakingOverCar;

        public VehicleCheckProcess(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
            trianTakingOverCar = new Triangular(STKDistributions.takingOverCar);
            MyAgent.AddOwnMessage(Mc.CheckEnd);
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
        }

		//meta! sender="AgentOffice", id="16", type="Start"
		public void ProcessStart(MessageForm message)
        {
            ((MyMessage)message).Code = Mc.CheckEnd;
            Hold(trianTakingOverCar.getNextValue(), message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.CheckEnd:
                    AssistantFinished(message);
                    break;
            }
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.Start:
				ProcessStart(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
        public new AgentOffice MyAgent
        {
            get
            {
                return (AgentOffice)base.MyAgent;
            }
        }
    }
}
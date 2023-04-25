using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.agents;
using STK_AgentSimulation.MyOthers.Distributions;
using STK_AgentSimulation.MyOthers.Distributions.Implementation;
using STK_AgentSimulation.MyOthers.Others;

namespace STK_AgentSimulation.continualAssistants
{
    //meta! id="17"
    public class VehiclePaymentProcess : Process
    {
        public BaseDistribution paymentDist;
        public VehiclePaymentProcess(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {            
            paymentDist = new ContinuousUniform(STKDistributions.paymentDist);
            MyAgent.AddOwnMessage(Mc.PaymentEnd);
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
        }

		//meta! sender="AgentOffice", id="18", type="Start"
		public void ProcessStart(MessageForm message)
        {
            ((MyMessage)message).Code = Mc.PaymentEnd;
            Hold(paymentDist.getNextValue(), message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.PaymentEnd:
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
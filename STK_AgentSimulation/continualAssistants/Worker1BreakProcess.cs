using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.agents;

namespace STK_AgentSimulation.continualAssistants
{
    //meta! id="43"
    public class Worker1BreakProcess : Process
    {
        public Worker1BreakProcess(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
            MyAgent.AddOwnMessage(Mc.WorkerBreakEnd);
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.WorkerBreakEnd:
                    AssistantFinished(message);
                    break;
            }
        }

		//meta! sender="AgentOffice", id="44", type="Start"
		public void ProcessStart(MessageForm message)
		{
            ((MyMessage)message).Code = Mc.WorkerBreakEnd;
            Hold(Config.breakDuration, message);
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
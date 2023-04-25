using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.agents;

namespace STK_AgentSimulation.continualAssistants
{
    //meta! id="41"
    public class WorkersBreakScheduler : Scheduler
    {
        public WorkersBreakScheduler(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
            MyAgent.AddOwnMessage(Mc.WorkerBreakEnd);
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
        }

		//meta! sender="AgentSTK", id="42", type="Start"
		public void ProcessStart(MessageForm message)
        {
            ((MyMessage)message).Code = Mc.WorkerBreakEnd;
            Hold(Config.startOfPlanningBreaks, message);
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
        public new AgentSTK MyAgent
        {
            get
            {
                return (AgentSTK)base.MyAgent;
            }
        }
    }
}
using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.agents;
using STK_AgentSimulation.MyOthers.Others;
using STK_AgentSimulation.MyOthers.Distributions.Implementation;
using STK_AgentSimulation.MyOthers.Distributions;

namespace STK_AgentSimulation.continualAssistants
{
    //meta! id="23"
    public class VehicleControlProcess : Process
    {
        private BaseDistribution carTypeDist { get; set; }
        private BaseDistribution vanTypeDist { get; set; }
        private BaseDistribution truckTypeDist { get; set; }
        public VehicleControlProcess(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {            
            carTypeDist = new DiscreteUniform(STKDistributions.carDist);
            vanTypeDist = new DiscreteEmpirical(STKDistributions.vanDist);
            truckTypeDist = new DiscreteEmpirical(STKDistributions.truckDist);
            MyAgent.AddOwnMessage(Mc.ControlEnd);
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
        }

        private double GetControlTimeOfVehicle(STKVehicle car)
        {
            if (car.vehicleType == VehicleType.Car) return carTypeDist.getNextValue() * 60;
            if (car.vehicleType == VehicleType.Van) return vanTypeDist.getNextValue() * 60;
            if (car.vehicleType == VehicleType.Truck) return truckTypeDist.getNextValue() * 60;
            throw new ArgumentException("Fatal error in generating vehicle control time!");
        }

		//meta! sender="AgentGarage", id="24", type="Start"
		public void ProcessStart(MessageForm message)
        {
            ((MyMessage)message).Code = Mc.ControlEnd;
            Hold( GetControlTimeOfVehicle(((MyMessage)message)._vehicle), message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.ControlEnd:
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
        public new AgentGarage MyAgent
        {
            get
            {
                return (AgentGarage)base.MyAgent;
            }
        }
    }
}
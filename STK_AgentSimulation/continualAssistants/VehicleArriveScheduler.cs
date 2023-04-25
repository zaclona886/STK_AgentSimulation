using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.agents;
using STK_AgentSimulation.MyOthers.Distributions.Implementation;
using STK_AgentSimulation.MyOthers.Distributions;
using STK_AgentSimulation.MyOthers.Others;

namespace STK_AgentSimulation.continualAssistants
{
    //meta! id="26"
    public class VehicleArriveScheduler : Scheduler
    {
        private BaseDistribution expoDistCarsArrival;
        private BaseDistribution vehicleTypeDist;
        private int vehicleIdCounter;

        public VehicleArriveScheduler(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
            expoDistCarsArrival = new Exponential(STKDistributions.carArrivals);
            vehicleTypeDist = new DiscreteEmpirical(STKDistributions.vehicleType);
            MyAgent.AddOwnMessage(Mc.NewVehicle);
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            vehicleIdCounter = 0;
        }
        private STKVehicle CreateVehicle()
        {
            vehicleIdCounter++;
            switch (vehicleTypeDist.getNextValue())
            {
                case 1:
                    return new STKVehicle(vehicleIdCounter, 0, VehicleType.Car);
                case 2:
                    return new STKVehicle(vehicleIdCounter, 0, VehicleType.Van);
                case 3:
                    return new STKVehicle(vehicleIdCounter, 0, VehicleType.Truck);
            }
            throw new ArgumentException("Fatal error in choosing vehicle type!");
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.NewVehicle:
                    double time = expoDistCarsArrival.getNextValue();
                    if ((MySim.CurrentTime + time) < Config.stopOfArrivingVehicles) 
                    {
                        MessageForm copy = message.CreateCopy();
                        ((MyMessage)copy)._vehicle = CreateVehicle();
                        Hold(time, copy);                      
                        AssistantFinished(message);
                    } 
                    break;
            }
        }

		//meta! sender="AgentEnvironment", id="27", type="Start"
		public void ProcessStart(MessageForm message)
		{
            ((MyMessage)message).Code = Mc.NewVehicle;
            ((MyMessage)message)._vehicle = CreateVehicle();
            Hold(expoDistCarsArrival.getNextValue(), message);
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
        public new AgentEnvironment MyAgent
        {
            get
            {
                return (AgentEnvironment)base.MyAgent;
            }
        }
    }
}
using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.continualAssistants;
using STK_AgentSimulation.agents;
using STK_AgentSimulation.MyOthers.Others;

namespace STK_AgentSimulation.managers
{
    //meta! id="6"
    public class ManagerGarage : Manager
    {
        public Dictionary<int, STKVehicle> controllingVehicles { get; set; }
        public Queue<MyMessage> vehiclesParkingInFrontOfControlQueue { get; set; }
        public List<STKWorker> workers2 { get; set; }
        public ManagerGarage(int id, Simulation mySim, Agent myAgent) :
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

            workers2 = new List<STKWorker>();
            for (int i = 0; i < Config.numberOfWorkers2; i++)
            {
                workers2.Add(new STKWorker());
            }
            vehiclesParkingInFrontOfControlQueue = new Queue<MyMessage>();
            controllingVehicles = new Dictionary<int, STKVehicle>();

        }

        //meta! sender="AgentSTK", id="21", type="Request"
        public void ProcessVehicleControl(MessageForm message)
        {
            vehiclesParkingInFrontOfControlQueue.Enqueue(message as MyMessage);
            TryToServeParkedVehicles();
        }

        private void TryToServeParkedVehicles()
        {
            if (vehiclesParkingInFrontOfControlQueue.Count > 0)
            {
                STKWorker? freeWorker = GetFreeWorker();
                if (freeWorker != null)
                {
                    MessageForm message = vehiclesParkingInFrontOfControlQueue.Dequeue();
                    freeWorker.isBusy = true;
                    freeWorker.jobType = JobType.Controlling;
                    freeWorker.vehicle = ((MyMessage)message)._vehicle;
                    ((MyMessage)message)._workerk2 = freeWorker;
                    controllingVehicles.Add(((MyMessage)message)._vehicle.id, ((MyMessage)message)._vehicle);
                    message.Addressee = MyAgent.FindAssistant(SimId.VehicleControlProcess);
                    StartContinualAssistant(message);
                }
            }
        }

        private STKWorker? GetFreeWorker()
        {
            foreach (STKWorker data in workers2)
            {
                if (!data.isBusy)
                {
                    return data;
                }
            }
            return null;
        }

        //meta! sender="VehicleControlProcess", id="24", type="Finish"
        public void ProcessFinish(MessageForm message)
        {
            // Control of Vehicle in Garage
            message.Code = Mc.VehicleControl;
            Response(message);

            ((MyMessage)message)._workerk2.isBusy = false;
            ((MyMessage)message)._workerk2.jobType = null;
            ((MyMessage)message)._workerk2.vehicle = null;
            ((MyMessage)message)._workerk2 = null;
            controllingVehicles.Remove(((MyMessage)message)._vehicle.id);

            TryToServeParkedVehicles();
        }

        //meta! userInfo="Process messages defined in code", id="0"
        public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

        //meta! sender="AgentSTK", id="34", type="Request"
        public void ProcessCheckSpace(MessageForm message)
        {
            message.Code = Mc.CheckSpace;
            message.Addressee = MySim.FindAgent(SimId.AgentSTK);
            ((MyMessage)message).freeParkingSlots = Config.numberOfParkingSlots - vehiclesParkingInFrontOfControlQueue.Count;

            int countBusy = 0;
            foreach (STKWorker data in workers2)
            {
                if (data.isBusy) countBusy++;
            }

            ((MyMessage)message).freeWorkers2 = Config.numberOfWorkers2 - countBusy;
            Response(message);
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
                    ProcessCheckSpace(message);
                    break;

                case Mc.Finish:
                    ProcessFinish(message);
                    break;

                case Mc.VehicleControl:
                    ProcessVehicleControl(message);
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
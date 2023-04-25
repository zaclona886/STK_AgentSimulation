using OSPABA;
using STK_AgentSimulation.simulation;
using STK_AgentSimulation.continualAssistants;
using STK_AgentSimulation.agents;
using STK_AgentSimulation.MyOthers.Others;
using System.Collections.Generic;

namespace STK_AgentSimulation.managers
{
    //meta! id="5"
    public class ManagerOffice : Manager
    {
        public List<STKWorker> workers1 { get; set; }
        public Dictionary<int, STKVehicle> takenVehicles { get; set; }
        public Dictionary<int, STKVehicle> payingVehicles { get; set; }
        public Queue<MyMessage> vehicleArrivalQueue { get; set; }
        public Queue<MyMessage> vehiclePaymentQueue { get; set; }

        public ManagerOffice(int id, Simulation mySim, Agent myAgent) :
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


            workers1 = new List<STKWorker>();
            for (int i = 0; i < Config.numberOfWorkers1; i++)
            {
                workers1.Add(new STKWorker());
            }
            vehicleArrivalQueue = new Queue<MyMessage>();
            vehiclePaymentQueue = new Queue<MyMessage>();
            takenVehicles = new Dictionary<int, STKVehicle>();
            payingVehicles = new Dictionary<int, STKVehicle>();
        }


        //meta! sender="AgentSTK", id="20", type="Request"
        public void ProcessVehicleService(MessageForm message)
        {
            ((MyMessage)message)._vehicle.arrivalTime = MySim.CurrentTime;
            vehicleArrivalQueue.Enqueue(message as MyMessage);

            message.Code = Mc.CheckSpace;
            message.Addressee = MySim.FindAgent(SimId.AgentSTK);
            Request(message);
        }

        //meta! sender="VehicleCheckProcess", id="16", type="Finish"
        public void ProcessFinishVehicleCheckProcess(MessageForm message)
        {
            // Control of Vehicle in Garage
            message.Code = Mc.VehicleControl;
            message.Addressee = MySim.FindAgent(SimId.AgentSTK);
            Request(message);          

            SetWorkerJobDone(((MyMessage)message));
            takenVehicles.Remove(((MyMessage)message)._vehicle.id);

            if (vehicleArrivalQueue.Count > 0 || vehiclePaymentQueue.Count > 0)
            {
                MyMessage newMessage = (MyMessage)message.CreateCopy();
                newMessage.Code = Mc.CheckSpace;
                newMessage.Addressee = MySim.FindAgent(SimId.AgentSTK);
                Request(newMessage);
            }
        }        

        //meta! sender="VehiclePaymentProcess", id="18", type="Finish"
        public void ProcessFinishVehiclePaymentProcess(MessageForm message)
        {
            message.Code = Mc.VehicleService;
            message.Addressee = MySim.FindAgent(SimId.AgentSTK);
            Response(message);

            SetWorkerJobDone(((MyMessage)message));
            payingVehicles.Remove(((MyMessage)message)._vehicle.id);

            if (vehicleArrivalQueue.Count > 0 || vehiclePaymentQueue.Count > 0)
            {
                MyMessage newMessage = (MyMessage)message.CreateCopy();
                newMessage.Code = Mc.CheckSpace;
                newMessage.Addressee = MySim.FindAgent(SimId.AgentSTK);
                Request(newMessage);
            }
        }

        //meta! sender="AgentSTK", id="30", type="Response"
        public void ProcessVehicleControl(MessageForm message)
        {
            vehiclePaymentQueue.Enqueue(message as MyMessage);

            if (vehicleArrivalQueue.Count > 0 || vehiclePaymentQueue.Count > 0)
            {
                MyMessage newMessage = (MyMessage)message.CreateCopy();
                newMessage.Code = Mc.CheckSpace;
                newMessage.Addressee = MySim.FindAgent(SimId.AgentSTK);
                Request(newMessage);
            }
        }

        //meta! userInfo="Process messages defined in code", id="0"
        public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

        //meta! sender="AgentSTK", id="33", type="Response"
        public void ProcessCheckSpace(MessageForm message)
        {
            TryToServePaymentQueue();
            if ((((MyMessage)message).freeParkingSlots + ((MyMessage)message).freeWorkers2) > takenVehicles.Count)
            {
                TryToServeArrivalQueue();
            }
        }
        private void TryToServePaymentQueue()
        {
            if (vehiclePaymentQueue.Count > 0)
            {
                STKWorker? freeWorker = GetFreeWorker();
                if (freeWorker != null)
                {
                    MessageForm message = vehiclePaymentQueue.Dequeue();
                    freeWorker.isBusy = true;
                    freeWorker.jobType = JobType.Paying;
                    freeWorker.vehicle = ((MyMessage)message)._vehicle;
                    ((MyMessage)message)._workerk1 = freeWorker;
                    payingVehicles.Add(((MyMessage)message)._vehicle.id, ((MyMessage)message)._vehicle);
                    message.Addressee = MyAgent.FindAssistant(SimId.VehiclePaymentProcess);
                    StartContinualAssistant(message);
                }
            }
        }

        private void TryToServeArrivalQueue()
        {
            if (vehicleArrivalQueue.Count > 0)
            {
                STKWorker? freeWorker = GetFreeWorker();
                if (freeWorker != null)
                {
                    MessageForm message = vehicleArrivalQueue.Dequeue();
                    freeWorker.isBusy = true;
                    freeWorker.jobType = JobType.Checking;
                    freeWorker.vehicle = ((MyMessage)message)._vehicle;
                    ((MyMessage)message)._workerk1 = freeWorker;
                    takenVehicles.Add(((MyMessage)message)._vehicle.id, ((MyMessage)message)._vehicle);
                    message.Addressee = MyAgent.FindAssistant(SimId.VehicleCheckProcess);
                    StartContinualAssistant(message);
                }
            }
        }

        private STKWorker? GetFreeWorker()
        {
            foreach (STKWorker data in workers1)
            {
                if (!data.isBusy)
                {
                    return data;
                }
            }
            return null;
        }

        private void SetWorkerJobDone(MyMessage? message)
        {
            message._workerk1.isBusy = false;
            message._workerk1.jobType = null;
            message._workerk1.vehicle = null;
            message._workerk1 = null;
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        public void Init()
        {
        }

        override public void ProcessMessage(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.Finish:
                    switch (message.Sender.Id)
                    {
                        case SimId.VehiclePaymentProcess:
                            ProcessFinishVehiclePaymentProcess(message);
                            break;

                        case SimId.VehicleCheckProcess:
                            ProcessFinishVehicleCheckProcess(message);
                            break;
                    }
                    break;

                case Mc.CheckSpace:
                    ProcessCheckSpace(message);
                    break;

                case Mc.VehicleControl:
                    ProcessVehicleControl(message);
                    break;

                case Mc.VehicleService:
                    ProcessVehicleService(message);
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
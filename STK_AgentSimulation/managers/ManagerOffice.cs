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

        public bool breakTime { get; set; }

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
                var newWorker = new STKWorker();
                newWorker.certificate = CertificateType.Basic;
                workers1.Add(newWorker);
            }
            vehicleArrivalQueue = new Queue<MyMessage>();
            vehiclePaymentQueue = new Queue<MyMessage>();
            takenVehicles = new Dictionary<int, STKVehicle>();
            payingVehicles = new Dictionary<int, STKVehicle>();

            breakTime = false;
        }


        //meta! sender="AgentSTK", id="20", type="Request"
        public void ProcessVehicleService(MessageForm message)
        {
            MyAgent.arrivedVehicles++;
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
            MyAgent.finishedVehicles++;
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
            TryToScheduleBreak();
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
                    ((MyMessage)message)._worker = freeWorker;
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
                    ((MyMessage)message)._worker = freeWorker;
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
            message._worker.isBusy = false;
            message._worker.jobType = null;
            message._worker.vehicle = null;
            message._worker = null;
        }

        //meta! sender="Worker1BreakProcess", id="44", type="Finish"
        public void ProcessFinishWorker1BreakProcess(MessageForm message)
        {
            ((MyMessage)message)._worker.breakDoneAt = MySim.CurrentTime;
            SetWorkerJobDone(((MyMessage)message));
        }

        //meta! sender="AgentSTK", id="48", type="Notice"
        public void ProcessWorkerBreak(MessageForm message)
        {
            breakTime = true;
            TryToScheduleBreak();
        }

        private void TryToScheduleBreak()
        {
            if (breakTime & Config.advancedSimulation)
            {
                foreach (STKWorker data in workers1)
                {
                    if (!data.isBusy & data.breakDoneAt == 0)
                    {
                        data.isBusy = true;
                        data.jobType = JobType.Break;
                        MyMessage message = new MyMessage(MySim);
                        message._worker = data;
                        message.Addressee = MyAgent.FindAssistant(SimId.Worker1BreakProcess);
                        StartContinualAssistant(message);
                    }
                }
            }
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
                    switch (message.Sender.Id)
                    {
                        case SimId.VehiclePaymentProcess:
                            ProcessFinishVehiclePaymentProcess(message);
                            break;

                        case SimId.Worker1BreakProcess:
                            ProcessFinishWorker1BreakProcess(message);
                            break;

                        case SimId.VehicleCheckProcess:
                            ProcessFinishVehicleCheckProcess(message);
                            break;
                    }
                    break;

                case Mc.VehicleControl:
                    ProcessVehicleControl(message);
                    break;

                case Mc.WorkerBreak:
                    ProcessWorkerBreak(message);
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
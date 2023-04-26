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
        public bool breakTime { get; set; }
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
            for (int i = 0; i < Config.numberOfWorkers2AllVehicles; i++)
            {
                var newWorker = new STKWorker();
                newWorker.certificate = CertificateType.AllVehicles;
                workers2.Add(newWorker);
            }
            if (Config.advancedSimulation)
            {
                for (int i = 0; i < Config.numberOfWorkers2VanCar; i++)
                {
                    var newWorker = new STKWorker();
                    newWorker.certificate = CertificateType.VanCar;
                    workers2.Add(newWorker);
                }
            }
            vehiclesParkingInFrontOfControlQueue = new Queue<MyMessage>();
            controllingVehicles = new Dictionary<int, STKVehicle>();
            breakTime = false;

        }

		//meta! sender="AgentSTK", id="21", type="Request"
		public void ProcessVehicleControl(MessageForm message)
        {
            vehiclesParkingInFrontOfControlQueue.Enqueue(message as MyMessage);

            TryToScheduleBreak();
            TryToServeParkedVehicles();
        }

        private void TryToServeParkedVehicles()
        {           

            if (vehiclesParkingInFrontOfControlQueue.Count > 0)
            {
                STKWorker? freeWorker = null;
                if (Config.advancedSimulation)
                {
                    freeWorker = GetFreeWorkerAdvanced();
                } else
                {
                    freeWorker = GetFreeWorker();
                }
                
                if (freeWorker != null)
                {
                    MessageForm message = vehiclesParkingInFrontOfControlQueue.Dequeue();
                    // Stats {begin}
                    MyAgent.averageCountOfFreeWorkers2.AddValue(CountFreeWorkers());
                    // {end}
                    freeWorker.isBusy = true;
                    freeWorker.jobType = JobType.Controlling;
                    freeWorker.vehicle = ((MyMessage)message)._vehicle;
                    ((MyMessage)message)._worker = freeWorker;
                    controllingVehicles.Add(((MyMessage)message)._vehicle.id, ((MyMessage)message)._vehicle);
                    message.Addressee = MyAgent.FindAssistant(SimId.VehicleControlProcess);
                    StartContinualAssistant(message);
                }
            }
        }

        private int CountFreeWorkers()
        {
            int countFree = 0;
            foreach (STKWorker data in workers2)
            {
                if (!data.isBusy) countFree++;
            }
            return countFree;
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
        private STKWorker? GetFreeWorkerAdvanced()
        {
            if (vehiclesParkingInFrontOfControlQueue.Peek()._vehicle.vehicleType == VehicleType.Truck)
            {
                foreach (STKWorker data in workers2)
                {
                    if (!data.isBusy & data.certificate == CertificateType.AllVehicles)
                    {
                        return data;
                    }
                }
                return null;

            } else
            {
                foreach (STKWorker data in workers2)
                {
                    if (!data.isBusy & data.certificate == CertificateType.VanCar)
                    {
                        return data;
                    }
                }
                return GetFreeWorker();
            }
        }

        //meta! sender="VehicleControlProcess", id="24", type="Finish"
        public void ProcessFinishVehicleControlProcess(MessageForm message)
        {
            // Control of Vehicle in Garage
            message.Code = Mc.VehicleControl;
            Response(message);

            SetWorkerJobDone(((MyMessage)message));
            controllingVehicles.Remove(((MyMessage)message)._vehicle.id);
            

            TryToScheduleBreak();
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

            ((MyMessage)message).freeWorkers2 = workers2.Count - countBusy;
            Response(message);
        }

		//meta! sender="Worker2BreakProcess", id="47", type="Finish"
		public void ProcessFinishWorker2BreakProcess(MessageForm message)
		{
            ((MyMessage)message)._worker.breakDoneAt = MySim.CurrentTime;
            SetWorkerJobDone(((MyMessage)message));
        }

		//meta! sender="AgentSTK", id="49", type="Notice"
		public void ProcessWorkerBreak(MessageForm message)
		{
            breakTime = true;
            TryToScheduleBreak();
        }
        private void TryToScheduleBreak()
        {
            if (breakTime & Config.advancedSimulation)
            {
                foreach (STKWorker data in workers2)
                {
                    if (!data.isBusy & data.breakDoneAt == 0)
                    {
                        // Stats {begin}
                        MyAgent.averageCountOfFreeWorkers2.AddValue(CountFreeWorkers());
                        // {end}
                        data.isBusy = true;
                        data.jobType = JobType.Break;
                        MyMessage message = new MyMessage(MySim);
                        message._worker = data;
                        message.Addressee = MyAgent.FindAssistant(SimId.Worker2BreakProcess);
                        StartContinualAssistant(message);
                    }
                }
            }
        }
        private void SetWorkerJobDone(MyMessage? message)
        {
            // Stats {begin}
            MyAgent.averageCountOfFreeWorkers2.AddValue(CountFreeWorkers());
            // {end}
            message._worker.isBusy = false;
            message._worker.jobType = null;
            message._worker.vehicle = null;
            message._worker = null;
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
				case SimId.Worker2BreakProcess:
					ProcessFinishWorker2BreakProcess(message);
				break;

				case SimId.VehicleControlProcess:
					ProcessFinishVehicleControlProcess(message);
				break;
				}
			break;

			case Mc.WorkerBreak:
				ProcessWorkerBreak(message);
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
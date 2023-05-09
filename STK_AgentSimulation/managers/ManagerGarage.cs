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
        }

        //meta! sender="AgentSTK", id="21", type="Request"
        public void ProcessVehicleControl(MessageForm message)
        {
            ParkVehicle(message);

            TryToScheduleBreak();
            TryToServeParkedVehicles();
        }

        private void ParkVehicle(MessageForm message)
        {
            if (Config.advancedSimulation)
            {
                if (((MyMessage)message)._vehicle.vehicleType == VehicleType.Truck)
                {
                    MyAgent.vehiclesParkingInFrontOfControlADVANCEDQueue.Enqueue(message as MyMessage);
                }
                else
                {
                    MyAgent.vehiclesParkingInFrontOfControlBASICQueue.Enqueue(message as MyMessage);
                }
            }
            else
            {
                MyAgent.vehiclesParkingInFrontOfControlBASICQueue.Enqueue(message as MyMessage);
            }
        }

        private void TryToServeParkedVehicles()
        {
            if (Config.advancedSimulation)
            {
                TryToServeParkedVehiclesADVANCED();
            }
            else
            {
                TryToServeParkedVehiclesBasic();
            }
        }

        private void TryToServeParkedVehiclesADVANCED()
        {
            STKWorker? freeWorker = null;
            freeWorker = GetFreeWorkerAdvanced();

            if (freeWorker != null)
            {
                if (freeWorker.certificate == CertificateType.AllVehicles
                    & MyAgent.vehiclesParkingInFrontOfControlADVANCEDQueue.Count > 0)
                {
                    MessageForm message = MyAgent.vehiclesParkingInFrontOfControlADVANCEDQueue.Dequeue();
                    // Stats {begin}
                    if (freeWorker.certificate == CertificateType.AllVehicles)
                    {
                        MyAgent.averageCountOfFreeWorkers2AllVehicles.AddValue(CountFreeWorkersAllVehicles());
                    }
                    if (freeWorker.certificate == CertificateType.CarVan)
                    {
                        MyAgent.averageCountOfFreeWorkers2CarVans.AddValue(CountFreeWorkersCarVan());
                    }

                    // {end}
                    freeWorker.isBusy = true;
                    freeWorker.jobType = JobType.Controlling;
                    freeWorker.vehicle = ((MyMessage)message)._vehicle;
                    ((MyMessage)message)._worker = freeWorker;
                    MyAgent.controllingVehicles.Add(((MyMessage)message)._vehicle.id, ((MyMessage)message)._vehicle);
                    message.Addressee = MyAgent.FindAssistant(SimId.VehicleControlProcess);
                    StartContinualAssistant(message);
                }
                else if (MyAgent.vehiclesParkingInFrontOfControlBASICQueue.Count > 0)
                {
                    MessageForm message = MyAgent.vehiclesParkingInFrontOfControlBASICQueue.Dequeue();
                    // Stats {begin}
                    if (freeWorker.certificate == CertificateType.AllVehicles)
                    {
                        MyAgent.averageCountOfFreeWorkers2AllVehicles.AddValue(CountFreeWorkersAllVehicles());
                    }
                    if (freeWorker.certificate == CertificateType.CarVan)
                    {
                        MyAgent.averageCountOfFreeWorkers2CarVans.AddValue(CountFreeWorkersCarVan());
                    }

                    // {end}
                    freeWorker.isBusy = true;
                    freeWorker.jobType = JobType.Controlling;
                    freeWorker.vehicle = ((MyMessage)message)._vehicle;
                    ((MyMessage)message)._worker = freeWorker;
                    MyAgent.controllingVehicles.Add(((MyMessage)message)._vehicle.id, ((MyMessage)message)._vehicle);
                    message.Addressee = MyAgent.FindAssistant(SimId.VehicleControlProcess);
                    StartContinualAssistant(message);
                }
            }

        }

        private void TryToServeParkedVehiclesBasic()
        {
            if (MyAgent.vehiclesParkingInFrontOfControlBASICQueue.Count > 0)
            {
                STKWorker? freeWorker = null;
                freeWorker = GetFreeWorker();
                if (freeWorker != null)
                {
                    MessageForm message = MyAgent.vehiclesParkingInFrontOfControlBASICQueue.Dequeue();
                    // Stats {begin}
                    if (freeWorker.certificate == CertificateType.AllVehicles)
                    {
                        MyAgent.averageCountOfFreeWorkers2AllVehicles.AddValue(CountFreeWorkersAllVehicles());
                    }
                    if (freeWorker.certificate == CertificateType.CarVan)
                    {
                        MyAgent.averageCountOfFreeWorkers2CarVans.AddValue(CountFreeWorkersCarVan());
                    }

                    // {end}
                    freeWorker.isBusy = true;
                    freeWorker.jobType = JobType.Controlling;
                    freeWorker.vehicle = ((MyMessage)message)._vehicle;
                    ((MyMessage)message)._worker = freeWorker;
                    MyAgent.controllingVehicles.Add(((MyMessage)message)._vehicle.id, ((MyMessage)message)._vehicle);
                    message.Addressee = MyAgent.FindAssistant(SimId.VehicleControlProcess);
                    StartContinualAssistant(message);
                }
            }
        }

        private int CountFreeWorkersAllVehicles()
        {
            int countFree = 0;
            foreach (STKWorker data in MyAgent.workers2)
            {
                if (!data.isBusy & data.certificate == CertificateType.AllVehicles) countFree++;
            }
            return countFree;
        }

        private int CountFreeWorkersCarVan()
        {
            int countFree = 0;
            foreach (STKWorker data in MyAgent.workers2)
            {
                if (!data.isBusy & data.certificate == CertificateType.CarVan) countFree++;
            }
            return countFree;
        }

        private STKWorker? GetFreeWorker()
        {
            foreach (STKWorker data in MyAgent.workers2)
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
            if (MyAgent.vehiclesParkingInFrontOfControlADVANCEDQueue.Count > 0)
            {
                foreach (STKWorker data in MyAgent.workers2)
                {
                    if (!data.isBusy & data.certificate == CertificateType.AllVehicles)
                    {
                        return data;
                    }
                }
            }
            foreach (STKWorker data in MyAgent.workers2)
            {
                if (!data.isBusy & data.certificate == CertificateType.CarVan)
                {
                    return data;
                }
            }
            return GetFreeWorker();
        }

        //meta! sender="VehicleControlProcess", id="24", type="Finish"
        public void ProcessFinishVehicleControlProcess(MessageForm message)
        {
            // Control of Vehicle in Garage
            message.Code = Mc.VehicleControl;
            Response(message);

            SetWorkerJobDone(((MyMessage)message));
            MyAgent.controllingVehicles.Remove(((MyMessage)message)._vehicle.id);


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
            ((MyMessage)message).freeParkingSlots = Config.numberOfParkingSlots -
                MyAgent.vehiclesParkingInFrontOfControlBASICQueue.Count -
                MyAgent.vehiclesParkingInFrontOfControlADVANCEDQueue.Count;

            int countBusy = 0;
            foreach (STKWorker data in MyAgent.workers2)
            {
                if (data.isBusy) countBusy++;
            }

            ((MyMessage)message).freeWorkers2 = MyAgent.workers2.Count - countBusy;
            Response(message);
        }

        //meta! sender="Worker2BreakProcess", id="47", type="Finish"
        public void ProcessFinishWorker2BreakProcess(MessageForm message)
        {
            ((MyMessage)message)._worker.breakDoneAt = MySim.CurrentTime;
            SetWorkerJobDone(((MyMessage)message));

            TryToServeParkedVehicles();
        }

        //meta! sender="AgentSTK", id="49", type="Notice"
        public void ProcessWorkerBreak(MessageForm message)
        {
            MyAgent.breakTime = true;
            TryToScheduleBreak();
        }
        private void TryToScheduleBreak()
        {
            if (MyAgent.breakTime & Config.advancedSimulation)
            {
                foreach (STKWorker worker in MyAgent.workers2)
                {
                    if (!worker.isBusy & worker.breakDoneAt == 0)
                    {
                        // Stats {begin}
                        if (worker.certificate == CertificateType.AllVehicles)
                        {
                            MyAgent.averageCountOfFreeWorkers2AllVehicles.AddValue(CountFreeWorkersAllVehicles());
                        }
                        if (worker.certificate == CertificateType.CarVan)
                        {
                            MyAgent.averageCountOfFreeWorkers2CarVans.AddValue(CountFreeWorkersCarVan());
                        }
                        // {end}
                        worker.isBusy = true;
                        worker.jobType = JobType.Break;
                        MyMessage message = new MyMessage(MySim);
                        message._worker = worker;
                        message.Addressee = MyAgent.FindAssistant(SimId.Worker2BreakProcess);
                        StartContinualAssistant(message);
                    }
                }
            }
        }
        private void SetWorkerJobDone(MyMessage? message)
        {
            // Stats {begin}
            if (message._worker.certificate == CertificateType.AllVehicles)
            {
                MyAgent.averageCountOfFreeWorkers2AllVehicles.AddValue(CountFreeWorkersAllVehicles());
            }
            if (message._worker.certificate == CertificateType.CarVan)
            {
                MyAgent.averageCountOfFreeWorkers2CarVans.AddValue(CountFreeWorkersCarVan());
            }
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
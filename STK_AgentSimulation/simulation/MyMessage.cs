using OSPABA;
using STK_AgentSimulation.continualAssistants;
using STK_AgentSimulation.MyOthers.Others;

namespace STK_AgentSimulation.simulation
{
    public class MyMessage : MessageForm
    {
        public STKVehicle? _vehicle { get; set; }
        public STKWorker? _worker { get; set; }

        public int freeParkingSlots { get; set; }
        public int freeWorkers2 { get; set; }
        public MyMessage(Simulation sim) :
            base(sim)
        {
        }

        public MyMessage(MyMessage original) :
            base(original)
        {
            // copy() is called in superclass
        }

        override public MessageForm CreateCopy()
        {
            return new MyMessage(this);
        }

        override protected void Copy(MessageForm message)
        {
            base.Copy(message);
            MyMessage original = (MyMessage)message;
            // Copy attributes
            _vehicle = original._vehicle;

            _worker = original._worker;

            freeParkingSlots = original.freeParkingSlots;
            freeWorkers2 = original.freeWorkers2;
        }
    }
}
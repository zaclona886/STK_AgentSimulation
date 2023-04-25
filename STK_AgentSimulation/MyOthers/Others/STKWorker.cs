using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Others
{
    public class STKWorker
    {
        public bool isBusy;
        public JobType? jobType;       
        public STKVehicle? vehicle;

        public double breakDoneAt;
        public int certificate;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace STK_AgentSimulation.MyOthers.Others
{
    public class STKVehicle
    {
        public int id { get; set; }
        public double arrivalTime { get; set; }
        public VehicleType vehicleType { get; set; }

        public STKVehicle(int id, double arrivalTime, VehicleType vehicleType)
        {
            this.id = id;
            this.arrivalTime = arrivalTime;
            this.vehicleType = vehicleType;
        }
    }
}

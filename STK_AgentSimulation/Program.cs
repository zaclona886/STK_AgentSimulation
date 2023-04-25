using STK_AgentSimulation.simulation;

namespace STK_AgentSimulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simulating...");

            var sim = new MySimulation();
            sim.Simulate(Config.numberOfReplications, Config.simulationTime);

            Console.WriteLine("Finished...");
        }
    }
}
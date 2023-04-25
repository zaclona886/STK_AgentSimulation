using STK_AgentSimulation.simulation;

namespace STK_AgentSimulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simulating...");


            new MySimulation().Simulate(Config.numberOfReplications, Config.simulationTime);

            Console.WriteLine("Finished...");

            Console.ReadKey();
        }
    }
}
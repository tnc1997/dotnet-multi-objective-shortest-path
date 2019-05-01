namespace MultiObjectiveShortestPath.Apps.Console.Models
{
    public class AlgorithmResult
    {
        public double Time { get; }

        public AlgorithmResult(double time)
        {
            Time = time;
        }
    }
}
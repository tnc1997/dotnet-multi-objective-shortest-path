namespace MultiObjectiveShortestPath.Apps.Console.Models
{
    public class WeightedSumAlgorithmResult : AlgorithmResult
    {
        public int NoOfPaths { get; }

        public WeightedSumAlgorithmResult(
            double time,
            int noOfPaths
        ) : base(time)
        {
            NoOfPaths = noOfPaths;
        }
    }
}
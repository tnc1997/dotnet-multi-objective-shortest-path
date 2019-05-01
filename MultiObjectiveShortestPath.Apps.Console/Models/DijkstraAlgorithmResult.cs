namespace MultiObjectiveShortestPath.Apps.Console.Models
{
    public class DijkstraAlgorithmResult : AlgorithmResult
    {
        public int NoOfInteractiveComparisons { get; }
        
        public int NoOfTotalComparisons { get; }
        
        public double PathDistance { get; }
        
        public double PathTime { get; }

        public DijkstraAlgorithmResult(
            double time,
            int noOfInteractiveComparisons,
            int noOfTotalComparisons,
            double pathDistance,
            double pathTime
        ) : base(time)
        {
            NoOfInteractiveComparisons = noOfInteractiveComparisons;
            NoOfTotalComparisons = noOfTotalComparisons;
            PathDistance = pathDistance;
            PathTime = pathTime;
        }
    }
}
namespace MultiObjectiveShortestPath.Apps.Console.Models
{
    public class GeneticAlgorithmResult : AlgorithmResult
    {
        public int NoOfGenerations { get; }
            
        public double MutationProbability { get; }
            
        public double Accuracy { get; }

        public GeneticAlgorithmResult(
            double time,
            int noOfGenerations,
            double mutationProbability,
            double accuracy
        ) : base(time)
        {
            NoOfGenerations = noOfGenerations;
            MutationProbability = mutationProbability;
            Accuracy = accuracy;
        }
    }
}
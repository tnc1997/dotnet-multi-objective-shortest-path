namespace MultiObjectiveShortestPath.Models
{
    public interface IAdder
    {
        object Add(object x, object y);
    }

    public interface IAdder<T>
    {
        T Add(T x, T y);
    }
}
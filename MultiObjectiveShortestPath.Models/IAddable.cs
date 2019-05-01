namespace MultiObjectiveShortestPath.Models
{
    public interface IAddable
    {
        object AddTo(object other);
    }

    public interface IAddable<T>
    {
        T AddTo(T other);
    }
}
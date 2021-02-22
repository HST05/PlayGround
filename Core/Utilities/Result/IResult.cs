namespace Core.Utilities.Result
{
    public interface IResult<T>
    {
        T Data { get; }
        bool Success { get; set; }
        string Message { get; set; }
    }
}

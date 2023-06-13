namespace Common;

public interface IServer
{
    Task<int> AddAsync(int a, int b);
}